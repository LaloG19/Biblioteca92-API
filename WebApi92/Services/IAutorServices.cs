using Domain.Entities;

namespace WebApi92.Services
{
    public interface IAutorServices
    {
        public Task<Response<List<Autor>>> GetAutores();

        public Task<Response<Autor>> CrearAutor(Autor i);



        public Task<Response<int>> BorrarAutor(int PkAutor);
        public Task<Response<AutoresResponse>> EditarAutor(int PkAutor, AutoresResponse request);

        public Task<Response<AutoresResponse>> GetAutor(int PkAutor);
    }
}
