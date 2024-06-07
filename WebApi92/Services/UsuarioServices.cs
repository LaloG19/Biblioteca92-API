using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi92.Context;

namespace WebApi92.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly ApplicationDBContext _context;

        public UsuarioServices(ApplicationDBContext context)
        {
            _context = context;
        }


        public async Task<Response<List<Usuario>>> GetUsuarios()
        {
            try
            {
                List<Usuario> response = await _context.Usuarios.Include(x => x.Roles).ToListAsync();
                return new Response<List<Usuario>>(response, "Listado encontrado");
            } 
            catch (Exception ex)
            {
                throw new Exception("Error 500, problema del servidor apa \n  " + ex.Message);
            }
        }

        public async Task<Response<Usuario>> GetUsuario(int PkUsuario)
        {
            try
            {
                Usuario response = await _context.Usuarios.FirstOrDefaultAsync(x => x.PkUsuario == PkUsuario);
                if (response == null)
                {
                    return new Response<Usuario>(response, "Usuario no encontrado");
                }
                return new Response<Usuario>(response, "Usuario encontrado");
            }
            catch (Exception ex)
            {
                throw new Exception("Error 500, problema del servidor apa \n  " + ex.Message);
            }
        }
        public async Task<Response<UsuariosResponse>> CrearUsuario(UsuariosResponse request)
        {
            try
            {
                Usuario usuario = new Usuario() 
                {
                    Nombre = request.Nombre,
                    UserName = request.UserName,
                    Password = request.Password,
                    FkRol = request.FkRol
                };

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return new Response<UsuariosResponse>(request, "Usuario creado");

            }
            catch (Exception ex)
            {
                throw new Exception("Error 500, problema del servidor apa \n  " + ex.Message);
            }   
        }
        public async Task<Response<int>> BorrarUsuario(int PkUsuario)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.PkUsuario == PkUsuario);
                if (usuario == null)
                {
                    return new Response<int>(PkUsuario, "Usuario no encontrado");
                }
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                return new Response<int>(PkUsuario, "Usuario eliminado");
            }
            catch (Exception ex)
            {
                throw new Exception("Error 500, problema del servidor apa \n  " + ex.Message);
            }
        }   
        public async Task<Response<UsuariosResponse>> EditarUsuario( int PkUsuario, UsuariosResponse request)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.PkUsuario == PkUsuario);

                if (usuario == null)
                {
                    return new Response<UsuariosResponse>(request, "Usuario con id " + PkUsuario + " no encontrado");
                }
                usuario.Nombre = request.Nombre;
                usuario.UserName = request.UserName;
                usuario.Password = request.Password;
                usuario.FkRol = request.FkRol;
                await _context.SaveChangesAsync();
                return new Response<UsuariosResponse>(request, "Usuario actualizado");
            }
            catch (Exception ex)
            {
                throw new Exception("Error 500, problema del servidor apa \n  " + ex.Message);
            }
        }
    }
}
