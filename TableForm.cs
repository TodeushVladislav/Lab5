using System.Windows.Forms;

namespace Lab5
{
    public partial class TableForm : Form
    {
        public TableForm()
        {
            InitializeComponent();
            SetupGrid();
        }

        private void SetupGrid()
        {
            dgvTable.Columns.Clear();
            dgvTable.Columns.Add("Name", "Назва");
            dgvTable.Columns.Add("X1", "x1");
            dgvTable.Columns.Add("Y1", "y1");
            dgvTable.Columns.Add("X2", "x2");
            dgvTable.Columns.Add("Y2", "y2");
            dgvTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTable.ReadOnly = true;
            dgvTable.AllowUserToAddRows = false;
        }

        public void AddRow(string name, int x1, int y1, int x2, int y2)
        {
            dgvTable.Rows.Add(name, x1, y1, x2, y2);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
            else
            {
                base.OnFormClosing(e);
            }
        }
    }
}
