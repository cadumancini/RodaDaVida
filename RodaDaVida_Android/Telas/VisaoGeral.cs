using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Widget;
using RodaDaVidaAndroid.Adapters;
using RodaDaVidaShared.Tabelas;
using Android.Content;
using System;

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

            notas = RodaDaVida.Current.dataBaseManager.GetUsuariosAreas("CODIGO");
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
                    ", e teremos que descontar 0,5 ponto de cada: \n\n";
                foreach (UsuarioArea UArea in areasDescontar)
                {
                    Area area = RodaDaVida.Current.dataBaseManager.GetArea(UArea.AreaID);
                    mensagem += area.Descricao + "\n";

                    if (UArea.Nota > 0.5)
                        UArea.Nota -= 0.5;
                    else if (UArea.Nota > 0)
                        UArea.Nota = 0;

                    UArea.DataUltReducao = DateTime.Now;
                    RodaDaVida.Current.dataBaseManager.saveUsuarioArea(UArea);
                }

                mensagem += "Sugerimos que você preste atenção às áreas afetadas, e crie agora mesmo uma tarefa para melhorar a sua pontuação!";

                //set alert for executing the task
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
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