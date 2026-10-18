using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Lab5.Shapes
{
    public class EllipseShape : Shape
    {
        public override string Name => "Еліпс";

        public bool HasFill { get; set; } = false;

        protected Rectangle GetBounds()
        {
            int x = Math.Min(this.x1, this.x2);
            int y = Math.Min(this.y1, this.y2);
            int width = Math.Abs(this.x2 - this.x1);
            int height = Math.Abs(this.y2 - this.y1);
            return new Rectangle(x, y, width, height);
        }

        public override void Draw(Graphics g)
        {
            Rectangle rect = GetBounds();

            if (HasFill)
            {
                using (Brush brush = new SolidBrush(Color.White))
                {
                    g.FillEllipse(brush, rect);
                }
            }

            using (Pen pen = new Pen(Color.Black, 1))
            {
                g.DrawEllipse(pen, rect);
            }
        }

        public override void DrawRubber(Graphics g)
        {
            Rectangle rect = GetBounds();

            if (HasFill)
            {
                using (Brush brush = new SolidBrush(Color.White))
                {
                    g.FillEllipse(brush, rect);
                }
            }

            using (Pen pen = new Pen(Color.Black, 1) { DashStyle = DashStyle.Dot })
            {
                g.DrawEllipse(pen, rect);
            }
        }
    }
}


