using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RodaDaVidaAndroid.Telas
{
    [Activity(Label = "NovaTarefa")]
    public class NovaTarefa : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Definindo layout
            SetContentView(Resource.Layout.Tarefa);
        }
    }
}