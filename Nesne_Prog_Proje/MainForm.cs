using Nesne_Prog_Proje.Formlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nesne_Prog_Proje
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private ToolStripMenuItem windowsBtn = new ToolStripMenuItem();
        private GraphicsForm graphics;
        private int counter = 1;
        private void newBtn_Click(object sender, EventArgs e)
        {
            windowsBtn.Name = "windowsBtn";
            windowsBtn.Text = "Windows";
            windowsBtn.Size = new Size(120, 28);

            var item = mainmenu.Items.IndexOf(windowsBtn);
            if(item == -1)
            {
                mainmenu.Items.Add(windowsBtn);
                mainmenu.MdiWindowListItem = windowsBtn;
            }

            graphics = new GraphicsForm();
            graphics.Name = string.Concat("Graphics", counter.ToString());
            graphics.Text = graphics.Name;
            graphics.MdiParent = this;
            graphics.Show();
            graphics.WindowState = FormWindowState.Maximized;

            counter++;

        }
    }
}
