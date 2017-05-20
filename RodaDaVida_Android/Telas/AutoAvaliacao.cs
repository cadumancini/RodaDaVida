using Android.App;
using Android.OS;

namespace RodaDaVidaAndroid.Telas
{
    [Activity(Label = "AutoAvaliacao")]
    public class AutoAvaliacao : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AutoAvaliacao);

        }
        
    }
}