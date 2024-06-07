using Dapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi92.Context;

namespace WebApi92.Services
{
    public class AutorServices : IAutorServices
    {
        private readonly ApplicationDBContext _context;
        public AutorServices(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Autor>>> GetAutores()
        {
            try
            {
                List<Autor> Response = new List<Autor>();
                var result= await _context.Database.GetDbConnection().QueryAsync<Autor>("spGetAllAutores", new {}, commandType: CommandType.StoredProcedure);
                Response = result.ToList();
                return new Response<List<Autor>>(Response, "Listado encontrado");
            }
            catch (Exception ex)
            {
                throw new Exception("Error 500, problema del servidor apa \n  " + ex.Message);
            }
        }

        public async  Task<Response<Autor>> CrearAutor([FromBody]Autor i)
        {
            try
            {
                Autor result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("spCrearAutor", new { i.Nombre, i.Nacionalidad}, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                return new Response<Autor>(result, "Autor creado");
            }
            catch{
                throw new Exception("Error 500, problema del servidor apa");
            }
        }






        public async Task<Response<int>> BorrarAutor(int PkAutor)
        {
            try
            {
                await _context.Database.GetDbConnection().QueryAsync<Autor>("spBorrarAutor", new { PkAutor }, commandType: CommandType.StoredProcedure);
                return new Response<int>(PkAutor, "Autor eliminado");
            }
            catch (Exception ex)
            {
                throw new Exception("Error 500, problema del servidor apa \n  " + ex.Message);
            }
        }
        public async Task<Response<AutoresResponse>> EditarAutor(int PkAutor, AutoresResponse request)
        {
            try
            {
                AutoresResponse result = (await _context.Database.GetDbConnection().QueryAsync<AutoresResponse>("spEditarAutor", new { PkAutor, request.Nombre, request.Nacionalidad }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                return new Response<AutoresResponse>(result, "Autor con ID: " + PkAutor +  " editado");
            }
            catch (Exception ex)
            {
                throw new Exception("Error 500, problema del servidor apa \n  " + ex.Message);
            }
        }
        public async Task<Response<AutoresResponse>> GetAutor(int PkAutor)
        {
            try
            {
                AutoresResponse result = (await _context.Database.GetDbConnection().QueryAsync<AutoresResponse>("spBuscarAutor", new { PkAutor }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                return new Response<AutoresResponse>(result, "Autor encontrado");
            }
            catch (Exception ex)
            {
                throw new Exception("Error 500, problema del servidor apa \n  " + ex.Message);
            }
        }
    }
}
