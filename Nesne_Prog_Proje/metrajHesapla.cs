using Nesne_Prog_Proje.Formlar;
using Nesne_Prog_Proje.Formlar2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nesne_Prog_Proje
{
    class metrajHesapla  
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public int adet { get; set; }
        public double toplam { get; set; }
        public int d { get; set; }
        public double m { get; set; }
        public double pi = 3.14;
        public double kalinlik { get; set; }

        public double doluKare()
        {
          
            toplam = x * y * z * adet;// hacim            
          
            return toplam * d;//kütle
            
        }

        public double doluDaire()
        {
            toplam = pi * x * x * adet *y;

            return toplam * d;
        }

        public double bosKare()
        {

            toplam = (x*y - ((x - 2 * kalinlik) * (y - 2 * kalinlik))) * z * adet;// hacim            * z * adet
          
            return toplam * d;//kütle

        }

        public double bosDaire()
        {
            toplam = ((pi * x * x)-(pi* (x - kalinlik) * (x - kalinlik))) * adet * y;

            return toplam * d;
        }

        public double U()
        {

            toplam = (x * y -((x - 2 * kalinlik) * (y - kalinlik))) * z * adet;// hacim            

            return toplam * d;//kütle

        }

        public double L()
        {

            toplam = (x * y - ((x - kalinlik) *(y - kalinlik)))* z * adet;// hacim            

            return toplam * d;//kütle

        }

        public double I()
        {

            toplam = (x * y - ((x - kalinlik) * (y - 2 *  kalinlik))) * z * adet;// hacim            

            return toplam * d;//kütle

        }
    }
}
