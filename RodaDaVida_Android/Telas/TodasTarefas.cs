using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using RodaDaVidaAndroid.Adapters;
using RodaDaVidaShared.Tabelas;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Views;

namespace RodaDaVidaAndroid.Telas
{
    [Activity(Label = "Todas_Tarefas")]
    class TodasTarefas : AppCompatActivity
    {
        TodasTarefasItemListAdapter tarefasListAdapter;
        IList<Tarefa> tarefas;
        ListView tarefasListView;
        CheckBox tarefaConcluida;
        bool mostrarTarefasConcluidas;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
            Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            //Definindo layout
            SetContentView(Resource.Layout.TodasTarefas);

            //Acrescentando toolbar
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            //Toolbar will now take on default actionbar characteristics
            SetSupportActionBar(toolbar);

            SupportActionBar.Title = "Todas as Tarefas";
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            //Buscando os controles
            tarefasListView = FindViewById<ListView>(Resource.Id.TodasTarefasList);
            tarefaConcluida = FindViewById<CheckBox>(Resource.Id.chckTarefasConcluidas);

            mostrarTarefasConcluidas = false;

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

            //Pegando clique no filtro de tarefas concluidas
            if (tarefaConcluida != null)
            {
                tarefaConcluida.CheckedChange += (object sender, CheckBox.CheckedChangeEventArgs e) =>
                {
                    if (tarefaConcluida.Checked)
                        mostrarTarefasConcluidas = true;
                    else
                        mostrarTarefasConcluidas = false;

                    atualizarAdapter();
                };
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            //Back button pressed -> toggle event
            if (item.ItemId == Android.Resource.Id.Home)
                this.OnBackPressed();

            return base.OnOptionsItemSelected(item);
        }

        protected override void OnResume()
        {
            base.OnResume();
            atualizarAdapter();
        }

        protected void atualizarAdapter()
        {
            tarefas = RodaDaVida.Current.dataBaseManager.GetTarefas(mostrarTarefasConcluidas);

            //Criando o Adapter
            tarefasListAdapter = new TodasTarefasItemListAdapter(this, tarefas);

            //Atribuindo o Adapter para a ListVew
            tarefasListView.Adapter = tarefasListAdapter;
        }
    }
}