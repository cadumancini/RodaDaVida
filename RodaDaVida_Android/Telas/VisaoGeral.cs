using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Widget;
using RodaDaVidaAndroid.Adapters;
using RodaDaVidaShared.Tabelas;
using Android.Views;
using Android.Content;

namespace RodaDaVidaAndroid.Telas
{
    [Activity(Label = "Visao_Geral")]
    class VisaoGeral : Activity
    {
        UsuarioAreaItemListAdapter listAdapter;
        IList<UsuarioArea> notas;
        ListView notasListView;
        Button btnNovaTarefa;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Definindo layout
            SetContentView(Resource.Layout.VisaoGeral);

            //Buscando os controles
            notasListView = FindViewById<ListView>(Resource.Id.NotasList);
            btnNovaTarefa = FindViewById<Button>(Resource.Id.btnNovaTarefa);

            if(btnNovaTarefa != null)
            {
                btnNovaTarefa.Click += (sender, e) =>
                {
                    var telaNovaTarefa = new Intent(this, typeof(NovaTarefa)).SetFlags(ActivityFlags.ReorderToFront);
                    StartActivity(telaNovaTarefa);
                };
            }

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