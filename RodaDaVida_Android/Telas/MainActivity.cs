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

            usuarios = RodaDaVida.Current.dataBaseManager.GetUsuarios();

            if (usuarios.Count == 0)
            {
                SetContentView(Resource.Layout.Main);

                //Buscando controles:
                editNome = FindViewById<EditText>(Resource.Id.editNome);
                btnCadastrar = FindViewById<Button>(Resource.Id.btnCadastrar);
                var root = FindViewById<LinearLayout>(Resource.Id.rootLayout);

                //Dando foco para o Layout
                root.RequestFocus();

                imm = (InputMethodManager)GetSystemService(Context.InputMethodService);

                //Pegando clique do botão:
                if (btnCadastrar != null)
                {
                    btnCadastrar.Click += (sender, e) =>
                    {
                        imm.HideSoftInputFromWindow(btnCadastrar.WindowToken, 0);

                        //Gravando usuário
                        Usuario usuario = new Usuario();
                        usuario.Nome = editNome.Text;
                        RodaDaVida.Current.idUsuarioGeral = RodaDaVida.Current.dataBaseManager.saveUsuario(usuario);

                        //Gravando áreas
                        Area familiar = new Area();
                        Area profissional = new Area();
                        Area saude = new Area();
                        Area fisica = new Area();
                        Area financeira = new Area();
                        Area economica = new Area();
                        Area educacao = new Area();
                        Area social = new Area();
                        Area espiritual = new Area();
                        Area comunidade = new Area();
                        Area ecologica = new Area();
                        Area lazer = new Area();

                        familiar.Codigo = 1;
                        familiar.Descricao = "Familiar";
                        profissional.Codigo = 2;
                        profissional.Descricao = "Profissional";
                        saude.Codigo = 3;
                        saude.Descricao = "Saúde";
                        fisica.Codigo = 4;
                        fisica.Descricao = "Física";
                        financeira.Codigo = 5;
                        financeira.Descricao = "Financeira";
                        economica.Codigo = 6;
                        economica.Descricao = "Econômica";
                        educacao.Codigo = 7;
                        educacao.Descricao = "Educação";
                        social.Codigo = 8;
                        social.Descricao = "Social";
                        espiritual.Codigo = 9;
                        espiritual.Descricao = "Espiritual";
                        comunidade.Codigo = 10;
                        comunidade.Descricao = "Comunidade";
                        ecologica.Codigo = 11;
                        ecologica.Descricao = "Ecológica";
                        lazer.Codigo = 12;
                        lazer.Descricao = "Lazer";

                        RodaDaVida.Current.dataBaseManager.saveArea(familiar);
                        RodaDaVida.Current.dataBaseManager.saveArea(profissional);
                        RodaDaVida.Current.dataBaseManager.saveArea(saude);
                        RodaDaVida.Current.dataBaseManager.saveArea(fisica);
                        RodaDaVida.Current.dataBaseManager.saveArea(financeira);
                        RodaDaVida.Current.dataBaseManager.saveArea(economica);
                        RodaDaVida.Current.dataBaseManager.saveArea(educacao);
                        RodaDaVida.Current.dataBaseManager.saveArea(social);
                        RodaDaVida.Current.dataBaseManager.saveArea(espiritual);
                        RodaDaVida.Current.dataBaseManager.saveArea(comunidade);
                        RodaDaVida.Current.dataBaseManager.saveArea(ecologica);
                        RodaDaVida.Current.dataBaseManager.saveArea(lazer);

                        //Iniciando tela
                        var telaBemVindo = new Intent(this, typeof(BemVindo)).SetFlags(ActivityFlags.ReorderToFront);
                        telaBemVindo.PutExtra("NomeUsuario", usuario.Nome);
                        telaBemVindo.PutExtra("NovoUsuario", true);
                        StartActivity(telaBemVindo);
                        Finish();
                    };
                }
            }
            else
            {
                Usuario usuario = usuarios[0];
                RodaDaVida.Current.idUsuarioGeral = usuario.ID;
                var telaBemVindo = new Intent(this, typeof(BemVindo)).SetFlags(ActivityFlags.ReorderToFront);
                telaBemVindo.PutExtra("NomeUsuario", usuario.Nome);
                telaBemVindo.PutExtra("NovoUsuario", false);
                StartActivity(telaBemVindo);
                Finish();
            }
        }
    }
}

