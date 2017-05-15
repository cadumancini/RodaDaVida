using Android.App;
using Android.OS;

namespace RodaDaVidaAndroid.Telas
{
    [Activity(Label = "Cadastrar")]
    public class Cadastrar : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Cadastrar);
        }
    }
}