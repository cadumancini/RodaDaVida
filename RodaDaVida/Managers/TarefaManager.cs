using RodaDaVidaShared.Repositories;
using RodaDaVidaShared.Tabelas;
using SQLite;
using System.Collections.Generic;

namespace RodaDaVidaShared.Managers
{
    public class TarefaManager
    {
        TarefaRepository repository = null;

        public TarefaManager(SQLiteConnection conn)
        {
            repository = new TarefaRepository(conn);
        }

        public Tarefa GetTarefa(int id)
        {
            return repository.GetTarefa(id);
        }

        public IEnumerable<Tarefa> GetTarefas()
        {
            return repository.GetTarefas();
        }

        public int saveTarefa(Tarefa tarefa)
        {
            return repository.SaveTarefa(tarefa);
        }

        public int deleteTarefa(int id)
        {
            return repository.DeleteTarefa(id);
        }
    }
}
