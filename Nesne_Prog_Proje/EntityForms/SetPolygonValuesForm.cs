using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nesne_Prog_Proje.EntityForms
{
    public partial class SetPolygonValuesForm : Form
    {
        public SetPolygonValuesForm()
        {
            InitializeComponent();
        }
        public int SidesQty {  get; private set; }
        public int Inscribed {  get; private set; }
        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(sides.Text) || (Convert.ToInt32(sides.Text) < 3)){
                MessageBox.Show("Bir çokgenin boyutu en az 3 olmalıdır","Uyarı !",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sides.Focus();
                return;
            }

            SidesQty= Convert.ToInt32(sides.Text);
            Inscribed = inscibed.SelectedIndex;
            this.DialogResult = DialogResult.OK;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SetPolygonValuesForm_Load(object sender, EventArgs e)
        {
            Text = "Polygon Ayarları";
            inscibed.SelectedIndex = 0;
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - Width - 20;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height - Height - 20;
        }
    }
}
