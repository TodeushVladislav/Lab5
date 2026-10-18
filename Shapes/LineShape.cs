using System.Drawing;
using System.Drawing.Drawing2D;

namespace Lab5.Shapes
{
    public class LineShape : Shape
    {
       public override string Name => "Лінія";

       public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(Color.Black, 1))
            {
                g.DrawLine(pen, this.x1, this.y1, this.x2, this.y2);
            }
        }

        public override void DrawRubber(Graphics g)
        {
            using (Pen pen = new Pen(Color.Black, 1) { DashStyle = DashStyle.Dot })
            {
                g.DrawLine(pen, this.x1, this.y1, this.x2, this.y2);
            }
        }
    }
}
