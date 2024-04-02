using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Nesne_Prog_Proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Formlar.FrmMalzemeler frm3;
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm3 == null ||  frm3.IsDisposed)
            {
                frm3 = new Formlar.FrmMalzemeler();
                frm3.MdiParent = this;
                frm3.Show();
            }
        }
        Formlar.FrmAnaForm frm1;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm1 == null  || frm1.IsDisposed)
            {
                frm1 = new Formlar.FrmAnaForm();
                frm1.MdiParent = this;
                frm1.Show();
            }
        }
        Formlar.FrmMetraj frm2;
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm2 == null || frm2.IsDisposed)
            {
                frm2 = new Formlar.FrmMetraj();
                //frm2.MdiParent = this;
                frm2.Show();
            }
        }
        Formlar.FrmMalzemeEkle frm4;
        private void BtnMalzemeEkle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm4 == null || frm4.IsDisposed)
            {
                frm4 = new Formlar.FrmMalzemeEkle();
                frm4.Show();
            }
        }
        MainForm frm5;
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm5 == null || frm5.IsDisposed)
            {
                frm5 = new MainForm();
                frm5.Show();
            }
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("https://www.youtube.com");
        }

        private void BtnIcMekan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("https://www.dezeen.com/interiors/");
        }
        Formlar.FrmYeniPlan frm6;
        private void YeniPlan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm6 == null || frm6.IsDisposed)
            {
                frm6 = new Formlar.FrmYeniPlan();
                frm6.MdiParent = this;
                frm6.Show();
            }
        }
        Formlar.FrmPlanListesi frm7;
        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm7 == null || frm7.IsDisposed)
            {
                frm7 = new Formlar.FrmPlanListesi();
                frm7.MdiParent = this;
                frm7.Show();
            }
        }

        Formlar.FrmHesapMakinesi frm8;
        private void HesapMakinesiBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm8 == null || frm8.IsDisposed)
            {
                frm8 = new Formlar.FrmHesapMakinesi();            
                frm8.Show();
            }
        }
    }
}
