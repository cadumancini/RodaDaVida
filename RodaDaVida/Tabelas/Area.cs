using SQLite;

namespace RodaDaVidaShared.Tabelas
{
    public class Area
    {
        public Area()
        {
        }

        //SQLite attributes
        [PrimaryKey, AutoIncrement, Unique]
        public int ID { get; set; }

        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
