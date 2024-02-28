using System;
using System.Collections.Generic;
using System.Linq;

namespace OgrenciYonetimUygulamasi
{
    internal class Program
    {
        static List<Ogrenci> ogrenciler = new List<Ogrenci>(); // global değişken

        static void Main(string[] args)
        {
            Uygulama();
            //KüpAlma();
            //SubString();
        }
        static void Uygulama()
        {
            bool programCalısıyor = true;
            //SahteVeriEkle();
            Menu();
            {

                int sayac = 0; 
                while (programCalısıyor)
                {

                    Console.Write("Seçiminiz : ");  
                    string giris = SecimAl();

                    switch (giris)
                    {
                        case "E":
                        case "1":
                            OgrenciEkle();
                            break;
                        case "L":
                        case "2":
                            OgrenciListele();
                            break;
                        case "S":
                        case "3":
                            OgrenciSil();
                            break;
                        case "X":
                        case "4":
                            Console.WriteLine("Programdan çıkış yapıldı.");
                            programCalısıyor = false;
                            break;

                        default:
                            Console.WriteLine("Hatalı giriş yapıldı, tekrar deneyin!");
                            break;
                    }
                    sayac++;
                    if (sayac == 10)
                    {
                        Console.WriteLine("Üzgünüm sizi anlayamıyorum. Program sonlandırılıyor...");
                        break;
                    }
                    Console.WriteLine();
                }
            }

        }
        static void OgrenciEkle()
        {
            Ogrenci o = new Ogrenci();
            int sayac = 0;
            
            Console.WriteLine("1- Öğrenci Ekle |--------------------|");
            Console.WriteLine((ogrenciler.Count+1)+". Öğrencinin");
            bool baskaNumaraYok = true;
            while (baskaNumaraYok)
            {
                Console.Write("No: ");
                int noGirin = int.Parse(Console.ReadLine());
                baskaNumaraYok = false;
                foreach (var item in ogrenciler)
                {
                    if (item.No == noGirin)
                    {
                        baskaNumaraYok = true;
                        Console.WriteLine("Bu numarada bir öğrenci zaten mevcut. Lütfen başka bir numara girin.");
                        break;
                    }
                    else
                    {
                        o.No = noGirin;
                    }
                }
            } 
            Console.Write("Adı: ");
            o.Ad = IlkHarfiBuyut(Console.ReadLine());
            Console.Write("Soyadı: "); 
            o.Soyad = IlkHarfiBuyut(Console.ReadLine());
            Console.Write("Şubesi: ");
            o.Sube = Console.ReadLine().ToUpper();

            Console.WriteLine();

            Console.Write("Öğrenciyi kaydetmek istediğinize emin misiniz? (E/H)  ");
            string secim = Console.ReadLine().ToUpper();
            
            if (secim == "E")
            {
                ogrenciler.Add(o);
                Console.WriteLine("Öğrenci eklendi.");
                sayac++;
            }
            else
            {
                Console.WriteLine("Öğrenci eklenmedi.");
            }

            Console.WriteLine();

        }
        static void OgrenciListele()
        {
            if (ogrenciler.Count==0)
            {
                Console.WriteLine("Gösterilicek Öğrenci Yok.");
            }
            else
            {
                Console.WriteLine("2- Öğrenci Listele |--------------------|");
                Console.WriteLine();
                Console.WriteLine("  Şube       No         Ad      Soyad");
                Console.WriteLine("|----------------------------------------");

                foreach (Ogrenci item in ogrenciler)
                {
                    Console.WriteLine("| "+item.Sube.PadRight(11) + item.No+ "          " + item.Ad.PadRight(7) + " " + item.Soyad.PadRight(5));
                }
                Console.WriteLine("| ");
                Console.WriteLine("| Ögrenci Sayısı: " + ogrenciler.Count);
            }
            
        }
        static void OgrenciSil()
        {
            if (ogrenciler.Count==0)
            {
                Console.WriteLine("3- Öğrenci Sil |--------------------|");
                Console.WriteLine("Listede silinecek öğrenci yok.");
                
            }
            else
            {
                Console.WriteLine("3- Öğrenci Sil |--------------------|");
                Console.WriteLine("Silmek istediğiniz öğrencinin");
                Console.Write("No: ");
                int no = int.Parse(Console.ReadLine());
                
                Ogrenci ogr = null;

                if (ogr == null)
                {
                    Console.WriteLine("Listede silinecek öğrenci yok.");
                }
                foreach (Ogrenci item in ogrenciler)
                {
                    if (item.No == no)
                    {
                        ogr = item;
                        break;
                    }
                }
                if (ogr != null)
                {
                    Console.WriteLine("Adı: " + ogr.Ad);
                    Console.WriteLine("Soyadı: " + ogr.Soyad);
                    Console.WriteLine("Şubesi: " + ogr.Sube);
                    Console.WriteLine();
                    Console.Write("Öğrenciyi silmek istediğinize emin misiniz? (E/H)  ");

                    string secim = Console.ReadLine().ToUpper();

                    if (secim == "E")
                    {
                        ogrenciler.Remove(ogr);
                        Console.WriteLine("Öğrenci silindi");
                    }
                    else
                    {
                        Console.WriteLine("Öğrenci Silinemedi.");// silinmedi
                    }
                }
                else
                {
                   // Böyle bir öğrenci bulunamadı.
                }
            }
        }
        static void Menu()
        {
            Console.WriteLine("|¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯|");
            Console.WriteLine("|   Öğrenci Yönetim Uygulaması   | ");
            Console.WriteLine("|________________________________|");
            Console.WriteLine();
            Console.WriteLine("1 - Öğrenci Ekle(E)       ");
            Console.WriteLine("2 - Öğrenci Listele(L)    ");
            Console.WriteLine("3 - Öğrenci Sil(S)        ");
            Console.WriteLine("4 - Çıkış(X)              ");
            Console.WriteLine();
        }
        static void SahteVeriEkle()
        {
            Ogrenci o1 = new Ogrenci();
            o1.Ad = "Mehmet";
            o1.Soyad = "Gündüz";
            o1.No = 1;
            o1.Sube = "A";
            ogrenciler.Add(o1);

            Ogrenci o2 = new Ogrenci();
            o2.Ad = "Ahmet";
            o2.Soyad = "Kıymaz";
            o2.No = 2;
            o2.Sube = "B";
            ogrenciler.Add(o2);

            Ogrenci o3 = new Ogrenci();
            o3.Ad = "Ayşe";
            o3.Soyad = "Yıldız";
            o3.No = 3;
            o3.Sube = "C";
            ogrenciler.Add(o3);

            Ogrenci o4 = new Ogrenci();
            o4.Ad = "Aycan";
            o4.Soyad = "Ay";
            o4.No = 4;
            o4.Sube = "A";
            ogrenciler.Add(o4);

            Ogrenci o5 = new Ogrenci();
            o5.Ad = "Cemile";
            o5.Soyad = "Nalbant";
            o5.No = 5;
            o5.Sube = "B";
            ogrenciler.Add(o5);
        }
        static string SecimAl()
        {
            string giris = Console.ReadLine().ToUpper();
            return giris;
        }
        static string IlkHarfiBuyut(string metin)
        {

            return metin.Substring(0, 1).ToUpper() + metin.Substring(1).ToLower();
        }
        static void SubString()
        {
            string a = "Bve hiçbir System sınıfından string metot kullanılmasın";
            string c = a.Substring(6, 10);
            Console.WriteLine(c);
        }
        static void KüpAlma()
        {
            Console.Write("Küp'ü Alınacak Sayıyı Giriniz: ");
            int sayi1 = Convert.ToInt32(Console.ReadLine());
            int sayi2;
            if (sayi1>0)
            {
                sayi2 = sayi1 * sayi1 * sayi1;
                
                Console.WriteLine("Sonuç: " + sayi2);
            }
            else
            {
                Console.WriteLine("Pozitif Değerler Giriniz..!");
            }
            
            
            


        }


    }
}
