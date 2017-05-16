using RodaDaVidaShared.Repositories;
using RodaDaVidaShared.Tabelas;
using SQLite;
using System.Collections.Generic;

namespace RodaDaVidaShared.Managers
{
    public class UsuarioAreaManager
    {
        UsuarioAreaRepository repository = null;

        public UsuarioAreaManager(SQLiteConnection conn)
        {
            repository = new UsuarioAreaRepository(conn);
        }

        public UsuarioArea GetUsuarioArea(int id)
        {
            return repository.GetUsuarioArea(id);
        }

        public IEnumerable<UsuarioArea> GetUsuariosAreas()
        {
            return repository.GetUsuariosAreas();
        }

        public int saveUsuarioArea(UsuarioArea usuarioArea)
        {
            return repository.SaveUsuarioArea(usuarioArea);
        }

        public int deleteUsuarioArea(int id)
        {
            return repository.DeleteUsuarioArea(id);
        }
    }
}
