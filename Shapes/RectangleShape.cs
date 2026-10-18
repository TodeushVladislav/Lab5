using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Lab5.Shapes
{
    public class RectangleShape : Shape
    {
        public override string Name => "Прямокутник";

        public bool HasFill { get; set; } = true;

        protected Rectangle GetBoundsFromCenter()
        {
            int rx = Math.Abs(this.x2 - this.x1);
            int ry = Math.Abs(this.y2 - this.y1);
            return new Rectangle(this.x1 - rx, this.y1 - ry, rx * 2, ry * 2);
        }

        public override void Draw(Graphics g)
        {
            Rectangle rect = GetBoundsFromCenter();
            using (Pen pen = new Pen(Color.Black, 1))
            {
                if (HasFill)
                {
                    using (Brush brush = new SolidBrush(Color.White))
                    {
                        g.FillRectangle(brush, rect);
                    }
                }
                g.DrawRectangle(pen, rect);
            }
        }

        public override void DrawRubber(Graphics g)
        {
            using (Pen pen = new Pen(Color.Black, 1) { DashStyle = DashStyle.Dot })
            {
                g.DrawRectangle(pen, GetBoundsFromCenter());
            }
        }
    }
}