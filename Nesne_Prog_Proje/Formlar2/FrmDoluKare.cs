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
    public partial class FrmDoluKare : Form 
    {
        public FrmDoluKare()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {

        }
        DbTasarimRehberimEntities db = new DbTasarimRehberimEntities();
        metrajHesapla karehesapla = new metrajHesapla();

        double bilgi;
        double toplam1 = 0;
        public void BtnKareHesapla_Click_1(object sender, EventArgs e)
        {           
            karehesapla.x = Convert.ToDouble(textEdit1.Text);
            karehesapla.y = Convert.ToDouble(textEdit2.Text);
            karehesapla.z = Convert.ToDouble(textEdit3.Text);
            karehesapla.adet = Convert.ToInt32(textEdit4.Text);         
            karehesapla.toplam = 0;
            karehesapla.d = Convert.ToInt32(lookUpEdit1.Text);
            karehesapla.doluKare();

            bilgi = karehesapla.doluKare();
            textEdit5.Text = Convert.ToString(karehesapla.doluKare());

        }

        private void BtnKareTemizle_Click(object sender, EventArgs e)
        {
            textEdit1.Clear();
            textEdit2.Clear();
            textEdit3.Clear();
            textEdit4.Clear();
            textEdit5.Clear();
            lookUpEdit1.Clear();

        }
        
        public void BtnEkle_Click(object sender, EventArgs e)
        {

            listBox1.Items.Add(bilgi);
            toplam1 += bilgi/1000;
            
            toplamKg.Text = toplam1.ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            toplam1 = 0;
            toplamKg.Text = toplam1.ToString();
        }

        private void FrmDoluKare_Load(object sender, EventArgs e)
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
    }
}
