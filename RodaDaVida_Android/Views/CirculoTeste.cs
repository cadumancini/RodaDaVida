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
        Paint paint, paintAreas;
        IList<UsuarioArea> notas;
        PointF[] pontos;

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
            paint.TextSize = 10;
            paint.TextAlign = Align.Center;

            paintAreas = new Paint();
            paintAreas.SetARGB(255, 0, 0, 0);
            paintAreas.SetStyle(Paint.Style.Stroke);
            paintAreas.StrokeWidth = 1;
            paintAreas.TextSize = 12;
            paintAreas.TextAlign = Align.Center;

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

            //Desenhando retas:
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

            //Desenhando numeros:
            paint.StrokeWidth = 1;
            canvas.DrawText("1", startX, startY - 35, paint);
            canvas.DrawText("2", startX, startY - 55, paint);
            canvas.DrawText("3", startX, startY - 75, paint);
            canvas.DrawText("4", startX, startY - 95, paint);
            canvas.DrawText("5", startX, startY - 115, paint);
            canvas.DrawText("6", startX, startY - 135, paint);
            canvas.DrawText("7", startX, startY - 155, paint);
            canvas.DrawText("8", startX, startY - 175, paint);
            canvas.DrawText("9", startX, startY - 195, paint);
            canvas.DrawText("10", startX, startY - 215, paint);
            canvas.DrawText("Familiar", startX, startY - 235, paintAreas);

            canvas.DrawText("1", startX, startY + 45, paint);
            canvas.DrawText("2", startX, startY + 65, paint);
            canvas.DrawText("3", startX, startY + 85, paint);
            canvas.DrawText("4", startX, startY + 105, paint);
            canvas.DrawText("5", startX, startY + 125, paint);
            canvas.DrawText("6", startX, startY + 145, paint);
            canvas.DrawText("7", startX, startY + 165, paint);
            canvas.DrawText("8", startX, startY + 185, paint);
            canvas.DrawText("9", startX, startY + 205, paint);
            canvas.DrawText("10", startX, startY + 225, paint);
            canvas.DrawText("Educação", startX, startY + 245, paintAreas);
            
            canvas.DrawText("1", startX - 40, startY, paint);
            canvas.DrawText("2", startX - 60, startY, paint);
            canvas.DrawText("3", startX - 80, startY, paint);
            canvas.DrawText("4", startX - 100, startY, paint);
            canvas.DrawText("5", startX - 120, startY, paint);
            canvas.DrawText("6", startX - 140, startY, paint);
            canvas.DrawText("7", startX - 160, startY, paint);
            canvas.DrawText("8", startX - 180, startY, paint);
            canvas.DrawText("9", startX - 200, startY, paint);
            canvas.DrawText("10", startX - 220, startY, paint);
            canvas.DrawText("Comunidade", startX - 270, startY, paintAreas);

            canvas.DrawText("1", startX + 40, startY, paint);
            canvas.DrawText("2", startX + 60, startY, paint);
            canvas.DrawText("3", startX + 80, startY, paint);
            canvas.DrawText("4", startX + 100, startY, paint);
            canvas.DrawText("5", startX + 120, startY, paint);
            canvas.DrawText("6", startX + 140, startY, paint);
            canvas.DrawText("7", startX + 160, startY, paint);
            canvas.DrawText("8", startX + 180, startY, paint);
            canvas.DrawText("9", startX + 200, startY, paint);
            canvas.DrawText("10", startX + 220, startY, paint);
            canvas.DrawText("Física", startX + 250, startY, paintAreas);

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
            canvas.DrawPath(path, paintNotas);
        }
    }
}