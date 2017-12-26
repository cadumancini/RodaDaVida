using System.Collections.Generic;

using Android.App;
using Android.Views;
using Android.Widget;
using RodaDaVidaShared.Tabelas;

namespace RodaDaVidaAndroid.Adapters
{
    class TodasTarefasItemListAdapter : BaseAdapter<Tarefa>
    {
        Activity context = null;
        IList<Tarefa> tarefas = new List<Tarefa>();

        public TodasTarefasItemListAdapter(Activity context, IList<Tarefa> tarefas) : base()
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
                view = context.LayoutInflater.Inflate(Resource.Layout.TodasTarefasListItem, null);

            var txtNomeCurto = view.FindViewById<TextView>(Resource.Id.TodTarNomeCurto);
            var txtNomeArea = view.FindViewById<TextView>(Resource.Id.TodTarNomeArea);
            var txtQuando = view.FindViewById<TextView>(Resource.Id.TodTarQuando);
            var txtOnde = view.FindViewById<TextView>(Resource.Id.TodTarOnde);
            var txtComo = view.FindViewById<TextView>(Resource.Id.TodTarComo);
            var txtConcluida = view.FindViewById<TextView>(Resource.Id.TodTarConcluida);

            txtNomeCurto.Text = item.NomeCurto;
            txtNomeArea.Text = area.Descricao;
            txtQuando.Text = item.Quando.ToLongDateString();
            txtOnde.Text = item.Onde;
            txtComo.Text = item.Como;
            if (item.Concluida)
                txtConcluida.Text = "Concluída";
            else
                txtConcluida.Text = "Não concluída";

            //Finally return the view
            return view;
        }
    }
}