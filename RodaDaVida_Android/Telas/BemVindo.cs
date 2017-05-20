using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using RodaDaVidaShared.Tabelas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RodaDaVidaAndroid.Telas
{
    [Activity(Label = "Cadastrar")]
    public class BemVindo : Activity, View.IOnTouchListener
    {
        TextView txtBemVindo;
        bool detectarToque = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.BemVindo);

            //Buscando controles:
            txtBemVindo = FindViewById<TextView>(Resource.Id.txtBemVindo);

            string nomeUsuario = "";
            bool novoUsuario;
            nomeUsuario = Intent.GetStringExtra("NomeUsuario");
            novoUsuario = Intent.GetBooleanExtra("NovoUsuario", false);
            if (txtBemVindo != null && !nomeUsuario.Equals(""))
                txtBemVindo.Text = "Bem vindo(a), " + nomeUsuario + ".";

            if (txtBemVindo != null)
            {
                if (novoUsuario)
                    txtBemVindo.Text += " \nAgora você vai fazer a sua auto avaliação. \nPressione a tela para continuar.";
                else
                {
                    IList<UsuarioArea> usuariosAreas = RodaDaVida.Current.dataBaseManager.GetUsuariosAreas();
                    if (usuariosAreas.Count == 0)
                    {
                        txtBemVindo.Text += " \nVocê precisa fazer a sua auto avaliação. \nPressione a tela para continuar.";
                        detectarToque = true;
                    }
                    else if (usuariosAreas.Count < 12)
                    {
                        txtBemVindo.Text += " \nVocê precisa terminar a sua auto avaliação. \nPressione a tela para continuar.";
                        detectarToque = true;
                    }
                    else
                    {
                        LoadActivity(2000);
                    }
                }
            }
        }

        public async void LoadActivity(int time)
        {
            //Esperando por <time> milisegundos
            await Task.Delay(time);
            //Iniciando tela
            var telaAutoAvaliacao = new Intent(this, typeof(AutoAvaliacao)).SetFlags(ActivityFlags.ReorderToFront);
            StartActivity(telaAutoAvaliacao);
            Finish();
        }

        public bool OnTouch(View v, MotionEvent e)
        {
            if (detectarToque && e.Action == MotionEventActions.Down)
            {
                var telaAutoAvaliacao = new Intent(this, typeof(AutoAvaliacao)).SetFlags(ActivityFlags.ReorderToFront);
                StartActivity(telaAutoAvaliacao);
                Finish();
            }

            return true;
        }
    }
}