using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Widget;
using RodaDaVidaAndroid.Adapters;
using RodaDaVidaShared.Tabelas;
using Android.Content;

namespace RodaDaVidaAndroid.Telas
{
    [Activity(Label = "Visao_Geral")]
    class VisaoGeral : Activity
    {
        UsuarioAreaItemListAdapter notasListAdapter;
        ProxTarefasItemListAdapter tarefasListAdapter;

        IList<UsuarioArea> notas;
        IList<Tarefa> tarefas;
        ListView notasListView;
        ListView tarefasListView;
        Button btnNovaTarefa;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Definindo layout
            SetContentView(Resource.Layout.VisaoGeral);

            //Buscando os controles
            notasListView = FindViewById<ListView>(Resource.Id.NotasList);
            tarefasListView = FindViewById<ListView>(Resource.Id.ProximasTarefasList);
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
            tarefas = RodaDaVida.Current.dataBaseManager.GetTarefas();

            //Criando os Adapters
            notasListAdapter = new UsuarioAreaItemListAdapter(this, notas);
            tarefasListAdapter = new ProxTarefasItemListAdapter(this, tarefas);

            //Atribuindo os Adapters para as ListVews
            notasListView.Adapter = notasListAdapter;
            tarefasListView.Adapter = tarefasListAdapter;
        }
    }
}