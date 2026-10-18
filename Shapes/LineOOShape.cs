using System.Drawing;

namespace Lab5.Shapes
{
    public class LineOOShape : Shape
    {
        public override string Name => "Лінія з кружечками";

        private readonly LineShape _line = new LineShape();
        private readonly EllipseShape _circle1 = new EllipseShape { HasFill = true };
        private readonly EllipseShape _circle2 = new EllipseShape { HasFill = true };

        private void UpdateParts()
        {
            const int r = 8;

            _line.Set(this.x1, this.y1, this.x2, this.y2);

            _circle1.Set(this.x1 - r, this.y1 - r, this.x1 + r, this.y1 + r);
            _circle2.Set(this.x2 - r, this.y2 - r, this.x2 + r, this.y2 + r);
        }

        public override void Draw(Graphics g)
        {
            UpdateParts();
            _line.Draw(g);
            _circle1.Draw(g);
            _circle2.Draw(g);
        }

        public override void DrawRubber(Graphics g)
        {
            UpdateParts();
            _line.DrawRubber(g);
            _circle1.DrawRubber(g);
            _circle2.DrawRubber(g);
        }
    }
}
