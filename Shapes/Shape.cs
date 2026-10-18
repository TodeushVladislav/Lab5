using System.Drawing;

namespace Lab5.Shapes
{
    public abstract class Shape
    {
        protected int x1, y1, x2, y2;
        public void Set (int x1, int y1, int x2, int y2)
        {
            this.x1= x1;
            this.y1= y1;
            this.x2 = x2;
            this.y2= y2;
        }
        public abstract void Draw(Graphics g);
        public abstract string Name { get; }
        public abstract void DrawRubber(Graphics g);
        public (int x1, int y1, int x2, int y2) GetCoords() => (this.x1, this.y1, this.x2, this.y2);
    }
}
