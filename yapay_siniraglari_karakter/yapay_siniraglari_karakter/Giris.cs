using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yapay_siniraglari_karakter
{
    public class Giris_Sinir
    {
        //sinir hücrelerinin her birinin bir aldığı ara değerleri bağlarla ifade ettim.ve başlangıçta
        //rastegele bir sayı verdim
        public int deger;
        public double bag_x;
        public double bag_y;
        public double bag_z;
        //sigmoid fonk sonucu atanakcak olacan çözüm ve eşik değeri
        public double cozum;
        public double esik;

        public double eskideger;

        public double biat;
        Random rn = new Random();
       public Giris_Sinir()
        {
            this.bag_x = rn.NextDouble()*rn.Next(-1,1);
            this.bag_y = rn.NextDouble() * rn.Next(-1, 1);
            this.bag_z = rn.NextDouble() * rn.Next(-1, 1);
            this.biat = rn.NextDouble() * rn.Next(-1, 1);

        }




    }
}
