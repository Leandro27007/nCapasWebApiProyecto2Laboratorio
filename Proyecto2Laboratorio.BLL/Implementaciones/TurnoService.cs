﻿using DTOs;
using Microsoft.EntityFrameworkCore;
using Proyecto2Laboratorio.BLL.Interfaces;
using Proyecto2Laboratorio.DAL.Repositorio.Interfaces;
using Proyecto2Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.BLL.Implementaciones
{
    public class TurnoService : ITurnoService
    {
        private readonly ITurnoRepositorio _turnoRepositorio;
        public TurnoService(ITurnoRepositorio turnoRepositorio)
        {
            this._turnoRepositorio = turnoRepositorio;
        }

        public async Task<bool> Atender(string idTurno)
        {
            //Obtengo el turno de la base de datos que su id sea igual a mi parametro
            var turno = await _turnoRepositorio.Obtener(t => t.TurnoId == idTurno);

            //Si existe le cambio el estado a 2, o sea atendido.
            if (turno != null)
            {
                turno.EstadoTurno = "Atendido";
                await _turnoRepositorio.Editar(turno);

                return true;
            }
            return false;
        }

        public async Task<bool> CancelarTurno(string idTurno)
        {
            //Obtengo el turno de la base de datos que su id sea igual a mi parametro
            var turno = await _turnoRepositorio.Obtener(t => t.TurnoId == idTurno);

            //Si existe le cambio el estado a 3, o sea cancelado.
            if (turno != null)
            {
                turno.EstadoTurno = "Cancelado";
                await _turnoRepositorio.Editar(turno);

                return true;
            }
            return false;
        }

        public async Task<Turno> GenerarTurno(GenerarTurnoDTO Turno)
        {
            //Pido a la capa Datos que me traiga el ultimo id de turno que esta registrado
            var consulta = _turnoRepositorio.Consultar();
            var turno = await consulta.OrderBy(t => t.TurnoId).Select(t => t.TurnoId).LastOrDefaultAsync();

            turno ??= "0";

            string ultimoTurnoId = await _turnoRepositorio.ObtenerSiguienteTurno();

            //int numeroTurno = ExtraerNumeroDeIdTurno(ultimoTurno);
            //numeroTurno += 1;
            //Coloco el turno en el formato debido (T-0)
            //string turnoIdFormateado = $"T-{numeroTurno}";


            //Creo y asigno pruebasLaboratorio en un objeto para el turno que se va a crear.
            var turnoPruebaLab = new List<TurnoPruebaDeLaboratorio>();
            for (int i = 0; i <= Turno.PruebasLab.Count - 1; i++)
            {
                turnoPruebaLab.Add(new TurnoPruebaDeLaboratorio()
                {
                    PruebaDeLaboratorioId = Turno.PruebasLab[i].IdPruebaLab,
                    TurnoId = ultimoTurnoId
                });

            }


            //mando a crear el turno en la base de datos y lo retorno
            return await _turnoRepositorio.Crear(new Turno()
            {
                TurnoId = ultimoTurnoId,
                EstadoTurno = "Pendiente",
                FechaRegistro = DateTime.Now,
                turnoPruebaDeLaboratorios = turnoPruebaLab
            });

        }

        public async Task<List<TurnoDTO>> ListarTurnosPendientes()
        {

            var consulta =  _turnoRepositorio.Consultar().Where(t => 
            t.EstadoTurno == "Pendiente").OrderByDescending(t => t.FechaRegistro).AsQueryable();


            var lista = await consulta.Select(t => new TurnoDTO()
            {
                IdTurno = t.TurnoId,

                PruebasLab = t.turnoPruebaDeLaboratorios.Select(tp => new PruebaLabTurnoDTO()
                {
                    IdPruebaLab = tp.PruebaDeLaboratorioId,
                    NombrePrueba = tp.PruebaDeLaboratorio.Nombre
                }).ToList()

            }).ToListAsync();


            return lista;
        }

        public async Task<List<TurnoDTO>> HistorialTurnos()
        {
            var consulta = _turnoRepositorio.Consultar().OrderByDescending(t => t.FechaRegistro).AsQueryable();

            var lista = await consulta.Select(t => new TurnoDTO()
            {
                IdTurno = t.TurnoId,

                PruebasLab = t.turnoPruebaDeLaboratorios.Select(tp => new PruebaLabTurnoDTO()
                {
                    IdPruebaLab = tp.PruebaDeLaboratorioId,
                    NombrePrueba = tp.PruebaDeLaboratorio.Nombre
                }).ToList()

            }).ToListAsync();


            return lista;
        }

        public async Task<bool> ResetearTurnos()
        {
            var turnos = await _turnoRepositorio.ObtenerTodo();
            if (turnos != null)
            {
                foreach (var item in turnos)
                {
                    await _turnoRepositorio.Eliminar(item);
                }
                return true;
            }
            return false;
        }



    }
}
