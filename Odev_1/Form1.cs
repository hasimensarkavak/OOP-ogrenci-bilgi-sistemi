using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true; //Form yüklendiğin de Lisans seçili olsun istiyorum
        }

        public Ders[] dersListesi = new Ders[1]; // Kullanıcıdan öğrenci alırken gereken dizi Buttonlardan erişmek 
                                                 // istediğim için globalde tanımladım

        int i = 1;  //başka buttondan sıfırlamak istediğim için burada tanımladım          

        public void temizle()  //ekran temizleme fonksiyonu
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            lisansB.Clear();
            lisansO.Clear();
            yuksekB.Clear();
            yuksekO.Clear();
            i = 1;
            dersIndex.Text = "0 Ders Eklendi";
        }

        private void button1_Click(object sender, EventArgs e)  // Hesapla Göster Buttonu
        {
            listBox1.Items.Clear();
            
            if (radioButton1.Checked==true)
            {
                Lisans lisansOgrenci = new Lisans();
                lisansOgrenci.AdSoyad = textBox1.Text;
                lisansOgrenci.OgrenciNo = textBox2.Text;
                lisansOgrenci.Bolum = textBox3.Text;
                lisansOgrenci.Dersler = dersListesi;
                lisansOgrenci.Yazdir(listBox1);
            }

            if (radioButton2.Checked==true)
            {
                YuksekLisans yuksekOgrenci = new YuksekLisans(lisansO.Text,lisansB.Text);
                yuksekOgrenci.AdSoyad = textBox1.Text;
                yuksekOgrenci.OgrenciNo = textBox2.Text;
                yuksekOgrenci.Bolum = textBox3.Text;
                yuksekOgrenci.Dersler = dersListesi;
                yuksekOgrenci.LisansYazdir(listBox1);
                yuksekOgrenci.Yazdir(listBox1);
            }

            if (radioButton3.Checked==true)
            {
                Doktora doktoraOgrenci = new Doktora(lisansO.Text,lisansB.Text,yuksekO.Text,yuksekB.Text);
                doktoraOgrenci.AdSoyad = textBox1.Text;
                doktoraOgrenci.OgrenciNo = textBox2.Text;
                doktoraOgrenci.Bolum = textBox3.Text;
                doktoraOgrenci.Dersler = dersListesi;
                doktoraOgrenci.LisansYuksekLisansYazdir(listBox1);
                doktoraOgrenci.Yazdir(listBox1);
            }

            temizle(); // gösterimden sonra ekranı temizliyoruz.
            dersListesi = new Ders[1]; // Gösterdikten sonra diziyi sıfırlıyorum yeni öğrencide problem olmasın.
        }

        
        private void button2_Click(object sender, EventArgs e) // Ders ekleme buttonu
        {
            Array.Resize(ref dersListesi, i);
            Ders ders = new Ders(textBox4.Text,textBox5.Text,Convert.ToInt32(textBox6.Text),Convert.ToInt32(textBox7.Text));
            dersListesi[i-1] = ders;
            dersIndex.Text = i + " Ders Eklendi"; // kaç ders eklediğimizi sayıyıoruz
            i++;
            textBox4.Clear();
            textBox5.Clear(); //Ders eklendikten sonra textBoxları temizliyoruz
            textBox6.Clear();
            textBox7.Clear();
        }


        private void lisansbt_Click(object sender, EventArgs e) // örnek lisans öğrencisi
        {
            listBox1.Items.Clear();

            Lisans lisansOgrenci = new Lisans();
            lisansOgrenci.AdSoyad = "Haşim Ensar Kavak";
            lisansOgrenci.Bolum = "Bilgisayar Bilimleri";
            lisansOgrenci.OgrenciNo = "2018280027";
            Ders ders = new Ders("MAT101","Matematik",6,62);
            Ders ders1 = new Ders("MAT107", "Matematik", 6, 80);
            Ders ders2 = new Ders("FSH333", "Hayat Bilgisi", 8, 60);
            Ders[] dersler = { ders, ders1, ders2 };
            lisansOgrenci.Dersler = dersler;

            lisansOgrenci.Yazdir(listBox1);

        }

       

        private void yüksekbt_Click(object sender, EventArgs e) // örnek yüksek lisans öğrencisi
        {
            listBox1.Items.Clear();

            YuksekLisans yuksekOgrenci = new YuksekLisans("İstanbul Üniversitesi","Tarih");
            yuksekOgrenci.AdSoyad = "ADİL KEMAL KÜKRER";
            yuksekOgrenci.Bolum = "TARİH";
            yuksekOgrenci.OgrenciNo = "2009291062";
            Ders ders = new Ders("TAR505", "Tatar Tarihi", 18, 79);
            Ders ders1 = new Ders("TAR511", "Uzakdoğu Halkları", 18, 100);
            Ders[] dersler = { ders, ders1 };
            yuksekOgrenci.Dersler = dersler;

            yuksekOgrenci.LisansYazdir(listBox1);
            yuksekOgrenci.Yazdir(listBox1);
        }

        private void doktorabt_Click(object sender, EventArgs e) // örnek doktora öğrencisi
        {
            listBox1.Items.Clear();

            Doktora doktoraOgrenci = new Doktora("Ege Üniversitesi","Beden Eğitimi Ve Spor","University Of British Columbia","Kinesiology");
            doktoraOgrenci.OgrenciNo = "2009291030";
            doktoraOgrenci.AdSoyad = "DOĞAÇ SAZAN";
            doktoraOgrenci.Bolum = "SPOR BİLİMLERİ";
            Ders ders = new Ders("SPB603", "Rehabilitatif Spor",18,95);
            Ders ders1 = new Ders("SPB630", "Sporda Sponsorluk", 6, 100);
            Ders[] dersler = { ders, ders1 };
            doktoraOgrenci.Dersler = dersler;

            doktoraOgrenci.LisansYuksekLisansYazdir(listBox1);
            doktoraOgrenci.Yazdir(listBox1);

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) // lisans radio buttonu
        {
            if (radioButton1.Checked == true)
            {
                lisansO.Enabled = false;
                lisansB.Enabled = false;
                yuksekO.Enabled = false;
                yuksekB.Enabled = false;
                temizle();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) // Yüksek lisans Radio buttonu
        {
            if (radioButton2.Checked == true)
            {
                lisansB.Enabled = true;
                lisansO.Enabled = true;
                yuksekO.Enabled = false;
                yuksekB.Enabled = false;
                temizle();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e) //Doktora Radio buttonu
        {
            if (radioButton3.Checked == true)
            {
                lisansB.Enabled = true;
                lisansO.Enabled = true;
                yuksekO.Enabled = true;
                yuksekB.Enabled = true;
                temizle();
            }
        }
    }

    public class Ders
    {
        public string dersKodu;
        public string dersAdi;
        public int akts;
        public int basariNotu; 
        public Ders(string dersKodu, string dersAdi, int akts, int basariNotu)
        {
            this.dersKodu = dersKodu;
            this.dersAdi = dersAdi;
            this.akts = akts;
            this.basariNotu = basariNotu;
        }
    }

    public abstract class Ogrenci
    {
        public abstract string AdSoyad { get; set; }
        public abstract string OgrenciNo { get; set; }
        public abstract string Bolum { get; set; }
        public abstract Ders[] Dersler {get;set;}
        public abstract void Yazdir(ListBox listBox);
        public string KumulatifHesapla (Ders[] dersler) // hesaplama hepsinde aynı olduğu için abstract class içinde doldurdum.
        {
            double notToplami = 0.0;
            int toplamAkts = 0;
            foreach (var ders in dersler)
            {
                toplamAkts += ders.akts;
                notToplami += ders.akts * ders.basariNotu;
            }

            double kumulatifBasariNotu = notToplami / toplamAkts;
            string sonuc = kumulatifBasariNotu.ToString("0.##"); 
            return sonuc;
        }
    }

    public class Lisans : Ogrenci
    {
        public override string AdSoyad { get; set; }
        public override string OgrenciNo { get; set; }
        public override string Bolum { get; set; }
        public override Ders[] Dersler { get; set; }
        public override void Yazdir(ListBox listBox) // yazdırma fonk
        {
            listBox.Items.Add("Lisans Öğrencisi");
            listBox.Items.Add("");
            listBox.Items.Add("No: " + OgrenciNo);
            listBox.Items.Add("Ad Soyad: " + AdSoyad);
            listBox.Items.Add("Bölüm: " + Bolum);
            listBox.Items.Add("");

            string kumulatifBasariNotu = KumulatifHesapla(Dersler);

            foreach (var de in Dersler)
            {
                listBox.Items.Add(de.dersKodu + "    " + de.dersAdi + "    AKTS: " + de.akts + "     Başarı Notu: " + de.basariNotu);
            }

            listBox.Items.Add("");
            listBox.Items.Add("Kümülatif Başarı Notu: " + kumulatifBasariNotu);
        }
    }

    public class LisansUstu : Ogrenci
    {
        protected string adSoyad; // Yüksek Lisans ve Doktora da da kullanmak için protected. Lisans classında kullandığım
                                // gibi kullanabilirdim fakat protected da kullanmak istedim.
        public override string AdSoyad 
        {
            get
            {
                return adSoyad;
            }
            set
            {
                adSoyad = value;
            }
        }
        protected string ogrenciNo;
        public override string OgrenciNo
        {
            get
            {
                return ogrenciNo;
            }
            set
            {
                ogrenciNo = value;
            }
        }
        protected string bolum;
        public override string Bolum
        {
            get
            {
                return bolum;
            }
            set
            {
                bolum = value;
            }
        }
        public override Ders[] Dersler { get; set; }

        public override void Yazdir(ListBox listBox)
        {
            listBox.Items.Add("No: " + ogrenciNo);
            listBox.Items.Add("Ad Soyad: " + adSoyad);
            listBox.Items.Add("Bölüm: " + bolum);
            listBox.Items.Add("");

            string kumulatifBasariNotu = KumulatifHesapla(Dersler);

            foreach (var de in Dersler)
            {
                listBox.Items.Add(de.dersKodu + "    " + de.dersAdi + "    AKTS: " + de.akts + "     Başarı Notu: " + de.basariNotu);
            }

            listBox.Items.Add("");
            listBox.Items.Add("Kümülatif Başarı Notu: " + kumulatifBasariNotu);
        }
    }

    public class YuksekLisans : LisansUstu
    {
        private string lisansUni, lisansBolum; //constuctor ile erişim var o yüzden private

        public  YuksekLisans(string lisansUni, string lisansBolum)
        {
            this.lisansBolum = lisansBolum;
            this.lisansUni = lisansUni;
        }
        public void LisansYazdir(ListBox listBox) // lisans bilgilerini yazdırma
        {
            listBox.Items.Add("Yüksek Lisans Öğrencisi");
            listBox.Items.Add("");
            listBox.Items.Add("Lisans Bilgileri");
            listBox.Items.Add(lisansUni + ";   " +lisansBolum);
            listBox.Items.Add("");
            listBox.Items.Add("Yüksek Lisans Bilgileri");
        }
    }

    public class Doktora : LisansUstu
    {
        private string lisansUni, lisansBolum,yuksekUni,yuksekBolum; //constuctor ile erişim var o yüzden private

        public Doktora(string lisansUni, string lisansBolum,string yuksekUni,string yuksekBolum)
        {
            this.lisansBolum = lisansBolum;
            this.lisansUni = lisansUni;
            this.yuksekBolum = yuksekBolum;
            this.yuksekUni = yuksekUni;
        }

        public void LisansYuksekLisansYazdir(ListBox listBox) // yüksek lisans ve lisans bilgilerini yazdırma
        {
            listBox.Items.Add("Doktora Öğrencisi");
            listBox.Items.Add("");
            listBox.Items.Add("Lisans Bilgileri");
            listBox.Items.Add(lisansUni + ";   " + lisansBolum);
            listBox.Items.Add("");
            listBox.Items.Add("Yüksek Lisans Bilgileri");
            listBox.Items.Add(yuksekUni + ";   " + yuksekBolum);
            listBox.Items.Add("");
            listBox.Items.Add("Doktora Bilgileri");
        }
    }

}
