using SQLite;
using System;

namespace RodaDaVidaShared.Tabelas
{
    public class UsuarioArea
    {
        public UsuarioArea()
        {
        }

        //SQLite attributes
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [Indexed]
        public int UsuarioID { get; set; }

        [Indexed]
        public int AreaID { get; set; }
        public int CodigoArea { get; set; }
        public double Nota { get; set; }
        public DateTime DataUltTarefa { get; set; }
    }
}
