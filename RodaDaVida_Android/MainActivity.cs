using Android.App;
using Android.Content;
using Android.OS;
using Android.Views.InputMethods;
using Android.Widget;
using RodaDaVidaAndroid.Telas;

namespace RodaDaVidaAndroid
{
    [Activity(Label = "RodaDaVidaAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button btnCadastrar;
        private InputMethodManager imm;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView (Resource.Layout.Main);

            //Buscando controles:
            btnCadastrar = FindViewById<Button>(Resource.Id.btnCadastrar);
            var root = FindViewById<LinearLayout>(Resource.Id.rootLayout);

            //Dando foco para o Layout
            root.RequestFocus();

            //Pegando clique do botão:
            if (btnCadastrar != null)
            {
                btnCadastrar.Click += MainActivity_Click;
                btnCadastrar.Click += (sender, e) =>
                {
                    StartActivity(typeof(Cadastrar));
                };
            }

            imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
        }

        private async void MainActivity_Click(object sender, System.EventArgs e)
        {
            imm.HideSoftInputFromWindow(btnCadastrar.WindowToken, 0);
        }
    }
}

