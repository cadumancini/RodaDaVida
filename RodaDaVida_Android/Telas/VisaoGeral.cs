﻿using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Widget;
using Android.Content;
using Android.Support.Design.Widget;
using RodaDaVidaAndroid.Adapters;
using RodaDaVidaShared.Tabelas;
using System;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V4.Widget;
using Android.Views;

namespace RodaDaVidaAndroid.Telas
{
    [Activity(Label = "Visao_Geral")]
    class VisaoGeral : AppCompatActivity
    {
        //UsuarioAreaItemListAdapter notasListAdapter;
        ProxTarefasItemListAdapter tarefasListAdapter;

        IList<UsuarioArea> notas;
        IList<Tarefa> tarefas;
        //ListView notasListView;
        ListView tarefasListView;
        //Button btnTodasTarefas;
        FloatingActionButton btnNovaTarefa;
        DrawerLayout drawerLayout;
        NavigationView navigationView;
        TextView chamadaTarefa;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
            Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            //Definindo layout
            SetContentView(Resource.Layout.VisaoGeral);

            //Acrescentando toolbar
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            //Toolbar will now take on default actionbar characteristics
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Visão Geral - Roda da Vida";

            //Enable support action bar to display hamburger
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += (sender, e) => {
                e.MenuItem.SetChecked(true);
                switch (e.MenuItem.ItemId)
                {
                    case (Resource.Id.nav_visao_geral):
                        drawerLayout.CloseDrawers();
                        break;
                    case (Resource.Id.nav_todas_tarefas):
                        var telaTodasTarefas = new Intent(this, typeof(TodasTarefas));
                        StartActivity(telaTodasTarefas);
                        break;
                    case (Resource.Id.nav_config):
                        var telaConfigs = new Intent(this, typeof(Configs));
                        StartActivity(telaConfigs);
                        break;
                }
                e.MenuItem.SetChecked(false);
                drawerLayout.CloseDrawers();
            };

            //Buscando os controles
            //notasListView = FindViewById<ListView>(Resource.Id.NotasList);
            tarefasListView = FindViewById<ListView>(Resource.Id.ProximasTarefasList);
            btnNovaTarefa = FindViewById<FloatingActionButton>(Resource.Id.btnNovaTarefa);
            chamadaTarefa = FindViewById<TextView>(Resource.Id.txtSemTarefas);
            //btnTodasTarefas = FindViewById<Button>(Resource.Id.btnTodasTarefas);

            //Pegando clique em nova tarefa
            if (btnNovaTarefa != null)
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

            /*
            //Pegando clique em botão para mostrar todas as tarefas
            if(btnTodasTarefas != null)
            {
                btnTodasTarefas.Click += (sender, e) =>
                {
                    var telaTodasTarefas = new Intent(this, typeof(TodasTarefas));
                    StartActivity(telaTodasTarefas);
                };
            }*/

        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        protected override void OnResume()
        {
            base.OnResume();

            notas = RodaDaVida.Current.dataBaseManager.GetUsuariosAreas("CODIGO");
            tarefas = RodaDaVida.Current.dataBaseManager.GetTarefas(false);

            //Deixando lista de tarefas apenas com as 10 primeiras da lista
            if(tarefas.Count > 10)
            {
                chamadaTarefa.Visibility = ViewStates.Invisible;
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

            if (tarefas.Count == 0) // Não tem nenhuma tarefa. Exibir chamada para Nova Tarefa
                chamadaTarefa.Visibility = ViewStates.Visible;
            else
                chamadaTarefa.Visibility = ViewStates.Gone;

            //Criando os Adapters
            //notasListAdapter = new UsuarioAreaItemListAdapter(this, notas);
            tarefasListAdapter = new ProxTarefasItemListAdapter(this, tarefas);

            //Atribuindo os Adapters para as ListVews
            //notasListView.Adapter = notasListAdapter;
            tarefasListView.Adapter = tarefasListAdapter;

            //Verificando se é hora de abaixar pontos de alguma área:
            DateTime hoje = DateTime.Now;
            DateTime dataNula = new DateTime(1, 1, 1);
            var difDias = 0;
            IList<UsuarioArea> areasDescontar = new List<UsuarioArea>();
            foreach(UsuarioArea area in notas)
            {
                if (area.DataUltTarefa != dataNula) // já fez alguma tarefa?
                {
                    difDias = hoje.Subtract(area.DataUltTarefa).Days;
                    if (difDias > 15) // se a última tarefa feita foi há mais de 15 dias
                    {
                        if ((hoje.Subtract(area.DataUltReducao).Days) > 15) // se o último desconto foi a mais de 15 dias
                            areasDescontar.Add(area);
                    }
                }
                else // não fez nenhuma tarefa ainda
                {
                    if ((hoje.Subtract(area.DataUltReducao).Days) > 15) // se o último desconto foi a mais de 15 dias
                        areasDescontar.Add(area);
                }
            }
        
            //Temos alguma área a descontar notas?
            if (areasDescontar.Count > 0)
            {
                var mensagem = "Olá! Infelizmente você não concluiu nenhuma tarefa na(s) área(s) abaixo" +
                    ", e teremos que descontar 1 ponto de cada: \n\n";
                foreach (UsuarioArea UArea in areasDescontar)
                {
                    Area area = RodaDaVida.Current.dataBaseManager.GetArea(UArea.AreaID);
                    mensagem += area.Descricao + "\n";

                    if (UArea.Nota > 1)
                        UArea.Nota -= 1;
                    else
                        UArea.Nota = 0;

                    UArea.DataUltReducao = DateTime.Now;
                    RodaDaVida.Current.dataBaseManager.saveUsuarioArea(UArea);
                }

                mensagem += "Sugerimos que você preste atenção às áreas afetadas, e crie agora mesmo uma tarefa para melhorar a sua pontuação!";

                //set alert for executing the task
                Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(this);
                alert.SetTitle("Antenção!");
                alert.SetMessage(mensagem);
                alert.SetNeutralButton("OK", (senderAlert, args) => {
                    return;
                });

                Dialog dialog = alert.Create();
                dialog.Show();

            }
        }
    }
}