using Nesne_Prog_Proje.Formlar2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nesne_Prog_Proje.Formlar
{
    public partial class FrmMetraj : Form
    {
        public FrmMetraj()
        {
            InitializeComponent();
        }

        Formlar2.FrmDoluKare frmKare1;
        private void button1_Click_1(object sender, EventArgs e)
        {
            //if (frmKare1 == null || frmKare1.IsDisposed)
            //{
                frmKare1 = new Formlar2.FrmDoluKare();   
                frmKare1.MdiParent = this;
                frmKare1.FormBorderStyle = FormBorderStyle.None;
                frmKare1.Show();
            //}
        }

        

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }
      
        private void FrmMetraj_Load(object sender, EventArgs e)
        {

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Formlar2.FrmDoluDaire frmdaire;
        private void button2_Click(object sender, EventArgs e)
        {
            
            //if (frmdaire == null || frmdaire.IsDisposed)
            //{
                frmdaire = new Formlar2.FrmDoluDaire();
                frmdaire.MdiParent = this;
                frmdaire.FormBorderStyle = FormBorderStyle.None;
                frmdaire.Show();
            //}
        }
        Formlar2.FrmBosKare frmboskare;
        private void button5_Click(object sender, EventArgs e)
        {
            frmboskare = new Formlar2.FrmBosKare();
            frmboskare.MdiParent = this;
            frmboskare.FormBorderStyle = FormBorderStyle.None;
            frmboskare.Show();
        }
        Formlar2.FrmBosDaire frmbosdaire;
        private void button6_Click(object sender, EventArgs e)
        {
            frmbosdaire = new Formlar2.FrmBosDaire();
            frmbosdaire.MdiParent = this;
            frmbosdaire.FormBorderStyle = FormBorderStyle.None;
            frmbosdaire.Show();
        }

        Formlar2.FrmU frmU;
        private void button4_Click(object sender, EventArgs e)
        {
            frmU = new Formlar2.FrmU();
            frmU.MdiParent = this;
            frmU.FormBorderStyle = FormBorderStyle.None;
            frmU.Show();
        }

        Formlar2.FrmL frmL;
        private void button3_Click(object sender, EventArgs e)
        {
            frmL = new Formlar2.FrmL();
            frmL.MdiParent = this;
            frmL.FormBorderStyle = FormBorderStyle.None;
            frmL.Show();
        }
        Formlar2.FrmI frmI;
        private void button7_Click(object sender, EventArgs e)
        {

            frmI = new Formlar2.FrmI();
            frmI.MdiParent = this;
            frmI.FormBorderStyle = FormBorderStyle.None;
            frmI.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
