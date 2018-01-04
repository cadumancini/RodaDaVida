using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.Runtime;
using Android.Util;
using Android.Views;

namespace RodaDaVidaAndroid.Views
{
    [Register("rodadavidaandroid.views.CirculoTeste")]
    public class CirculoTeste : View
    {
        private readonly ShapeDrawable _shape;
        public CirculoTeste(Context context) : base(context)
        {
            var paint = new Paint();
            paint.SetARGB(255, 200, 255, 0);
            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeWidth = 4;

            _shape = new ShapeDrawable(new OvalShape());
            _shape.Paint.Set(paint);

            _shape.SetBounds(20, 20, 300, 200);
        }

        public CirculoTeste(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            var paint = new Paint();
            paint.SetARGB(255, 200, 255, 0);
            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeWidth = 4;

            _shape = new ShapeDrawable(new OvalShape());
            _shape.Paint.Set(paint);

            _shape.SetBounds(20, 20, 300, 200);
        }

        public CirculoTeste(Context context, IAttributeSet attrs, int defStyle) :
        base(context, attrs, defStyle)
        {
            var paint = new Paint();
            paint.SetARGB(255, 200, 255, 0);
            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeWidth = 4;

            _shape = new ShapeDrawable(new OvalShape());
            _shape.Paint.Set(paint);

            _shape.SetBounds(20, 20, 300, 200);
        }

        public override void Draw(Canvas canvas)
        {
            _shape.Draw(canvas);
        }
    }
}