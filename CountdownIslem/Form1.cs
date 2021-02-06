using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CountdownIslem
{

    public partial class Form1 : Form
    {
        public static Random randomSayi = new Random();
        public static int[] SayiArray = new int[6];
        public static int hedefSayi = 0;
        public static int cozumEniyi = 0;
        public static double gecenSure = 0;
        public Form1()
        {
            InitializeComponent();
        }
       

        private void Hesapla_Click(object sender, EventArgs e)
        {
            //sayilarin alinmasi bos kutu varsa calismaz
            int kontrol = 0;
            if (sayi1.Text != ""){ SayiArray[0] = Convert.ToInt32(sayi1.Text); kontrol++; } 
            if (sayi2.Text != ""){ SayiArray[1] = Convert.ToInt32(sayi2.Text); kontrol++; }
            if (sayi3.Text != ""){ SayiArray[2] = Convert.ToInt32(sayi3.Text); kontrol++; }
            if (sayi4.Text != ""){ SayiArray[3] = Convert.ToInt32(sayi4.Text); kontrol++; }
            if (sayi5.Text != ""){ SayiArray[4] = Convert.ToInt32(sayi5.Text); kontrol++; }
            if (sayi6.Text != ""){ SayiArray[5] = Convert.ToInt32(sayi6.Text); kontrol++; }
            if (hedefNum.Text != ""){ hedefSayi = Convert.ToInt32(hedefNum.Text); kontrol++; }
            if (kontrol != 7) MessageBox.Show("Lütfen Eksik Kutuları Doldurunuz!");
            
            
            // Tamamen kaba kuvvetle tum islemlerin yapilip hedefe ulasilmaya calisilmasi
            while (kontrol == 7)
            {

                //Her loopta farkli sayi dizisiyle denemek için sayi kariştirmasi
                int num = randomSayi.Next(6);
                int temp = SayiArray[num];
                SayiArray[num] = SayiArray[0];
                SayiArray[0] = temp;
                
                //islemlerdeki toplamı tutma
                int toplam = SayiArray[0];

                //Cozumun stringini tutma. Girecek ilk sayıyı atama sonrasında loopla eklenecek
                string cozumString = SayiArray[0].ToString();

                //tum numaralar kullanilmak zorunda kalınmayabilir diye random birkaçını secip hepsini deneme
                int kullanilacakSayilar = randomSayi.Next(1, 7);

                //
                for (int i = 1 ; i < kullanilacakSayilar ; i++)
                {

                    //Operatorlerin rastgele secilip sonucun bulunmaya calisilmasi
                    int operation = randomSayi.Next(4);
                    if (operation == 0)
                    {
                        toplam += SayiArray[i];
                        cozumString += " + " + SayiArray[i].ToString();
                    }
                    if (operation == 1)
                    {
                        toplam -= SayiArray[i];
                        cozumString += " - " + SayiArray[i].ToString();
                    }
                    if (operation == 2)
                    {
                        toplam *= SayiArray[i];
                        cozumString += " x " + SayiArray[i].ToString();
                    }
                    if (operation == 3)
                    {
                        if (toplam % SayiArray[i] != 0) continue;  //fraction?
                        toplam /= SayiArray[i];
                        cozumString += " / " + SayiArray[i].ToString();
                    }

                }

                //Sonucu stringe yazdirma
                cozumString += " = " + toplam.ToString();

                //Sonuc tutturlamazsa su ana kadar en iyisini yazdir
                if (Math.Abs(hedefSayi - toplam) < Math.Abs(hedefSayi - cozumEniyi))
                {
                    cozumEniyi = toplam;
                    
                    sonucLbl.Text = cozumString;
                }

                //Eger hedef tutturulmussa donguyu sonladir
                if (toplam == hedefSayi) break;
                
            }
           
            
        }
        // girilen sayilarin int kontrolü
        private void sayi1_KeyPress(object sender, KeyPressEventArgs e)
        {
            sayi1.MaxLength = 1;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void sayi2_KeyPress(object sender, KeyPressEventArgs e)
        {
            sayi2.MaxLength = 1;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void sayi3_KeyPress(object sender, KeyPressEventArgs e)
        {
            sayi3.MaxLength = 1;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void sayi4_KeyPress(object sender, KeyPressEventArgs e)
        {
            sayi4.MaxLength = 1;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void sayi5_KeyPress(object sender, KeyPressEventArgs e)
        {
            sayi5.MaxLength = 1;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void sayi6_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            sayi6.MaxLength = 1;
            if (sayi6.TextLength == 1)
            {
                sayi6.Text += 0;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void hedefNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            hedefNum.MaxLength = 3;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
    
}
