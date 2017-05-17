using Android.App;
using Android.Content;
using Android.OS;
using Android.Views.InputMethods;
using Android.Widget;
using RodaDaVidaShared.Tabelas;
using System.Collections.Generic;

namespace RodaDaVidaAndroid.Telas
{
    [Activity(Label = "RodaDaVidaAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button btnCadastrar;
        EditText editNome;
        private InputMethodManager imm;
        IList<Usuario> usuarios;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView (Resource.Layout.Main);

            //Buscando controles:
            editNome = FindViewById<EditText>(Resource.Id.editNome);
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
                    Usuario usuario = new Usuario();
                    usuario.Nome = editNome.Text;
                    RodaDaVida.Current.dataBaseManager.saveUsuario(usuario);
                    StartActivity(typeof(Cadastrar));
                };
            }

            imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
        }

        private void MainActivity_Click(object sender, System.EventArgs e)
        {
            imm.HideSoftInputFromWindow(btnCadastrar.WindowToken, 0);
        }

        protected override void OnResume()
        {
            base.OnResume();

            usuarios = RodaDaVida.Current.dataBaseManager.GetUsuarios();

            if(usuarios.Count == 0)
            {
                Toast.MakeText(this, "Nenhum usuário cadastrado.", ToastLength.Long).Show();
            }
            else
            {
                string texto = "Quantidade de usuários: " + usuarios.Count.ToString();
                Toast.MakeText(this, texto, ToastLength.Long).Show();
            }
        }
    }
}

