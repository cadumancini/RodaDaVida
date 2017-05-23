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
        IList<UsuarioArea> areasADefinir;
        private InputMethodManager imm;
        int idAtual = 0, totalAreas;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AutoAvaliacao);

            pergunta = FindViewById<TextView>(Resource.Id.txtPergunta);
            picker = FindViewById<NumberPicker>(Resource.Id.picker);
            picker.MinValue = 1;
            picker.MaxValue = 10;

            imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
            imm.HideSoftInputFromWindow(picker.WindowToken, 0);

            areasADefinir = RodaDaVida.Current.dataBaseManager.GetUsuariosAreasADefinir();
            totalAreas = areasADefinir.Count;

            Area area = RodaDaVida.Current.dataBaseManager.GetArea(areasADefinir[idAtual].AreaID);
            pergunta.Text = "Defina a sua nota para a área " + area.Descricao + ":";
        }

    }
}