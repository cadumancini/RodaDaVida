﻿using System;

using Android.App;
using Android.OS;
using Android.Widget;
using Android.Util;
using RodaDaVidaShared.Tabelas;
using Android.Views;
using RodaDaVidaShared.Utils;

namespace RodaDaVidaAndroid.Telas
{
    [Activity(Label = "NovaTarefa")]
    public class NovaTarefa : Activity
    {
        Button btnSelecionarData, btnSalvar, btnExcluir;
        EditText editTarefaNomeCurto, editTarefaDescricao, editTarefaOnde, editTarefaQuando, editTarefaComo;
        DateTime dataTarefa;
        Spinner spinnerArea;
        CheckBox chckTarefaConcluida;
        Area areaAtual;
        Tarefa tarefa = new Tarefa();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Definindo layout
            SetContentView(Resource.Layout.Tarefa);

            //Buscando os controles
            btnSelecionarData = FindViewById<Button>(Resource.Id.btnSelecionarData);
            editTarefaNomeCurto = FindViewById<EditText>(Resource.Id.editTarefaNome);
            editTarefaDescricao = FindViewById<EditText>(Resource.Id.editTarefaDescricao);
            editTarefaOnde = FindViewById<EditText>(Resource.Id.editTarefaOnde);
            editTarefaQuando = FindViewById<EditText>(Resource.Id.editTarefaQuando);
            editTarefaComo = FindViewById<EditText>(Resource.Id.editTarefaComo);
            spinnerArea = FindViewById<Spinner>(Resource.Id.spinnerAreas);
            chckTarefaConcluida = FindViewById<CheckBox>(Resource.Id.chckTarefaConcluida);
            btnSalvar = FindViewById<Button>(Resource.Id.btnTarefaSalvar);
            btnExcluir = FindViewById<Button>(Resource.Id.btnTarefaExcluir);

            spinnerArea.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.areas_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerArea.Adapter = adapter;

            //Preenchendo valores, caso vier de um clique numa tarefa, na lista da tela de Visao Geral
            int tarefaID = Intent.GetIntExtra("TarefaID", 0);
            if(tarefaID > 0)
            {
                tarefa = RodaDaVida.Current.dataBaseManager.GetTarefa(tarefaID);
                editTarefaNomeCurto.Text = tarefa.NomeCurto;
                editTarefaDescricao.Text = tarefa.Descricao;
                editTarefaOnde.Text = tarefa.Onde;
                editTarefaQuando.Text = tarefa.Quando.ToLongDateString();
                dataTarefa = tarefa.Quando;
                editTarefaComo.Text = tarefa.Como;
                UsuarioArea usuarioArea = RodaDaVida.Current.dataBaseManager.GetUsuarioArea(tarefa.UsuarioAreaID);
                spinnerArea.SetSelection(usuarioArea.CodigoArea - 1);
                chckTarefaConcluida.Visibility = ViewStates.Visible;
                btnExcluir.Visibility = ViewStates.Visible;
            }
            else
            {
                chckTarefaConcluida.Visibility = ViewStates.Invisible;
                btnExcluir.Visibility = ViewStates.Invisible;
            }

            //Selecionando data
            if (btnSelecionarData != null)
                btnSelecionarData.Click += DateSelect_OnClick;

