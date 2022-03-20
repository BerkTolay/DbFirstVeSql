using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DbFirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindEntities db = new NorthwindEntities();
            db.Configuration.LazyLoadingEnabled = false;
            Console.WriteLine("------------");

            #region CRUD

            #region CREATE

            //var category = new Kategoriler();
            //category.KategoriAdi = "Çerezler";
            //category.Tanimi = "fındık,fıstık,ceviz...";
            //db.Kategorilers.Add(category);
            //db.SaveChanges();


            #endregion

            #region Read

            //var category = db.Kategorilers;
            //foreach (var cat in category)
            //{
            //    Console.WriteLine(cat.KategoriAdi + " /" + cat.Tanimi);
            //}


            #endregion

            #region UPDATE

            //var category = db.Kategorilers.Find(9);//find'a bir primary key verilmeli
            //category.KategoriAdi = "içecekler";
            //category.Tanimi = "su,cola,mevye suyu...";
            //db.SaveChanges();

            #endregion

            #region DELETE

            //var category = db.Kategorilers.Find(9);
            //db.Kategorilers.Remove(category);
            //db.SaveChanges();

            #endregion

            #endregion

            #region SQL sorguları
            //urunler tablosu eklenmemiş şekilde
            #region Select * from Kategoriler

            //method
            //var result = db.Kategorilers;
            //ConsoleTable.From(result).Write();

            //linq
            //var result = from cat in db.Kategorilers
            //select cat;
            //ConsoleTable.From(result).Write();

            #endregion

            #region Select KategoriId as Id, KategoriAdi as Name from kategoriler


            //var result = db.Kategorilers.Select(x => new
            //{
            //    Id = x.KategoriID,
            //    name = x.KategoriAdi
            //});

            ////linq
            //var result = from cat in db.Kategorilers
            //             select new
            //             {
            //                 Id = cat.KategoriID,
            //                 Name = cat.KategoriAdi
            //             };

            #endregion

            #region Select top(2) from kategoriler

            //method
            //var result = db.Kategorilers.Take(2);


            #endregion

            #region Select * from kategoriler order by kategoriadi
            //method
            //var result = db.Kategorilers.OrderBy(x => x.KategoriAdi);
            //var result2 = db.Kategorilers.OrderByDescending(x => x.KategoriAdi);
            //ConsoleTable.From(result2).Write();
            #endregion

            #region Select * from katagoriler where kategoriId<5

            //var result = db.Kategorilers.Where(x => x.KategoriID < 5);


            #endregion

            #region Select * from katagoriler where kategoriId<>4 and kategoriId<>7

            //var result = db.Kategorilers.Where(x => x.KategoriID != 4 && x.KategoriID != 7);


            #endregion

            #region Select * from katagoriler where kategoriId between 3 and 6

            //var result = db.Kategorilers.Where(x => x.KategoriID >= 3 && x.KategoriID <= 6);

            #endregion

            #region Select * from katagoriler where kategoriId not between 3 and 6
            //var result = db.Kategorilers.Where(x => x.KategoriID < 3 || x.KategoriID > 6);

            #endregion

            #region Select sum(categoriId) from categories

            //var result2 = db.Kategorilers.Sum(x => x.KategoriID);
            //Console.WriteLine(result2);
            #endregion

            #region Select avg(kategoriId) from kategoriler

            //var result2 = db.Kategorilers.Average(x => x.KategoriID);
            //Console.WriteLine(result2);

            #endregion

            #region select max(kategoriId) from kategoriler

            //var result2 = db.Kategorilers.Max(x => x.KategoriID);
            //Console.WriteLine(result2);

            #endregion

            #region select max(kategoriId) from kategoriler

            //var result2 = db.Kategorilers.Min(x => x.KategoriID);
            //Console.WriteLine(result2);

            #endregion

            #region select KategoriID as Id, KategoriID*KategoriID as IdKare from Kategoriler

            //var result = db.Kategorilers.Select( x=> new
            //{
            //    Id=x.KategoriID,
            //    IdKare=x.KategoriID*x.KategoriID
            //});
            //ConsoleTable.From(result).Write();

            #endregion

            #region select * from Kategoriler where KategoriAdi like '%ro%'

            //var result = db.Kategorilers.Where(x => x.KategoriAdi.Contains("ro"));
            //ConsoleTable.From(result).Write();
            #endregion

            #region select * from Kategoriler where KategoriAdi like 'pr%'

            //var result = db.Kategorilers.Where(x => x.KategoriAdi.StartsWith("pr"));
            //ConsoleTable.From(result).Write();
            #endregion

            #region select * from Kategoriler where KategoriAdi like '%ts'

            //var result = db.Kategorilers.Where(x => x.KategoriAdi.EndsWith("ts"));
            //ConsoleTable.From(result).Write();
            #endregion

            //ConsoleTable.From(result).Write();

            //-----------------------------------

            #region select UrunAdi,KategoriAdi from kategoriler k join Urunler u on k.KategoriID=u.TedarikciID
            //linq

            //var result = from c in db.Kategorilers
            //    join u in db.Urunlers on c.KategoriID equals u.KategoriID
            //    select new
            //    {
            //        u.UrunAdi,
            //        c.KategoriAdi

            //    };
            //ConsoleTable.From(result).Write();
            #endregion

            #region select UrunAdi,KategoriAdi, BirimFiyati from kategoriler k join Urunler u on k.KategoriID=u.TedarikciID order by BirimFiyati desc

            //var result = from k in db.Kategorilers
            //    join u in db.Urunlers 
            //    on k.KategoriID equals u.KategoriID 
            //    orderby u.BirimFiyati descending 
            //    select new
            //    {
            //        u.UrunAdi,
            //        k.KategoriAdi,
            //        u.BirimFiyati
            //    };
            //ConsoleTable.From(result).Write();
            #endregion

            #region select KategoriID, count(*) as numberofproducts from urunler group by KategoriID

            //var result = from u in db.Urunlers
            //    group u by u.KategoriID
            //    into g //u'yu kategoriId sine göre grupla, into ile g olarak dahil et
            //    select new
            //    {
            //        g.Key, //kategori id'yi verecek
            //        NumberOfProducts = g.Count()
            //    };
            //ConsoleTable.From(result).Write();


            #endregion

            #region select KategoriAdi, count(*) as NumberOfProducts from Kategoriler k join Urunler u on k.KategoriID=u.KategoriID group by KategoriAdi

            //var result = from c in db.Kategorilers
            //    join u in db.Urunlers
            //        on c.KategoriID equals u.KategoriID
            //    group c by c.KategoriAdi
            //    into g
            //    select new
            //    {
            //        g.Key,
            //        NumberOfProduct=g.Count()
            //    };
            //ConsoleTable.From(result).Write();
            #endregion

            #region select kategoriAdi, count(*) as numberofproducts, sum(birimfiyati) as TotalPrice,max(birimfiyati) as maxprice, min(BirimFiyati) as minprice from Kategoriler k join urunler u on k.KategoriID = u.KategoriID group by KategoriAdi

            //var result = from k in db.Kategorilers
            //    join u in db.Urunlers
            //        on k.KategoriID equals u.KategoriID
            //    group new {k,u} by new { k.KategoriAdi } //k.kategoriadi bir obje olarka gönderilir
            //    into g
            //    select new
            //    {
            //        g.Key.KategoriAdi,
            //        NumberOfProducts=g.Count(),
            //        TotalPrice=g.Sum(x=>x.u.BirimFiyati),
            //        MaxPrice=g.Sum(x=>x.u.BirimFiyati),
            //        MinPRice=g.Sum(x=>x.u.BirimFiyati)
            //    };
            //ConsoleTable.From(result).Write();

            #endregion

            #region select kategoriAdi, count(*) as numberofproducts, sum(birimfiyati) as TotalPrice,max(birimfiyati) as maxprice, min(BirimFiyati) as minprice from Kategoriler k join urunler u on k.KategoriID = u.KategoriID group by KategoriAdi having SUM(BirimFiyati)>300
            //var result = (from k in db.Kategorilers
            //              join u in db.Urunlers
            //                  on k.KategoriID equals u.KategoriID
            //              group new { k,u  } by new { k.KategoriAdi } //k.kategoriadi bir obje olarka gönderilir
            //    into g
            //              select new
            //              {
            //                  g.Key.KategoriAdi,
            //                  NumberOfProducts = g.Count(),
            //                  TotalPrice = g.Sum(x => x.u.BirimFiyati),
            //                  MaxPrice = g.Sum(x => x.u.BirimFiyati),
            //                  MinPRice = g.Sum(x => x.u.BirimFiyati)
            //              }).Where(x => x.TotalPrice > 300);

            //ConsoleTable.From(result).Write();


            #endregion








            #endregion

            #region Immediate Mode ve Defered Mode
            //Immediate Mode: tolist te sorgu bu kodda sql servera gönderilir
            //var kategoriler = db.Kategorilers.ToList();

            //Defered Mode: burada ise kategoriler değişkeni kullanılmadan sorgu gönderilmez
            //var kategoriler = db.Kategorilers;

            #endregion

            #region Lazy Loading ve Navigation Properties
            ////model propertieslerinden lazy loading enable olmalı
            //var category = db.Kategorilers.Find(1);
            ////var products = db.Urunlers.Where(x => x.KategoriID == category.KategoriID);
            //var products = category.Urunlers;//category Kategorilers içinden urunlere erişebilir
            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.UrunAdi);
            //    Console.WriteLine("tedarikciler:" + product.Tedarikciler.SirketAdi);
            //    //product, category aracılığı ile ürünlere erişti, product ürünler içerisinden tedarikçilere erişebilir
            //    //fakat ne kadar ürün varsa o kadar sorgu gider, performansı etkiler
            //    //** 1000 ürün varsa 1000 sorgu + var category=db.kategorilers.find(1) de +1 sorgu =1001 sorgu
            //}


            #endregion

            #region Eager Loading
            //lazy loading yerine eager loading kullanmamızın sebebi
            //1001 N+1 problemi //**

            //lazy loading false yapılır

            //var category = db.Kategorilers.Include("Urunlers").Include("Urunlers.Tedarikciler").FirstOrDefault(x => x.KategoriID == 1);
            ////lazy loading false olduğu için urunlers'i ve tedarikcileri bizim eklememiz gerekir(navigation propertieslerde Urunler=Urunlers olarka yazıyor)
            ////bu durmda find'da çalışmayacağı için FirstOrDefault kullanırız
            ////FirstOrDefault varsa getirir yoksa null
            ////SingleOrDefault birden fazla kayıt varsa hata verir
            //var products = category.Urunlers;
            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.UrunAdi);
            //    Console.WriteLine("tedarikciler:" + product.Tedarikciler.SirketAdi);
            //}
            #endregion

            #region ThenBy, Skip, Take, All, Any, Single ve First Metotları

            #region ThenBy
            //ThenBy 2 order by kullanmak zrounda kaldığımızda, kullanılır
            //çünkü 2. order by 1. order by iptal edecektir

            //var products = db.Urunlers.OrderBy(x => x.KategoriID).ThenBy(x => x.UrunAdi).Select(x => new
            //{
            //    x.KategoriID,
            //    x.UrunAdi
            //});
            //ConsoleTable.From(products).Write();


            #endregion

            #region Skip ve Take
            //skip belirtilen sayı kadar ilk sonuçları atlar
            //take belirtilen sayı kadar sonucu alır
            //ayrı ayrı kullanılabilirler genelde beraber kullanılır
            //var products = db.Urunlers.OrderBy(x => x.KategoriID).Skip(12).Take(3).Select(x => new
            //{
            //    x.KategoriID,
            //    x.UrunAdi
            //});
            //ConsoleTable.From(products).Write();

            #endregion

            #region All ve Any
            //true ya da false döndürürl34
            //var result = db.Urunlers.All(x => x.BirimFiyati > 0);//tüm ürünlerin fiyatı 0'dan büyük mü 1 tane bile 0 olursa false
            //Console.WriteLine(result);
            //var result2 = db.Urunlers.Any(x => x.BirimFiyati > 100);//en az 1 tane 100de büyük varsa true
            //Console.WriteLine(result2);


            #endregion

            #region Single(),SingleOrDefault(),First(),FirstOrDefault
            //Single 1 den çok sonuç varsa ya da hiç sonuç yoksa hata verir
            //var result = db.Urunlers.Single(x => x.UrunID == 1);
            //SingleOrDefault
            //var result2 = db.Urunlers.SingleOrDefault(x => x.UrunID == 1);
            //First'te sonuç yoksa hata verir, varsa ilkini getirir
            //var result3 = db.Urunlers.First(x => x.UrunID == 1);
            //FirstOrDefault hiç hata vermez 
            #endregion

            #endregion

            Console.ReadLine();
        }
    }
}
