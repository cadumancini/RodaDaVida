using RodaDaVidaShared.Contracts;
using RodaDaVidaShared.Tabelas;
using SQLite;
using System.Collections.Generic;

namespace RodaDaVidaShared.Repositories
{
    public class UsuarioRepository
    {
        Database db = null;

        public UsuarioRepository(SQLiteConnection conn)
        {
            db = new Database(conn);
        }

        public Usuario GetUsuario(int id)
        {
            return db.GetUsuario(id);
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            return db.GetUsuarios();
        }

        public int SaveUsuario(Usuario usuario)
        {
            return db.SaveUsuario(usuario);
        }

        public int DeleteUsuario(int id)
        {
            return db.DeleteUsuario(id);
        }
    }
}
