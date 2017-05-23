using RodaDaVidaShared.Repositories;
using RodaDaVidaShared.Tabelas;
using SQLite;
using System.Collections.Generic;

namespace RodaDaVidaShared.Contracts
{
    public class DatabaseManager
    {
        UsuarioRepository usuarioRepository { get; set; } = null;
        AreaRepository areaRepository { get; set; } = null;
        UsuarioAreaRepository usuarioAreaRepository { get; set; } = null;
        TarefaRepository tarefaRepository { get; set; } = null;

        public DatabaseManager(SQLiteConnection conn)
        {
            usuarioRepository = new UsuarioRepository(conn);
            areaRepository = new AreaRepository(conn);
            usuarioAreaRepository = new UsuarioAreaRepository(conn);
            tarefaRepository = new TarefaRepository(conn);
        }

        public Usuario GetUsuario(int id)
        {
            return usuarioRepository.GetUsuario(id);
        }

        public IList<Usuario> GetUsuarios()
        {
            return new List<Usuario>(usuarioRepository.GetUsuarios());
        }

        public int saveUsuario(Usuario usuario)
        {
            return usuarioRepository.SaveUsuario(usuario);
        }

        public int deleteUsuario(int id)
        {
            return usuarioRepository.DeleteUsuario(id);
        }

        public Area GetArea(int id)
        {
            return areaRepository.GetArea(id);
        }

        public IList<Area> GetAreas()
        {
            return new List<Area>(areaRepository.GetAreas());
        }

        public int saveArea(Area area)
        {
            return areaRepository.SaveArea(area);
        }

        public int deleteArea(int id)
        {
            return areaRepository.DeleteArea(id);
        }

        public UsuarioArea GetUsuarioArea(int id)
        {
            return usuarioAreaRepository.GetUsuarioArea(id);
        }

        public IList<UsuarioArea> GetUsuariosAreas()
        {
            return new List<UsuarioArea>(usuarioAreaRepository.GetUsuariosAreas());
        }

        public IList<UsuarioArea> GetUsuariosAreasADefinir()
        {
            return new List<UsuarioArea>(usuarioAreaRepository.GetUsuariosAreasADefinir());
        }

        public IList<UsuarioArea> GetUsuariosAreasByCodigo(int codigo)
        {
            return new List<UsuarioArea>(usuarioAreaRepository.GetUsuariosAreasByCodigo(codigo));
        }

        public int saveUsuarioArea(UsuarioArea usuarioArea)
        {
            return usuarioAreaRepository.SaveUsuarioArea(usuarioArea);
        }

        public int deleteUsuarioArea(int id)
        {
            return usuarioAreaRepository.DeleteUsuarioArea(id);
        }

        public Tarefa GetTarefa(int id)
        {
            return tarefaRepository.GetTarefa(id);
        }

        public IList<Tarefa> GetTarefas()
        {
            return new List<Tarefa>(tarefaRepository.GetTarefas());
        }

        public int saveTarefa(Tarefa tarefa)
        {
            return tarefaRepository.SaveTarefa(tarefa);
        }

        public int deleteTarefa(int id)
        {
            return tarefaRepository.DeleteTarefa(id);
        }
    }
}
