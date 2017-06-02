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
using RodaDaVidaShared.Tabelas;

namespace RodaDaVidaAndroid.Adapters
{
    class UsuarioAreaItemListAdapter : BaseAdapter<UsuarioArea>
    {
        Activity context = null;
        IList<UsuarioArea> notas = new List<UsuarioArea>();

        public UsuarioAreaItemListAdapter(Activity context, IList<UsuarioArea> notas) : base()
        {
            this.context = context;
            this.notas = notas;
        }

        public override UsuarioArea this[int position]
        {
            get { return notas[position]; }
        }

        public override int Count
        {
            get { return notas.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            // Get our object for position
            var item = notas[position];

            // TODO: use this code to populate the row, and remove the above view
            /*
            var view = (convertView ??
                context.LayoutInflater.Inflate(
                    Android.Resource.Layout.SimpleListItemChecked,
                    parent,
                    false)) as CheckedTextView;*/
            var view = convertView;
            Area area = RodaDaVida.Current.dataBaseManager.GetArea(item.AreaID);

            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.UsuarioAreaListItem, null);
                var txtArea = view.FindViewById<TextView>(Resource.Id.NomeArea);
                var txtNota = view.FindViewById<TextView>(Resource.Id.NotaArea);
                txtArea.Text = area.Descricao;
                txtNota.Text = item.Nota.ToString();
            }
            else
            {
                var txtArea = view.FindViewById<TextView>(Resource.Id.NomeArea);
                var txtNota = view.FindViewById<TextView>(Resource.Id.NotaArea);
                txtArea.Text = area.Descricao;
                txtNota.Text = item.Nota.ToString();
            }

            //Finally return the view
            return view;
        }
    }
}