using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.Runtime;
using Android.Util;
using Android.Views;
using RodaDaVidaShared.Tabelas;
using System;
using System.Collections.Generic;
using static Android.Graphics.Paint;

namespace RodaDaVidaAndroid.Views
{
    [Register("rodadavidaandroid.views.CirculoTeste")]
    public class CirculoTeste : View
    {
        private ShapeDrawable _shape, _shape2, _shape3, _shape4, _shape5, _shape6,
            _shape7, _shape8, _shape9, _shape10;
        Paint paint, paintAreas, paintNumeros;
        IList<UsuarioArea> notas;
        PointF[] pontos;
        DisplayMetrics displayMetrics;

        public CirculoTeste(Context context) : base(context)
        {
            displayMetrics = Resources.DisplayMetrics;
            DefineShapes();
        }
        
        public CirculoTeste(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            displayMetrics = Resources.DisplayMetrics;
            DefineShapes();
        }

        public CirculoTeste(Context context, IAttributeSet attrs, int defStyle) :
        base(context, attrs, defStyle)
        {
            displayMetrics = Resources.DisplayMetrics;
            DefineShapes();
        }

        public void DefineShapes()
        {
            var startCircleTop = (int)(displayMetrics.WidthPixels * 0.10);
            var startCircleLeft = (int)(displayMetrics.WidthPixels * 0.10);
            var endCircleBottom = displayMetrics.WidthPixels - startCircleTop;
            var endCircleRight = displayMetrics.WidthPixels - startCircleLeft;

            paint = new Paint();
            paint.SetARGB(255, 0, 0, 0);
            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeWidth = 2;
            paint.TextSize = 4;
            paint.TextAlign = Align.Center;

            paintNumeros = new Paint();
            paintNumeros.SetARGB(255, 0, 0, 0);
            paintNumeros.SetStyle(Paint.Style.Fill);
            paintNumeros.StrokeWidth = 3;
            paintNumeros.TextSize = 18;
            paintNumeros.FakeBoldText = true;
            paintNumeros.TextAlign = Align.Center;

            paintAreas = new Paint();
            paintAreas.SetARGB(255, 0, 0, 0);
            paintAreas.SetStyle(Paint.Style.Fill);
            paintAreas.StrokeWidth = 3;
            paintAreas.TextSize = 20;
            paintAreas.FakeBoldText = true;
            paintAreas.TextAlign = Align.Center;

            _shape = new ShapeDrawable(new OvalShape());
            _shape.Paint.Set(paint);
            _shape.SetBounds(startCircleLeft, startCircleTop, endCircleRight, endCircleBottom);
            
            _shape2 = new ShapeDrawable(new OvalShape());
            _shape2.Paint.Set(paint);
            _shape2.SetBounds((startCircleLeft + ((endCircleRight - startCircleLeft) / 22 * 1)), 
                (startCircleTop + ((endCircleBottom - startCircleTop) / 22 * 1)), 
                (endCircleRight - ((endCircleRight - startCircleLeft) / 22 * 1)), 
                (endCircleBottom - ((endCircleBottom - startCircleTop) / 22 * 1)));

            _shape3 = new ShapeDrawable(new OvalShape());
            _shape3.Paint.Set(paint);
            _shape3.SetBounds((startCircleLeft + ((endCircleRight - startCircleLeft) / 22 * 2)),
                (startCircleTop + ((endCircleBottom - startCircleTop) / 22 * 2)),
                (endCircleRight - ((endCircleRight - startCircleLeft) / 22 * 2)),
                (endCircleBottom - ((endCircleBottom - startCircleTop) / 22 * 2)));

            _shape4 = new ShapeDrawable(new OvalShape());
            _shape4.Paint.Set(paint);
            _shape4.SetBounds((startCircleLeft + ((endCircleRight - startCircleLeft) / 22 * 3)),
                (startCircleTop + ((endCircleBottom - startCircleTop) / 22 * 3)),
                (endCircleRight - ((endCircleRight - startCircleLeft) / 22 * 3)),
                (endCircleBottom - ((endCircleBottom - startCircleTop) / 22 * 3)));

            _shape5 = new ShapeDrawable(new OvalShape());
            _shape5.Paint.Set(paint);
            _shape5.SetBounds((startCircleLeft + ((endCircleRight - startCircleLeft) / 22 * 4)),
                (startCircleTop + ((endCircleBottom - startCircleTop) / 22 * 4)),
                (endCircleRight - ((endCircleRight - startCircleLeft) / 22 * 4)),
                (endCircleBottom - ((endCircleBottom - startCircleTop) / 22 * 4)));

            _shape6 = new ShapeDrawable(new OvalShape());
            _shape6.Paint.Set(paint);
            _shape6.SetBounds((startCircleLeft + ((endCircleRight - startCircleLeft) / 22 * 5)),
                (startCircleTop + ((endCircleBottom - startCircleTop) / 22 * 5)),
                (endCircleRight - ((endCircleRight - startCircleLeft) / 22 * 5)),
                (endCircleBottom - ((endCircleBottom - startCircleTop) / 22 * 5)));

            _shape7 = new ShapeDrawable(new OvalShape());
            _shape7.Paint.Set(paint);
            _shape7.SetBounds((startCircleLeft + ((endCircleRight - startCircleLeft) / 22 * 6)),
                (startCircleTop + ((endCircleBottom - startCircleTop) / 22 * 6)),
                (endCircleRight - ((endCircleRight - startCircleLeft) / 22 * 6)),
                (endCircleBottom - ((endCircleBottom - startCircleTop) / 22 * 6)));

            _shape8 = new ShapeDrawable(new OvalShape());
            _shape8.Paint.Set(paint);
            _shape8.SetBounds((startCircleLeft + ((endCircleRight - startCircleLeft) / 22 * 7)),
                (startCircleTop + ((endCircleBottom - startCircleTop) / 22 * 7)),
                (endCircleRight - ((endCircleRight - startCircleLeft) / 22 * 7)),
                (endCircleBottom - ((endCircleBottom - startCircleTop) / 22 * 7)));

            _shape9 = new ShapeDrawable(new OvalShape());
            _shape9.Paint.Set(paint);
            _shape9.SetBounds((startCircleLeft + ((endCircleRight - startCircleLeft) / 22 * 8)),
                (startCircleTop + ((endCircleBottom - startCircleTop) / 22 * 8)),
                (endCircleRight - ((endCircleRight - startCircleLeft) / 22 * 8)),
                (endCircleBottom - ((endCircleBottom - startCircleTop) / 22 * 8)));

            _shape10 = new ShapeDrawable(new OvalShape());
            _shape10.Paint.Set(paint);
            _shape10.SetBounds((startCircleLeft + ((endCircleRight - startCircleLeft) / 22 * 9)),
                (startCircleTop + ((endCircleBottom - startCircleTop) / 22 * 9)),
                (endCircleRight - ((endCircleRight - startCircleLeft) / 22 * 9)),
                (endCircleBottom - ((endCircleBottom - startCircleTop) / 22 * 9)));
        }

