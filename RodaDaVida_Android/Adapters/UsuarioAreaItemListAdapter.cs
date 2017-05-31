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
        IList<UsuarioArea> notas = new List<UsuarioArea>;

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
            throw new NotImplementedException();
        }
    }
}