            //Pegando clique em Salvar
            if(btnSalvar != null)
            {
                btnSalvar.Click += (sender, e) =>
                {
                    bool salvar = true;
                    if(editTarefaNomeCurto.Text.Equals(""))
                    {
                        Toast.MakeText(this, "O nome curto da tarefa deve ser preenchido!", ToastLength.Short).Show();
                        editTarefaNomeCurto.RequestFocus();
                        salvar = false;
                    }
                    else if (editTarefaDescricao.Text.Equals(""))
                    {
                        Toast.MakeText(this, "A descrição da tarefa deve ser preenchida!", ToastLength.Short).Show();
                        editTarefaDescricao.RequestFocus();
                        salvar = false;
                    }
                    else if (editTarefaOnde.Text.Equals(""))
                    {
                        Toast.MakeText(this, "O local da tarefa deve ser preenchido!", ToastLength.Short).Show();
                        editTarefaOnde.RequestFocus();
                        salvar = false;
                    }
                    else if (editTarefaQuando.Text.Equals(""))
                    {
                        Toast.MakeText(this, "A data da tarefa deve ser preenchida!", ToastLength.Short).Show();
                        editTarefaQuando.RequestFocus();
                        salvar = false;
                    }
                    else if (editTarefaComo.Text.Equals(""))
                    {
                        Toast.MakeText(this, "Como a tarefa vai ser realizada deve ser preenchido!", ToastLength.Short).Show();
                        editTarefaComo.RequestFocus();
                        salvar = false;
                    }

                    if (salvar)
                    {
                        string texto = "Tarefa salva com sucesso!";

                        UsuarioArea usuarioArea = RodaDaVida.Current.dataBaseManager.GetUsuarioAreaByCodigo(areaAtual.ID);
                        Area area = RodaDaVida.Current.dataBaseManager.GetArea(usuarioArea.AreaID);
                        tarefa.NomeCurto = editTarefaNomeCurto.Text;
                        tarefa.Descricao = editTarefaDescricao.Text;
                        tarefa.Onde = editTarefaOnde.Text;
                        tarefa.Quando = dataTarefa;
                        tarefa.Como = editTarefaComo.Text;
                        tarefa.UsuarioAreaID = usuarioArea.ID;
                        if (tarefa.ID > 0)
                            tarefa.Concluida = chckTarefaConcluida.Checked;
                        
                        if (tarefa.Concluida)
                        {
                            tarefa.PontosGanhos = Utils.Current.NotasPorTarefa;
                            string nota = Utils.Current.NotasPorTarefa.ToString();
                            nota = nota.Replace('.', ',');
                            if ((usuarioArea.DataUltTarefa == null) || (tarefa.Quando > usuarioArea.DataUltTarefa))
                                usuarioArea.DataUltTarefa = tarefa.Quando;
                            usuarioArea.Nota += tarefa.PontosGanhos;
                            if (usuarioArea.Nota > 10)
                                usuarioArea.Nota = 10;
                            RodaDaVida.Current.dataBaseManager.saveUsuarioArea(usuarioArea);
                            texto = "Parabéns por concluir a tarefa! Você ganhou " + nota + 
                                        " ponto na área: " + area.Descricao + ". Continue em frente!";
                        }
                        RodaDaVida.Current.dataBaseManager.saveTarefa(tarefa);
                        
                        Toast.MakeText(this, texto, ToastLength.Short).Show();

                        OnBackPressed();
                    }
                };
            }

            //Pegando clique em Excluir
            if(btnExcluir != null)
            {
                btnExcluir.Click += (sender, e) =>
                {
                    var builder = new AlertDialog.Builder(this);
                    builder.SetMessage("Tem certeza que deseja excluir a tarefa?");
                    builder.SetPositiveButton("Sim", (s, ev) => 
                        {
                            ExcluirTarefaAtual();
                            string texto = "Tarefa excluída com sucesso!";
                            Toast.MakeText(this, texto, ToastLength.Short).Show();

                            OnBackPressed();
                        });
                    builder.SetNegativeButton("Não", (s, ev) => { return; });
                    builder.Create().Show();
                };
            }

        }

        private void ExcluirTarefaAtual()
        {
            RodaDaVida.Current.dataBaseManager.deleteTarefa(tarefa.ID);
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            areaAtual = RodaDaVida.Current.dataBaseManager.GetArea(e.Position + 1);
        }

        void DateSelect_OnClick(object sender, EventArgs eventArgs)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                editTarefaQuando.Text = time.ToLongDateString();
                dataTarefa = time;
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }
    }

    public class DatePickerFragment : DialogFragment,
                                  DatePickerDialog.IOnDateSetListener
    {
        // TAG can be any string of your choice.
        public static readonly string TAG = "X:" + typeof(DatePickerFragment).Name.ToUpper();

        // Initialize this value to prevent NullReferenceExceptions.
        Action<DateTime> _dateSelectedHandler = delegate { };

        public static DatePickerFragment NewInstance(Action<DateTime> onDateSelected)
        {
            DatePickerFragment frag = new DatePickerFragment();
            frag._dateSelectedHandler = onDateSelected;
            return frag;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            DateTime currently = DateTime.Now;
            DatePickerDialog dialog = new DatePickerDialog(Activity,
                                                           this,
                                                           currently.Year,
                                                           currently.Month - 1,
                                                           currently.Day);
            return dialog;
        }

        public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            // Note: monthOfYear is a value between 0 and 11, not 1 and 12!
            DateTime selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);
            Log.Debug(TAG, selectedDate.ToLongDateString());
            _dateSelectedHandler(selectedDate);
        }
    }
}