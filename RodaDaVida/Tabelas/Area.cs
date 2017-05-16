using SQLite;
using System;

namespace RodaDaVidaShared.Tabelas
{
    public class Area
    {
        public Area()
        {
        }

        //SQLite attributes
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Descricao { get; set; }
    }
}
