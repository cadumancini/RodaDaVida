using RodaDaVidaShared.Repositories;
using RodaDaVidaShared.Tabelas;
using SQLite;
using System.Collections.Generic;

namespace RodaDaVidaShared.Managers
{
    public class UsuarioManager
    {
        UsuarioRepository repository = null;

        public UsuarioManager(SQLiteConnection conn)
        {
            repository = new UsuarioRepository(conn);
        }

        public Usuario GetUsuario(int id)
        {
            return repository.GetUsuario(id);
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            return repository.GetUsuarios();
        }

        public int saveUsuario(Usuario usuario)
        {
            return repository.SaveUsuario(usuario);
        }

        public int deleteUsuario(int id)
        {
            return repository.DeleteUsuario(id);
        }
    }
}
