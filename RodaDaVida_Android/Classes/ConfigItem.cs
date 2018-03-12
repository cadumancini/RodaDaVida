using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RodaDaVidaAndroid.Classes
{
    class ConfigItem
    {
        public string ID { get; set; }
        public string Cabecalho { get; set; }
        public string Descricao { get; set; }

        public ConfigItem(string novoID, string novoCabecalho, string novaDescricao)
        {
            ID = novoID;
            Cabecalho = novoCabecalho;
            Descricao = novaDescricao;
        }
    }
}