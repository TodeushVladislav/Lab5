using System;
using System.IO;
using System.Windows.Forms;
using Lab5.Shapes;

namespace Lab5
{
    public partial class MainForm : Form
    {
        private readonly MyEditor _editor = MyEditor.GetInstance();
        private readonly TableForm _tableForm = new();
        private const string FilePath = "shapes.txt";

        public MainForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            InitMenu();
        }

        private void InitMenu()
        {
            var menuStrip = new MenuStrip();

            var objectsMenu = new ToolStripMenuItem("Об'єкти");
            objectsMenu.DropDownItems.Add("Крапка", null, (s, e) => _editor.Start(typeof(PointShape)));
            objectsMenu.DropDownItems.Add("Лінія", null, (s, e) => _editor.Start(typeof(LineShape)));
            objectsMenu.DropDownItems.Add("Прямокутник", null, (s, e) => _editor.Start(typeof(RectangleShape)));
            objectsMenu.DropDownItems.Add("Еліпс", null, (s, e) => _editor.Start(typeof(EllipseShape)));
            objectsMenu.DropDownItems.Add("Лінія з кружечками", null, (s, e) => _editor.Start(typeof(LineOOShape)));
            objectsMenu.DropDownItems.Add("Каркас куба", null, (s, e) => _editor.Start(typeof(CubeShape)));

            var tableMenu = new ToolStripMenuItem("Таблиця");
            
            tableMenu.DropDownItems.Add("Показати / Сховати", null, (s, e) =>
            {
                if (_tableForm.Visible) _tableForm.Hide();
                else _tableForm.Show();
            });

            menuStrip.Items.Add(objectsMenu);
            menuStrip.Items.Add(tableMenu);
            MainMenuStrip = menuStrip;
            Controls.Add(menuStrip);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                _editor.OnLBdown(e.X, e.Y);
                Invalidate();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            _editor.OnMouseMove(e.X, e.Y);
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                Shape? finished = _editor.OnLBup(e.X, e.Y);
                if (finished != null)
                {
                    var (x1, y1, x2, y2) = finished.GetCoords();

                    _tableForm.AddRow(finished.Name, x1, y1, x2, y2);

                    string line = $"{finished.Name}\t{x1}\t{y1}\t{x2}\t{y2}{Environment.NewLine}";
                    File.AppendAllText(FilePath, line);
                }
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            _editor.OnPaint(e.Graphics);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _tableForm.Dispose();
            base.OnFormClosing(e);
        }
    }
}
