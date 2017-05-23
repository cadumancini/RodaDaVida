using Android.App;
using Android.Content;
using Android.OS;
using Android.Views.InputMethods;
using Android.Widget;
using RodaDaVidaShared.Tabelas;
using System.Collections.Generic;

namespace RodaDaVidaAndroid.Telas
{
    [Activity(Label = "AutoAvaliacao")]
    public class AutoAvaliacao : Activity
    {
        NumberPicker picker;
        TextView pergunta;
        IList<UsuarioArea> areasDefinidas;
        List<int> areasDefinir;
        private InputMethodManager imm;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            areasDefinir = new List<int>();
            SetContentView(Resource.Layout.AutoAvaliacao);

            pergunta = FindViewById<TextView>(Resource.Id.txtPergunta);
            picker = FindViewById<NumberPicker>(Resource.Id.picker);
            picker.MinValue = 1;
            picker.MaxValue = 10;

            imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
            imm.HideSoftInputFromWindow(picker.WindowToken, 0);

            areasDefinidas = RodaDaVida.Current.dataBaseManager.GetUsuariosAreas();
            if (areasDefinidas.Count == 0)
            {
                pergunta.Text = "Defina a sua nota para a área Familiar:";
            }
            else
            {
                for(int i = 1; i <= 12; i++)
                {
                    areasDefinidas = RodaDaVida.Current.dataBaseManager.GetUsuariosAreasByCodigo(i);
                    if (areasDefinidas.Count == 0)
                        areasDefinir.Add(i);
                }

                areasDefinir.Sort();
            }
        }

    }
}