using System;
using System.Collections.Generic;
using System.Drawing;
using Lab5.Shapes;

namespace Lab5
{
    public class MyEditor
    {
        private static MyEditor? _instance;
        private MyEditor() { }

        public static MyEditor GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MyEditor();
            }
            return _instance;
        }

        private readonly List<Shape> _shapes = new();
        private Type? _currentShapeType;
        private Shape? _tempShape;
        private bool _isDrawing = false;
        private int _startX, _startY;

        public void Start(Type shapeType)
        {
            _currentShapeType = shapeType;
        }

        public void OnLBdown(int x, int y)
        {
            if (_currentShapeType == null) return;

            _isDrawing = true;
            _startX = x;
            _startY = y;
            _tempShape = (Shape?)Activator.CreateInstance(_currentShapeType);
            _tempShape?.Set(x, y, x, y);
        }

        public void OnMouseMove(int x, int y)
        {
            if (!_isDrawing || _tempShape == null) return;
            _tempShape.Set(_startX, _startY, x, y);
        }

        public Shape? OnLBup(int x, int y)
        {
            if (!_isDrawing || _tempShape == null) return null;

            _isDrawing = false;
            _tempShape.Set(_startX, _startY, x, y);
            _shapes.Add(_tempShape);

            Shape finishedShape = _tempShape;
            _tempShape = null;
            return finishedShape;
        }

        public void OnPaint(Graphics g)
        {
            foreach (var shape in _shapes)
            {
                shape.Draw(g);
            }

            if (_isDrawing && _tempShape != null)
            {
                _tempShape.DrawRubber(g);
            }
        }
    }
}
