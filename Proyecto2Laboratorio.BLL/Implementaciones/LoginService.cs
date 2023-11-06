using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Proyecto2Laboratorio.BLL.Interfaces;
using Proyecto2Laboratorio.DAL;
using SharedLibrary.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.BLL.Implementaciones
{
    public class LoginService : ILoginService
    {
        private readonly ApplicationDbContext appDbContext;
        private readonly IConfiguration config;
        public LoginService(ApplicationDbContext appDbContext, IConfiguration config)
        {
            this.appDbContext = appDbContext;
            this.config = config;
        }

        public async Task<ServiceResponse> LoginUserAsync(Login model)
        {
            var getUser = await appDbContext.usuario.Where(_ => _.Username!.Equals(model.UserName)).FirstOrDefaultAsync();
            if (getUser == null) return new ServiceResponse() { Flag = false, Message = "User not found" };

            var checkIfPasswordMatch = VerifyUserPassword(model.Password!, getUser.Password!);

            if (checkIfPasswordMatch)
            {
                //get user role from the roles table
                var getUserRole = await appDbContext.usuario.Include(u => u.Role).Where(_ => _.UsuarioId == getUser.UsuarioId).FirstOrDefaultAsync();

                //Generate token with the role, and username as email
                var token = GenerateToken(getUser.Username, model.UserName!, getUserRole!.Role.NombreRol!);

                //var checkIfTokenExist = await appDbContext.TokenInfo.Where(_ => _.UserId == getUser.Id).FirstOrDefaultAsync();
                //if (checkIfTokenExist == null)
                //{
                //    appDbContext.TokenInfo.Add(new TokenInfo() { Token = token, UserId = getUser.Id });
                //    await appDbContext.SaveChangesAsync();
                //    return new ServiceResponse() { Flag = true, Token = token };
                //}
                //checkIfTokenExist.Token = token;
                //await appDbContext.SaveChangesAsync();
                return new ServiceResponse() { Flag = true, Token = token };
            }
            return new ServiceResponse() { Flag = false, Message = "Invalid email or password" };
        }

        //Decrypt user database password and encrypt user raw password and compare
        private static bool VerifyUserPassword(string rawPassword, string databasePassword)
        {
            byte[] dbPasswordHash = Convert.FromBase64String(databasePassword);
            byte[] salt = new byte[16];
            Array.Copy(dbPasswordHash, 0, salt, 0, 16);
            var rfcPassword = new Rfc2898DeriveBytes(rawPassword, salt, 1000, HashAlgorithmName.SHA1);
            byte[] rfcPasswordHash = rfcPassword.GetBytes(20);
            for (int i = 0; i < rfcPasswordHash.Length; i++)
            {
                if (dbPasswordHash[i + 16] != rfcPasswordHash[i])
                    return false;
            }
            return true;
        }

        private string GenerateToken(string name, string email, string roleName)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, roleName)
            };
            var token = new JwtSecurityToken(
                //issuer: config["Jwt:Issuer"],
                //audience: config["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
