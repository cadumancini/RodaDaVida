using System.Collections.Generic;

using Android.App;
using Android.Views;
using Android.Widget;
using RodaDaVidaShared.Tabelas;

namespace RodaDaVidaAndroid.Adapters
{
    class ProxTarefasItemListAdapter : BaseAdapter<Tarefa>
    {
        Activity context = null;
        IList<Tarefa> tarefas = new List<Tarefa>();

        public ProxTarefasItemListAdapter(Activity context, IList<Tarefa> tarefas) : base()
        {
            this.context = context;
            this.tarefas = tarefas;
        }

        public override Tarefa this[int position]
        {
            get { return tarefas[position]; }
        }

        public override int Count
        {
            get { return tarefas.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            // Get our object for position
            var item = tarefas[position];
            var view = convertView;
            UsuarioArea usuarioArea = RodaDaVida.Current.dataBaseManager.GetUsuarioArea(item.UsuarioAreaID);
            Area area = RodaDaVida.Current.dataBaseManager.GetArea(usuarioArea.AreaID);

            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.ProximasTarefasListItem, null);

            var txtArea = view.FindViewById<TextView>(Resource.Id.ProxTarNomeArea);
            var txtNomeCurto = view.FindViewById<TextView>(Resource.Id.ProxTarNomeCurto);
            var txtQuando = view.FindViewById<TextView>(Resource.Id.ProxTarQuando);
            txtArea.Text = area.Descricao;
            txtNomeCurto.Text = item.NomeCurto;
            txtQuando.Text = item.Quando.ToLongDateString();

            //Finally return the view
            return view;
        }
    }
}