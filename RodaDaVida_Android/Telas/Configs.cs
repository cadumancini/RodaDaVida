using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using RodaDaVidaAndroid.Adapters;
using RodaDaVidaAndroid.Classes;
using RodaDaVidaShared.Tabelas;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Runtime;

namespace RodaDaVidaAndroid.Telas
{
    [Activity(Label = "Configs")]
    class Configs : AppCompatActivity
    {
        ConfigsListAdapter configsAdapter;
        IList<ConfigItem> configsItens;
        ListView configsList;
        int idUsuario;
        Usuario usuario;
        Android.Support.V7.App.AlertDialog.Builder dialogBuilder;
        Android.Support.V7.App.AlertDialog alertDialog;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
            Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            //Definindo layout
            SetContentView(Resource.Layout.Configs);

            //Acrescentando toolbar
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            //Toolbar will now take on default actionbar characteristics
            SetSupportActionBar(toolbar);

            SupportActionBar.Title = "Configurações";
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            configsList = FindViewById<ListView>(Resource.Id.ConfigsList);

            idUsuario = RodaDaVida.Current.idUsuarioGeral;
            usuario = RodaDaVida.Current.dataBaseManager.GetUsuario(idUsuario);

            configsItens = new List<ConfigItem>();
            configsItens.Add(new ConfigItem("alteraNome", "Alterar Nome do Usuário", "Nome Atual: " + usuario.Nome));
            configsItens.Add(new ConfigItem("reavaliar", "Fazer Reavaliação", "Toque para reavaliar as áreas da sua vida"));

            //Pegando clique em item da lista de configurações
            if(configsList != null)
            {
                configsList.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
                {
                    // Se clicar em alterar nome, abrir input dialog:
                    if(configsItens[e.Position].ID.Equals("alteraNome"))
                    {
                        LayoutInflater layoutInflater = LayoutInflater.From(this);
                        View view = layoutInflater.Inflate(Resource.Layout.input_trocarNomeUsu, null);
                        dialogBuilder = new Android.Support.V7.App.AlertDialog.Builder(this);
                        dialogBuilder.SetView(view);
                        var nomeUsuario = view.FindViewById<EditText>(Resource.Id.inputUsuario);
                        nomeUsuario.Text = RodaDaVida.Current.dataBaseManager.GetUsuario(RodaDaVida.Current.idUsuarioGeral).Nome;
                        nomeUsuario.RequestFocus();
                        //nomeUsuario.SetSelection(nomeUsuario.Text.Length);
                        nomeUsuario.SelectAll();

                        dialogBuilder.SetCancelable(true)
                        .SetPositiveButton("Alterar", delegate
                        {
                            alteraNomeUsuario(nomeUsuario.Text);
                        })
                        .SetNegativeButton("Cancelar", delegate { dialogBuilder.Dispose(); });

                        alertDialog = dialogBuilder.Create();
                        alertDialog.Show();
                    }
                };
            }
        }

        public void alteraNomeUsuario(string texto)
        {
            Usuario usuario = RodaDaVida.Current.dataBaseManager.GetUsuario(RodaDaVida.Current.idUsuarioGeral);
            usuario.Nome = texto;
            RodaDaVida.Current.dataBaseManager.saveUsuario(usuario);
            configsItens[0].Descricao = "Nome Atual: " + texto;
            atualizaAdapter();
        }

        public void atualizaAdapter()
        {
            //Criando o Adapter
            configsAdapter = new ConfigsListAdapter(this, configsItens);

            //Atribuindo o Adapter para a ListVew
            configsList.Adapter = configsAdapter;
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
            atualizaAdapter();
        }

        public override void OnBackPressed()
        {
            if (alertDialog != null)
            {
                if (alertDialog.IsShowing)
                    alertDialog.Dispose();
                else
                    base.OnBackPressed();
            }
            else
                base.OnBackPressed();
        }
    }
}