namespace boattags
{
    public class GuiMapBoatIcon : IconUtil
    {
        // <<<<<<< HEAD
        ICoreClientAPI capi;

        // =======
        // >>>>>>> d9d08193ffe23cd940d75171a78acc3598bff667
        public GuiMapBoatIcon(ICoreClientAPI capi) : base(capi)
        {
        }

        public static void DrawMapBoat(Context cr, int x, int y, float width, float height, double[] rgba)
        {
            Pattern pattern = null;
            Matrix matrix = cr.Matrix;

            cr.Save();
            float w = 26;
            float h = 39;
            float scale = Math.Min(width / w, height / h);
            matrix.Translate(x + Math.Max(0, (width - w * scale) / 2), y + Math.Max(0, (height - h * scale) / 2));
            matrix.Scale(scale, scale);
            cr.Matrix = matrix;

            // Boat hull fill
            cr.Operator = Operator.Over;
            pattern = new SolidPattern(rgba[0], rgba[1], rgba[2], rgba[3]);
            cr.SetSource(pattern);

            cr.NewPath();
            cr.MoveTo(13, 2);      // Bow (front)
            cr.CurveTo(18, 10, 22, 20, 20, 30); // Right side curve
            cr.CurveTo(13, 37, 6, 37, 6, 30);   // Stern (back)
            cr.CurveTo(4, 20, 8, 10, 13, 2);    // Left side curve back to front
            cr.ClosePath();

            cr.FillPreserve();
            if (pattern != null) pattern.Dispose();

            // Outline stroke
            cr.Operator = Operator.Over;
            cr.LineWidth = 2.5;
            cr.MiterLimit = 10;
            cr.LineJoin = LineJoin.Round;
            cr.LineCap = LineCap.Round;

            pattern = new SolidPattern(rgba[0], rgba[1], rgba[2], rgba[3]);
            cr.SetSource(pattern);
            cr.StrokePreserve();

            if (pattern != null) pattern.Dispose();

            pattern = new SolidPattern(rgba[0], rgba[1], rgba[2], rgba[3]);
            cr.SetSource(pattern);
            cr.NewPath();
            cr.MoveTo(9, 25);
            cr.LineTo(17, 25);
            cr.Stroke();

            if (pattern != null) pattern.Dispose();

            cr.Restore();
        }

    }
}
