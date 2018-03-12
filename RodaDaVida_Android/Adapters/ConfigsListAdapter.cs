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
using RodaDaVidaAndroid.Classes;

namespace RodaDaVidaAndroid.Adapters
{
    class ConfigsListAdapter : BaseAdapter<ConfigItem>
    {
        Activity context = null;
        IList<ConfigItem> configs = new List<ConfigItem>();

        public ConfigsListAdapter(Activity context, IList<ConfigItem> configs) : base()
        {
            this.context = context;
            this.configs = configs;
        }

        public override ConfigItem this[int position]
        {
            get { return configs[position]; }
        }

        public override int Count
        {
            get { return configs.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            // Get our object for position
            var item = configs[position];
            var view = convertView;

            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.ConfigsListItem, null);

            var txtCabecalho = view.FindViewById<TextView>(Resource.Id.ConfigCabecalho);
            var txtDescricao = view.FindViewById<TextView>(Resource.Id.ConfigDescri);

            txtCabecalho.Text = item.Cabecalho;
            txtDescricao.Text = item.Descricao;

            //Finally return the view
            return view;
        }
    }
}