        public override void Draw(Canvas canvas)
        {
            //Desenhando circulos:
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

            var startCircleTop = (int)(displayMetrics.WidthPixels * 0.10);
            var startCircleLeft = (int)(displayMetrics.WidthPixels * 0.10);
            var endCircleBottom = displayMetrics.WidthPixels - startCircleTop;
            var endCircleRight = displayMetrics.WidthPixels - startCircleLeft;

            //Desenhando retas:
            float startX = startCircleLeft + ((endCircleRight - startCircleLeft) / 2), 
                startY = startCircleTop + ((endCircleBottom - startCircleTop) / 2), 
                length = (endCircleRight - startCircleLeft) / 2;

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
            
            
            //Desenhando numeros:
            canvas.DrawText("1", startX, startY - ((length / 10) + 10), paintNumeros);
            canvas.DrawText("2", startX, startY - ((length / 10) + 35), paintNumeros);
            canvas.DrawText("3", startX, startY - ((length / 10) + 60), paintNumeros);
            canvas.DrawText("4", startX, startY - ((length / 10) + 85), paintNumeros); 
            canvas.DrawText("5", startX, startY - ((length / 10) + 110), paintNumeros);
            canvas.DrawText("6", startX, startY - ((length / 10) + 135), paintNumeros);
            canvas.DrawText("7", startX, startY - ((length / 10) + 160), paintNumeros);
            canvas.DrawText("8", startX, startY - ((length / 10) + 185), paintNumeros);
            canvas.DrawText("9", startX, startY - ((length / 10) + 215), paintNumeros);
            canvas.DrawText("10", startX, startY - ((length / 10) + 240), paintNumeros);
            canvas.DrawText("Familiar", startX, startY - ((length / 10) + 270), paintAreas);
              
            canvas.DrawText("1", startX, startY + ((length / 10) + 20), paintNumeros);
            canvas.DrawText("2", startX, startY + ((length / 10) + 45), paintNumeros);
            canvas.DrawText("3", startX, startY + ((length / 10) + 70), paintNumeros);
            canvas.DrawText("4", startX, startY + ((length / 10) + 95), paintNumeros); 
            canvas.DrawText("5", startX, startY + ((length / 10) + 120), paintNumeros);
            canvas.DrawText("6", startX, startY + ((length / 10) + 145), paintNumeros);
            canvas.DrawText("7", startX, startY + ((length / 10) + 175), paintNumeros);
            canvas.DrawText("8", startX, startY + ((length / 10) + 200), paintNumeros);
            canvas.DrawText("9", startX, startY + ((length / 10) + 225), paintNumeros);
            canvas.DrawText("10", startX, startY + ((length / 10) + 250), paintNumeros);
            canvas.DrawText("Educação", startX, startY + ((length / 10) + 280), paintAreas);
            
            canvas.DrawText("1", startX - 45, startY + 4, paintNumeros);
            canvas.DrawText("2", startX - 70, startY + 4, paintNumeros);
            canvas.DrawText("3", startX - 95, startY + 4, paintNumeros);
            canvas.DrawText("4", startX - 120, startY + 4, paintNumeros);
            canvas.DrawText("5", startX - 145, startY + 4, paintNumeros);
            canvas.DrawText("6", startX - 170, startY + 4, paintNumeros);
            canvas.DrawText("7", startX - 200, startY + 4, paintNumeros);
            canvas.DrawText("8", startX - 225, startY + 4, paintNumeros);
            canvas.DrawText("9", startX - 250, startY + 4, paintNumeros);
            canvas.DrawText("10", startX - 275, startY + 4, paintNumeros);
            canvas.Save();
            canvas.Rotate(-90, startX - 295, startY + 4);
            canvas.DrawText("Comunidade", startX - 295, startY + 4, paintAreas);
            canvas.Restore();

            canvas.DrawText("1", startX + 45, startY + 4, paintNumeros);
            canvas.DrawText("2", startX + 70, startY + 4, paintNumeros);
            canvas.DrawText("3", startX + 95, startY + 4, paintNumeros);
            canvas.DrawText("4", startX + 120, startY + 4, paintNumeros);
            canvas.DrawText("5", startX + 145, startY + 4, paintNumeros);
            canvas.DrawText("6", startX + 170, startY + 4, paintNumeros);
            canvas.DrawText("7", startX + 200, startY + 4, paintNumeros);
            canvas.DrawText("8", startX + 225, startY + 4, paintNumeros);
            canvas.DrawText("9", startX + 250, startY + 4, paintNumeros);
            canvas.DrawText("10", startX + 275, startY + 4, paintNumeros);
            canvas.Save();
            canvas.Rotate(90, startX + 295, startY + 4);
            canvas.DrawText("Física", startX + 290, startY + 4, paintAreas);
            canvas.Restore();
            /*
            angleRadians = (Math.PI / 180.0) * 32;
            canvas.DrawText("1", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 40)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 40)), paint);
            canvas.DrawText("2", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 60)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 60)), paint);
            canvas.DrawText("3", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 80)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 80)), paint);
            canvas.DrawText("4", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 100)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 100)), paint);
            canvas.DrawText("5", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 120)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 120)), paint);
            canvas.DrawText("6", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 140)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 140)), paint);
            canvas.DrawText("7", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 160)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 160)), paint);
            canvas.DrawText("8", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 180)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 180)), paint);
            canvas.DrawText("9", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 200)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 200)), paint);
            canvas.DrawText("10", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 220)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 220)), paint);
            canvas.DrawText("Financeira", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 270)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 260)), paintAreas);

            angleRadians = (Math.PI / 180.0) * 62;
            canvas.DrawText("1", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 40)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 40)), paint);
            canvas.DrawText("2", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 60)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 60)), paint);
            canvas.DrawText("3", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 80)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 80)), paint);
            canvas.DrawText("4", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 100)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 100)), paint);
            canvas.DrawText("5", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 120)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 120)), paint);
            canvas.DrawText("6", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 140)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 140)), paint);
            canvas.DrawText("7", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 160)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 160)), paint);
            canvas.DrawText("8", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 180)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 180)), paint);
            canvas.DrawText("9", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 200)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 200)), paint);
            canvas.DrawText("10", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 220)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 220)), paint);
            canvas.DrawText("Econômica", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 280)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 250)), paintAreas);

            angleRadians = (Math.PI / 180.0) * 122;
            canvas.DrawText("1", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 40)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 40)), paint);
            canvas.DrawText("2", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 60)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 60)), paint);
            canvas.DrawText("3", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 80)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 80)), paint);
            canvas.DrawText("4", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 100)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 100)), paint);
            canvas.DrawText("5", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 120)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 120)), paint);
            canvas.DrawText("6", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 140)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 140)), paint);
            canvas.DrawText("7", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 160)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 160)), paint);
            canvas.DrawText("8", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 180)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 180)), paint);
            canvas.DrawText("9", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 200)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 200)), paint);
            canvas.DrawText("10", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 220)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 220)), paint);
            canvas.DrawText("Social", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 280)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 250)), paintAreas);

            angleRadians = (Math.PI / 180.0) * 152;
            canvas.DrawText("1", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 40)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 40)), paint);
            canvas.DrawText("2", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 60)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 60)), paint);
            canvas.DrawText("3", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 80)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 80)), paint);
            canvas.DrawText("4", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 100)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 100)), paint);
            canvas.DrawText("5", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 120)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 120)), paint);
            canvas.DrawText("6", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 140)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 140)), paint);
            canvas.DrawText("7", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 160)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 160)), paint);
            canvas.DrawText("8", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 180)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 180)), paint);
            canvas.DrawText("9", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 200)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 200)), paint);
            canvas.DrawText("10", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 220)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 220)), paint);
            canvas.DrawText("Espiritual", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 260)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 240)), paint);

            angleRadians = (Math.PI / 180.0) * 212;
            canvas.DrawText("1", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 40)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 40)), paint);
            canvas.DrawText("2", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 60)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 60)), paint);
            canvas.DrawText("3", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 80)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 80)), paint);
            canvas.DrawText("4", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 100)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 100)), paint);
            canvas.DrawText("5", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 120)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 120)), paint);
            canvas.DrawText("6", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 140)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 140)), paint);
            canvas.DrawText("7", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 160)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 160)), paint);
            canvas.DrawText("8", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 180)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 180)), paint);
            canvas.DrawText("9", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 200)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 200)), paint);
            canvas.DrawText("10", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 220)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 220)), paint);
            canvas.DrawText("Ecológica", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 260)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 250)), paint);

            angleRadians = (Math.PI / 180.0) * 242;
            canvas.DrawText("1", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 40)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 40)), paint);
            canvas.DrawText("2", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 60)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 60)), paint);
            canvas.DrawText("3", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 80)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 80)), paint);
            canvas.DrawText("4", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 100)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 100)), paint);
            canvas.DrawText("5", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 120)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 120)), paint);
            canvas.DrawText("6", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 140)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 140)), paint);
            canvas.DrawText("7", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 160)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 160)), paint);
            canvas.DrawText("8", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 180)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 180)), paint);
            canvas.DrawText("9", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 200)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 200)), paint);
            canvas.DrawText("10", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 220)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 220)), paint);
            canvas.DrawText("Lazer", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 240)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 240)), paint);

            angleRadians = (Math.PI / 180.0) * 302;
            canvas.DrawText("1", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 40)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 40)), paint);
            canvas.DrawText("2", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 60)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 60)), paint);
            canvas.DrawText("3", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 80)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 80)), paint);
            canvas.DrawText("4", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 100)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 100)), paint);
            canvas.DrawText("5", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 120)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 120)), paint);
            canvas.DrawText("6", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 140)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 140)), paint);
            canvas.DrawText("7", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 160)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 160)), paint);
            canvas.DrawText("8", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 180)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 180)), paint);
            canvas.DrawText("9", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 200)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 200)), paint);
            canvas.DrawText("10", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 220)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 220)), paint);
            canvas.DrawText("Profissional", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 260)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 240)), paint);

            angleRadians = (Math.PI / 180.0) * 332;
            canvas.DrawText("1", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 40)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 40)), paint);
            canvas.DrawText("2", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 60)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 60)), paint);
            canvas.DrawText("3", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 80)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 80)), paint);
            canvas.DrawText("4", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 100)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 100)), paint);
            canvas.DrawText("5", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 120)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 120)), paint);
            canvas.DrawText("6", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 140)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 140)), paint);
            canvas.DrawText("7", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 160)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 160)), paint);
            canvas.DrawText("8", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 180)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 180)), paint);
            canvas.DrawText("9", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 200)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 200)), paint);
            canvas.DrawText("10", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 220)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 220)), paint);
            canvas.DrawText("Saúde", Convert.ToSingle(startX + (Math.Cos(angleRadians) * 250)), Convert.ToSingle(startY + (Math.Sin(angleRadians) * 250)), paint);
            
            //Desenhando pontos das notas:
            notas = RodaDaVida.Current.dataBaseManager.GetUsuariosAreas("CODIGO");
            pontos = new PointF[12];
            int index = 0;
            foreach(UsuarioArea uArea in notas)
            {
                double nota = uArea.Nota;
                double distancia = 50 + ((nota - 1) * 20);
                int angulo = 0;
                switch(index)
                {
                    case 0:
                        angulo = 270;
                        break;
                    case 1:
                        angulo = 300;
                        break;
                    case 2:
                        angulo = 330;
                        break;
                    case 3:
                        angulo = 0;
                        break;
                    case 4:
                        angulo = 30;
                        break;
                    case 5:
                        angulo = 60;
                        break;
                    case 6:
                        angulo = 90;
                        break;
                    case 7:
                        angulo = 120;
                        break;
                    case 8:
                        angulo = 150;
                        break;
                    case 9:
                        angulo = 180;
                        break;
                    case 10:
                        angulo = 210;
                        break;
                    default:
                        angulo = 240;
                        break;
                }
                angleRadians = (Math.PI / 180.0) * angulo;
                pontos[index] = new PointF(Convert.ToSingle((startX + (Math.Cos(angleRadians) * distancia))),
                    Convert.ToSingle(startY + (Math.Sin(angleRadians) * distancia)));
                index++;
            }

            var path = new Path();
            // Set the first point, that the drawing will start from.
            path.MoveTo(pontos[0].X, pontos[0].Y);
            for (var i = 1; i < pontos.Length; i++)
            {
                // Draw a line from the previous point in the path to the new point.
                path.LineTo(pontos[i].X, pontos[i].Y);
            }
            var paintNotas = new Paint
            {
                Color = Color.Aqua,
                Alpha = 120
            };
            // We can use Paint.Style.Stroke if we want to draw a "hollow" polygon,
            // But then we had better set the .StrokeWidth property on the paint.
            paintNotas.SetStyle(Paint.Style.Fill);
            canvas.DrawPath(path, paintNotas);*/
        }
    }
}