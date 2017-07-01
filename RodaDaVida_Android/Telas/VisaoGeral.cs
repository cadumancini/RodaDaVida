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

            //Pegando clique em nova tarefa
            if(btnNovaTarefa != null)
            {
                btnNovaTarefa.Click += (sender, e) =>
                {
                    var telaNovaTarefa = new Intent(this, typeof(NovaTarefa)).SetFlags(ActivityFlags.ReorderToFront);
                    StartActivity(telaNovaTarefa);
                };
            }

            //Pegando clique em item da lista de tarefas
            if (tarefasListView != null)
            {
                tarefasListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
                {
                    var tarefaDetalhe = new Intent(this, typeof(NovaTarefa));
                    tarefaDetalhe.PutExtra("TarefaID", tarefas[e.Position].ID);
                    StartActivity(tarefaDetalhe);
                };
            }

        }

        protected override void OnResume()
        {
            base.OnResume();

            notas = RodaDaVida.Current.dataBaseManager.GetUsuariosAreas();
            tarefas = RodaDaVida.Current.dataBaseManager.GetTarefas();

            //Deixando lista de tarefas apenas com as 10 primeiras da lista
            if(tarefas.Count > 10)
            {
                IList<Tarefa> tarefasTmp = new List<Tarefa>();
                int idx = 0;
                foreach(Tarefa tmp in tarefas)
                {
                    idx++;
                    tarefasTmp.Add(tmp);
                    if (idx == 10)
                        break;
                }
                tarefas = tarefasTmp;
            }

            //Criando os Adapters
            notasListAdapter = new UsuarioAreaItemListAdapter(this, notas);
            tarefasListAdapter = new ProxTarefasItemListAdapter(this, tarefas);

            //Atribuindo os Adapters para as ListVews
            notasListView.Adapter = notasListAdapter;
            tarefasListView.Adapter = tarefasListAdapter;
        }
    }
}