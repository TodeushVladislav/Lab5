using System.Drawing;

namespace Lab5.Shapes
{
    public class PointShape : Shape
    {
        public override string Name => "Крапка";
        public override void Draw(Graphics g)
        {
            using (Brush brush = new SolidBrush(Color.Black))
            {
                g.FillEllipse(brush, this.x1 - 2, this.y1 - 2, 4, 4);
            }
        }

        public override void DrawRubber(Graphics g) => Draw(g);
    }
}
