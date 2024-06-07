using Domain.Entities;

namespace WebApi92.Services
{
    public interface IUsuarioServices
    {


        public Task<Response<List<Usuario>>> GetUsuarios();
        public Task<Response<UsuariosResponse>> CrearUsuario(UsuariosResponse request);
        public Task<Response<int>> BorrarUsuario(int PkUsuario);
        public Task<Response<UsuariosResponse>> EditarUsuario( int PkUsuario, UsuariosResponse request);
        public Task<Response<Usuario>> GetUsuario(int PkUsuario);
    }
}
