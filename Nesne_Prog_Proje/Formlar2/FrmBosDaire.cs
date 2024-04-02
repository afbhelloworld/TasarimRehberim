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
    public partial class FrmBosDaire : Form
    {
        public FrmBosDaire()
        {
            InitializeComponent();
        }
        DbTasarimRehberimEntities db = new DbTasarimRehberimEntities();
        metrajHesapla daire = new metrajHesapla();
        double bilgi;
        double toplam1 = 0;
        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void BtnKareHesapla_Click(object sender, EventArgs e)
        {
            daire.x = Convert.ToInt32(txtyaricap.Text);
            daire.y = Convert.ToInt32(txtUzunluk.Text);
            daire.adet = Convert.ToInt32(txtAdet.Text);
            daire.kalinlik = Convert.ToDouble(txtkalinlik.Text);
            daire.d = Convert.ToInt32(lookUpEdit1.Text);
            daire.toplam = 0;
            daire.bosDaire();

            bilgi = daire.bosDaire();
            textEdit5.Text = Convert.ToString(daire.bosDaire());
        }

        private void FrmBosDaire_Load(object sender, EventArgs e)
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
            txtyaricap.Clear();
            txtUzunluk.Clear();
            txtAdet.Clear();
            txtkalinlik.Clear();
            lookUpEdit1.Clear();
            textEdit5.Clear();
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
