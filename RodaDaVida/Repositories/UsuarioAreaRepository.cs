using RodaDaVidaShared.Contracts;
using RodaDaVidaShared.Tabelas;
using SQLite;
using System.Collections.Generic;

namespace RodaDaVidaShared.Repositories
{
    public class UsuarioAreaRepository
    {
        Database db = null;

        public UsuarioAreaRepository(SQLiteConnection conn)
        {
            db = new Database(conn);
        }

        public UsuarioArea GetUsuarioArea(int id)
        {
            return db.GetUsuarioArea(id);
        }

        public IEnumerable<UsuarioArea> GetUsuariosAreas()
        {
            return db.GetUsuariosAreas();
        }

        public int SaveUsuarioArea(UsuarioArea usuarioArea)
        {
            return db.SaveUsuarioArea(usuarioArea);
        }

        public int DeleteUsuarioArea(int id)
        {
            return db.DeleteUsuarioArea(id);
        }
    }
}
