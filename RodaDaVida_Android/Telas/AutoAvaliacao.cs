using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using RodaDaVidaShared.Tabelas;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using RodaDaVidaShared.Utils;

namespace RodaDaVidaAndroid.Telas
{
    [Activity(Label = "AutoAvaliacao")]
    public class AutoAvaliacao : Activity, View.IOnTouchListener
    {
        NumberPicker picker;
        TextView pergunta;
        IList<UsuarioArea> areasADefinir;
        private InputMethodManager imm;
        int idAtual = 0, totalAreas;
        Button btnSalvarNota;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AutoAvaliacao);

            pergunta = FindViewById<TextView>(Resource.Id.txtPergunta);
            btnSalvarNota = FindViewById<Button>(Resource.Id.btnSalvarNota);
            btnSalvarNota.SetOnTouchListener(this);
            picker = FindViewById<NumberPicker>(Resource.Id.picker);
            picker.MinValue = 1;
            picker.MaxValue = 10;

            imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
            imm.HideSoftInputFromWindow(picker.WindowToken, 0);

            areasADefinir = RodaDaVida.Current.dataBaseManager.GetUsuariosAreasADefinir();
            totalAreas = areasADefinir.Count;

            Area area = RodaDaVida.Current.dataBaseManager.GetArea(areasADefinir[idAtual].AreaID);
            pergunta.Text = Utils.Current.GetMensagem(area);

        }

        public bool OnTouch(View v, MotionEvent e)
        {
            if(e.Action == MotionEventActions.Up)
            {
                areasADefinir[idAtual].Nota = picker.Value;
                RodaDaVida.Current.dataBaseManager.saveUsuarioArea(areasADefinir[idAtual]);
                idAtual++;
                if(idAtual < totalAreas)
                {
                    Area area = RodaDaVida.Current.dataBaseManager.GetArea(areasADefinir[idAtual].AreaID);
                    pergunta.Text = Utils.Current.GetMensagem(area);
                    picker.Value = 1;
                }
                else
                {
                    pergunta.Text = "Tudo pronto. Vamos começar!";
                    picker.Visibility = ViewStates.Invisible;
                    btnSalvarNota.Visibility = ViewStates.Invisible;

                    LoadActivity(2000);
                }
            }
            return true;
        }

        public async void LoadActivity(int time)
        {
            //Esperando por <time> milisegundos
            await Task.Delay(time);
            //Iniciando tela
            var telaVisaoGeral = new Intent(this, typeof(VisaoGeral)).SetFlags(ActivityFlags.ReorderToFront);
            StartActivity(telaVisaoGeral);
            Finish();
        }
    }
}