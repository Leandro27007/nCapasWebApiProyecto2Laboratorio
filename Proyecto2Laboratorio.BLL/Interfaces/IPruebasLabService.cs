﻿using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.BLL.Interfaces
{
    public interface IPruebasLabService
    {
        Task<IEnumerable<PruebaLabDTO>?> ListarPruebas();
        Task<PruebaLabDTO?> CrearPruebaLabAsync(CreacionPruebaLabDTO creacionPruebaLabDTO);
        Task<bool?> EditarPruebaLabAsync(EdicionPruebaLabDTO creacionPruebaLabDTO);
        Task<bool?> EliminarPruebaLabAsync(int IdPrueba);

    }
}
