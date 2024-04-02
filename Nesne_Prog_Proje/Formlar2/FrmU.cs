using Nesne_Prog_Proje.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nesne_Prog_Proje.Formlar2
{
    public partial class FrmU : Form
    {
        public FrmU()
        {
            InitializeComponent();
        }
        DbTasarimRehberimEntities db = new DbTasarimRehberimEntities();
        metrajHesapla karehesapla = new metrajHesapla();

        double bilgi;
        double toplam1 = 0;
        private void BtnBosKareHesapla_Click(object sender, EventArgs e)
        {
            karehesapla.x = Convert.ToDouble(textEdit1.Text);
            karehesapla.y = Convert.ToDouble(textEdit2.Text);
            karehesapla.z = Convert.ToDouble(textEdit3.Text);
            karehesapla.adet = Convert.ToInt32(textEdit4.Text);
            karehesapla.kalinlik = Convert.ToDouble(textEdit6.Text);
            karehesapla.toplam = 0;
            karehesapla.d = Convert.ToInt32(lookUpEdit1.Text);
            karehesapla.U();

            bilgi = karehesapla.U();
            textEdit5.Text = Convert.ToString(karehesapla.U());
        }

        private void FrmU_Load(object sender, EventArgs e)
        {
            var degerler = (from x in db.TblMalzemeler
                            select new
                            {
                                x.ID,
                                x.MalzemeAd,
                                x.Yogunluk
                            }).ToList();

            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "Yogunluk";
            lookUpEdit1.Properties.DataSource = degerler;
        }

        private void BtnKareTemizle_Click(object sender, EventArgs e)
        {
            textEdit1.Clear();
            textEdit2.Clear();
            textEdit3.Clear();
            textEdit4.Clear();
            textEdit5.Clear();
            textEdit6.Clear();
            lookUpEdit1.Clear();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(bilgi);
            toplam1 += bilgi / 1000;

            toplamKg.Text = toplam1.ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            toplam1 = 0;
            toplamKg.Text = toplam1.ToString();
        }
    }
}
