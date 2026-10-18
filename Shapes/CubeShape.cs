using System;
using System.Drawing;

namespace Lab5.Shapes
{
    public class CubeShape : Shape
    {
        public override string Name => "Каркас куба";

        private readonly RectangleShape _frontRect = new RectangleShape { HasFill = false }; 
        private readonly RectangleShape _backRect = new RectangleShape { HasFill = false };

        private readonly LineShape[] _edges = new LineShape[4] 
        {
            new LineShape(),
            new LineShape(),
            new LineShape(),
            new LineShape()
        };

        private void UpdateParts()
        {
            int minX = Math.Min(this.x1, this.x2);
            int maxX = Math.Max(this.x1, this.x2);
            int minY = Math.Min(this.y1, this.y2);
            int maxY = Math.Max(this.y1, this.y2);

            int w = maxX - minX;
            int h = maxY - minY;

            int dx = w / 3;
            int dy = h / 3;

            int faceW = w - dx;
            int faceH = h - dy;

            int rx = faceW / 2;
            int ry = faceH / 2;

            int bLeft = minX + dx;
            int bTop = minY;
            int bRight = minX + w;
            int bBottom = minY + faceH;

            _backRect.Set(bLeft + rx, bTop + ry, bRight, bBottom);

            int fLeft = minX;
            int fTop = minY + dy;
            int fRight = minX + faceW;
            int fBottom = minY + h;

            _frontRect.Set(fLeft + rx, fTop + ry, fRight, fBottom);

            _edges[0].Set(fLeft, fTop, bLeft, bTop);               
            _edges[1].Set(fRight, fTop, bRight, bTop);              
            _edges[2].Set(fLeft, fBottom, bLeft, bBottom);          
            _edges[3].Set(fRight, fBottom, bRight, bBottom);        
        }

        public override void Draw(Graphics g)
        {
            UpdateParts();

            _backRect.Draw(g);
            _frontRect.Draw(g);

            foreach (var edge in _edges)
            {
                edge.Draw(g);
            }
        }

        public override void DrawRubber(Graphics g)
        {
            UpdateParts();

            _backRect.DrawRubber(g);
            _frontRect.DrawRubber(g);

            foreach (var edge in _edges)
            {
                edge.DrawRubber(g);
            }
        }
    }
}




