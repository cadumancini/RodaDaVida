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
using RodaDaVidaAndroid.Adapters;
using RodaDaVidaShared.Tabelas;

namespace RodaDaVidaAndroid.Telas
{
    [Activity(Label = "Visao_Geral")]
    class VisaoGeral : Activity
    {
        UsuarioAreaItemListAdapter listAdapter;
        IList<UsuarioArea> notas;
        ListView notasListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Definindo layout
            SetContentView(Resource.Layout.VisaoGeral);

            //Buscando os controles
            notasListView = FindViewById<ListView>(Resource.Id.NotasList);

        }

        protected override void OnResume()
        {
            base.OnResume();

            notas = RodaDaVida.Current.dataBaseManager.GetUsuariosAreas();

            //Criando o Adapter
            listAdapter = new UsuarioAreaItemListAdapter(this, notas);

            //Atribuindo o Adapter para a ListVew
            notasListView.Adapter = listAdapter;
        }
    }
}