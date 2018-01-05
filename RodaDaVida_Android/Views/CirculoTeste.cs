using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.Runtime;
using Android.Util;
using Android.Views;
using System;

namespace RodaDaVidaAndroid.Views
{
    [Register("rodadavidaandroid.views.CirculoTeste")]
    public class CirculoTeste : View
    {
        private ShapeDrawable _shape, _shape2, _shape3, _shape4, _shape5, _shape6,
            _shape7, _shape8, _shape9, _shape10;
        Paint paint;
        public CirculoTeste(Context context) : base(context)
        {
            DefineShapes();
        }
        
        public CirculoTeste(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            DefineShapes();
        }

        public CirculoTeste(Context context, IAttributeSet attrs, int defStyle) :
        base(context, attrs, defStyle)
        {
            DefineShapes();
        }

        public void DefineShapes()
        {
            paint = new Paint();
            paint.SetARGB(255, 0, 0, 0);
            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeWidth = 2;

            _shape = new ShapeDrawable(new OvalShape());
            _shape.Paint.Set(paint);
            _shape.SetBounds(80, 80, 540, 540);

            _shape2 = new ShapeDrawable(new OvalShape());
            _shape2.Paint.Set(paint);
            _shape2.SetBounds(100, 100, 520, 520);

            _shape3 = new ShapeDrawable(new OvalShape());
            _shape3.Paint.Set(paint);
            _shape3.SetBounds(120, 120, 500, 500);

            _shape4 = new ShapeDrawable(new OvalShape());
            _shape4.Paint.Set(paint);
            _shape4.SetBounds(140, 140, 480, 480);

            _shape5 = new ShapeDrawable(new OvalShape());
            _shape5.Paint.Set(paint);
            _shape5.SetBounds(160, 160, 460, 460);

            _shape6 = new ShapeDrawable(new OvalShape());
            _shape6.Paint.Set(paint);
            _shape6.SetBounds(180, 180, 440, 440);

            _shape7 = new ShapeDrawable(new OvalShape());
            _shape7.Paint.Set(paint);
            _shape7.SetBounds(200, 200, 420, 420);

            _shape8 = new ShapeDrawable(new OvalShape());
            _shape8.Paint.Set(paint);
            _shape8.SetBounds(220, 220, 400, 400);

            _shape9 = new ShapeDrawable(new OvalShape());
            _shape9.Paint.Set(paint);
            _shape9.SetBounds(240, 240, 380, 380);

            _shape10 = new ShapeDrawable(new OvalShape());
            _shape10.Paint.Set(paint);
            _shape10.SetBounds(260, 260, 360, 360);
        }

        public override void Draw(Canvas canvas)
        {
            _shape.Draw(canvas);
            _shape2.Draw(canvas);
            _shape3.Draw(canvas);
            _shape4.Draw(canvas);
            _shape5.Draw(canvas);
            _shape6.Draw(canvas);
            _shape7.Draw(canvas);
            _shape8.Draw(canvas);
            _shape9.Draw(canvas);
            _shape10.Draw(canvas);

            float startX = 310, startY = 310, length = 230;

            double angleRadians = (Math.PI / 180.0) * 255;
            canvas.DrawLine(startX, startY, 
                Convert.ToSingle((startX + (Math.Cos(angleRadians) * length))), 
                Convert.ToSingle(startY + (Math.Sin(angleRadians) * length)), paint);

            angleRadians = (Math.PI / 180.0) * 285;
            canvas.DrawLine(startX, startY,
                Convert.ToSingle((startX + (Math.Cos(angleRadians) * length))),
                Convert.ToSingle(startY + (Math.Sin(angleRadians) * length)), paint);

            angleRadians = (Math.PI / 180.0) * 315;
            canvas.DrawLine(startX, startY,
                Convert.ToSingle((startX + (Math.Cos(angleRadians) * length))),
                Convert.ToSingle(startY + (Math.Sin(angleRadians) * length)), paint);

            angleRadians = (Math.PI / 180.0) * 345;
            canvas.DrawLine(startX, startY,
                Convert.ToSingle((startX + (Math.Cos(angleRadians) * length))),
                Convert.ToSingle(startY + (Math.Sin(angleRadians) * length)), paint);

            angleRadians = (Math.PI / 180.0) * 15;
            canvas.DrawLine(startX, startY,
                Convert.ToSingle((startX + (Math.Cos(angleRadians) * length))),
                Convert.ToSingle(startY + (Math.Sin(angleRadians) * length)), paint);

            angleRadians = (Math.PI / 180.0) * 45;
            canvas.DrawLine(startX, startY,
                Convert.ToSingle((startX + (Math.Cos(angleRadians) * length))),
                Convert.ToSingle(startY + (Math.Sin(angleRadians) * length)), paint);

            angleRadians = (Math.PI / 180.0) * 75;
            canvas.DrawLine(startX, startY,
                Convert.ToSingle((startX + (Math.Cos(angleRadians) * length))),
                Convert.ToSingle(startY + (Math.Sin(angleRadians) * length)), paint);

            angleRadians = (Math.PI / 180.0) * 105;
            canvas.DrawLine(startX, startY,
                Convert.ToSingle((startX + (Math.Cos(angleRadians) * length))),
                Convert.ToSingle(startY + (Math.Sin(angleRadians) * length)), paint);

            angleRadians = (Math.PI / 180.0) * 135;
            canvas.DrawLine(startX, startY,
                Convert.ToSingle((startX + (Math.Cos(angleRadians) * length))),
                Convert.ToSingle(startY + (Math.Sin(angleRadians) * length)), paint);

            angleRadians = (Math.PI / 180.0) * 165;
            canvas.DrawLine(startX, startY,
                Convert.ToSingle((startX + (Math.Cos(angleRadians) * length))),
                Convert.ToSingle(startY + (Math.Sin(angleRadians) * length)), paint);

            angleRadians = (Math.PI / 180.0) * 195;
            canvas.DrawLine(startX, startY,
                Convert.ToSingle((startX + (Math.Cos(angleRadians) * length))),
                Convert.ToSingle(startY + (Math.Sin(angleRadians) * length)), paint);

            angleRadians = (Math.PI / 180.0) * 225;
            canvas.DrawLine(startX, startY,
                Convert.ToSingle((startX + (Math.Cos(angleRadians) * length))),
                Convert.ToSingle(startY + (Math.Sin(angleRadians) * length)), paint);
        }
    }
}