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
    [Activity(Label = "Visao_Geral")]
    class VisaoGeral : Activity, View.IOnTouchListener
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }

        public bool OnTouch(View v, MotionEvent e)
        {
            throw new NotImplementedException();
        }
    }
}