using Android.App;
using Android.Content;
using Android.OS;
using Android.Views.InputMethods;
using Android.Widget;
using RodaDaVidaShared.Tabelas;
using System;
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
            this.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
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
                        RodaDaVida.Current.dataBaseManager.saveUsuario(usuario);
                        RodaDaVida.Current.idUsuarioGeral = usuario.ID;

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

                        UsuarioArea areaFamiliar = new UsuarioArea();
                        UsuarioArea areaProfissional = new UsuarioArea();
                        UsuarioArea areaSaude = new UsuarioArea();
                        UsuarioArea areaFisica = new UsuarioArea();
                        UsuarioArea areaFinanceira = new UsuarioArea();
                        UsuarioArea areaEconomica = new UsuarioArea();
                        UsuarioArea areaEducacao = new UsuarioArea();
                        UsuarioArea areaSocial = new UsuarioArea();
                        UsuarioArea areaEspiritual = new UsuarioArea();
                        UsuarioArea areaComunidade = new UsuarioArea();
                        UsuarioArea areaEcologica = new UsuarioArea();
                        UsuarioArea areaLazer = new UsuarioArea();

                        areaFamiliar.AreaID = familiar.ID;
                        areaFamiliar.UsuarioID = usuario.ID;
                        areaFamiliar.Nota = 0;
                        areaFamiliar.DataUltReducao = DateTime.Now;

                        areaProfissional.AreaID = profissional.ID;
                        areaProfissional.UsuarioID = usuario.ID;
                        areaProfissional.Nota = 0;
                        areaProfissional.DataUltReducao = DateTime.Now;

                        areaSaude.AreaID = saude.ID;
                        areaSaude.UsuarioID = usuario.ID;
                        areaSaude.Nota = 0;
                        areaSaude.DataUltReducao = DateTime.Now;

                        areaFisica.AreaID = fisica.ID;
                        areaFisica.UsuarioID = usuario.ID;
                        areaFisica.Nota = 0;
                        areaFisica.DataUltReducao = DateTime.Now;

                        areaFinanceira.AreaID = financeira.ID;
                        areaFinanceira.UsuarioID = usuario.ID;
                        areaFinanceira.Nota = 0;
                        areaFinanceira.DataUltReducao = DateTime.Now;

                        areaEconomica.AreaID = economica.ID;
                        areaEconomica.UsuarioID = usuario.ID;
                        areaEconomica.Nota = 0;
                        areaEconomica.DataUltReducao = DateTime.Now;

                        areaEducacao.AreaID = educacao.ID;
                        areaEducacao.UsuarioID = usuario.ID;
                        areaEducacao.Nota = 0;
                        areaEducacao.DataUltReducao = DateTime.Now;

                        areaSocial.AreaID = social.ID;
                        areaSocial.UsuarioID = usuario.ID;
                        areaSocial.Nota = 0;
                        areaSocial.DataUltReducao = DateTime.Now;

                        areaEspiritual.AreaID = espiritual.ID;
                        areaEspiritual.UsuarioID = usuario.ID;
                        areaEspiritual.Nota = 0;
                        areaEspiritual.DataUltReducao = DateTime.Now;

                        areaComunidade.AreaID = comunidade.ID;
                        areaComunidade.UsuarioID = usuario.ID;
                        areaComunidade.Nota = 0;
                        areaComunidade.DataUltReducao = DateTime.Now;

                        areaEcologica.AreaID = ecologica.ID;
                        areaEcologica.UsuarioID = usuario.ID;
                        areaEcologica.Nota = 0;
                        areaEcologica.DataUltReducao = DateTime.Now;

                        areaLazer.AreaID = lazer.ID;
                        areaLazer.UsuarioID = usuario.ID;
                        areaLazer.Nota = 0;
                        areaLazer.DataUltReducao = DateTime.Now;

                        RodaDaVida.Current.dataBaseManager.saveUsuarioArea(areaFamiliar);
                        RodaDaVida.Current.dataBaseManager.saveUsuarioArea(areaProfissional);
                        RodaDaVida.Current.dataBaseManager.saveUsuarioArea(areaSaude);
                        RodaDaVida.Current.dataBaseManager.saveUsuarioArea(areaFisica);
                        RodaDaVida.Current.dataBaseManager.saveUsuarioArea(areaFinanceira);
                        RodaDaVida.Current.dataBaseManager.saveUsuarioArea(areaEconomica);
                        RodaDaVida.Current.dataBaseManager.saveUsuarioArea(areaEducacao);
                        RodaDaVida.Current.dataBaseManager.saveUsuarioArea(areaSocial);
                        RodaDaVida.Current.dataBaseManager.saveUsuarioArea(areaEspiritual);
                        RodaDaVida.Current.dataBaseManager.saveUsuarioArea(areaComunidade);
                        RodaDaVida.Current.dataBaseManager.saveUsuarioArea(areaEcologica);
                        RodaDaVida.Current.dataBaseManager.saveUsuarioArea(areaLazer);

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

