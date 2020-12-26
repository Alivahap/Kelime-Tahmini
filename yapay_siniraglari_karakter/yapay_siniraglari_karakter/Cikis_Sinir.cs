using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yapay_siniraglari_karakter
{
    public class Cikis_Sinir
    {
        //harflerimizi tahmin değererini tutan sinir sınıfımızdır 
        public int deger;
       
        //sigmoid fonksiyonu ile elde edilecek olan çözüm ve eşik değeri 
        public double cozum;
        public double esik;
       
        //bias değeri 
        public double biat;

        //çıkış sinirini bağları olmadığı için bağ tanımlaması yamadım
        Random rn = new Random();
        public Cikis_Sinir()
        {
          
            this.biat = rn.NextDouble() * rn.Next(-1, 1);

        }




    }
}
