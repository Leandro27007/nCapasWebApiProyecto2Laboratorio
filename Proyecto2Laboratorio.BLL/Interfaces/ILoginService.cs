﻿using Proyecto2Laboratorio.Shared.Models;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.BLL.Interfaces
{
    public interface ILoginService
    {
        Task<ServiceResponse> LoginUserAsync(Login model);
    }
}
