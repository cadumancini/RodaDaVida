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
using Android.Support.V7.App;
using RodaDaVidaAndroid.Adapters;
using RodaDaVidaAndroid.Classes;
using RodaDaVidaShared.Tabelas;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace RodaDaVidaAndroid.Telas
{
    [Activity(Label = "Configs")]
    class Configs : AppCompatActivity
    {
        ConfigsListAdapter configsAdapter;
        IList<ConfigItem> configsItens;
        ListView configsList;
        int idUsuario;
        Usuario usuario;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //Definindo layout
            SetContentView(Resource.Layout.Configs);

            //Acrescentando toolbar
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            //Toolbar will now take on default actionbar characteristics
            SetSupportActionBar(toolbar);

            SupportActionBar.Title = "Configurações";
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            configsList = FindViewById<ListView>(Resource.Id.ConfigsList);

            idUsuario = RodaDaVida.Current.idUsuarioGeral;
            usuario = RodaDaVida.Current.dataBaseManager.GetUsuario(idUsuario);

            configsItens = new List<ConfigItem>();
            configsItens.Add(new ConfigItem("alteraNome", "Alterar Nome do Usuário", "Nome Atual: " + usuario.Nome));
            configsItens.Add(new ConfigItem("reavaliar", "Fazer Reavaliação", "Toque para reavaliar as áreas da sua vida"));
        }

        protected override void OnResume()
        {
            base.OnResume();

            //Criando o Adapter
            configsAdapter = new ConfigsListAdapter(this, configsItens);

            //Atribuindo o Adapter para a ListVew
            configsList.Adapter = configsAdapter;
        }
    }
}