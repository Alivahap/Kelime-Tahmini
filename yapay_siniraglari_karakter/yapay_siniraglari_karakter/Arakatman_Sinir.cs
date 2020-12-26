using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yapay_siniraglari_karakter
{
   public class Arakatman_Sinir
    {
        public int deger;
        public double bag_x;
        public double bag_y;
        public double bag_z;
        public double bag_a;
        public double bag_b;
        //sigmoid fonk sonucu atanakcak olacan çözüm ve eşik değeri
        public double cozum;
        public double esik;
        //sonradan öğrenme işlemleri için  eski değerler aldım. Eski değer eşik değerinin eski değeridir. 
        public double eskideger;
        public double biat;
        //sinir hücrelerinin her birinin bir aldığı ara değerleri bağlarla ifade(bag_x gibi) ettim.ve başlangıçta
        //rastegele bir sayı verdim
        Random rn = new Random();
       public Arakatman_Sinir()
        {
            this.bag_x = rn.NextDouble() * rn.Next(-1, 1);
            this.bag_y = rn.NextDouble() * rn.Next(-1, 1);
            this.bag_z = rn.NextDouble() * rn.Next(-1, 1);
            this.bag_a = rn.NextDouble() * rn.Next(-1, 1);
            this.bag_b = rn.NextDouble() * rn.Next(-1, 1);
            this.biat = rn.NextDouble() * rn.Next(-1, 1);

        }



    }
}
