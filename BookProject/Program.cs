using BookProject.Enums;
using BookProject.Helpers;
using BookProject.Managers;
using BookProject.Models;
using System.ComponentModel;

namespace BookProject
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            AuthorManager authorManager=new AuthorManager();
            BookManager bookManager = new BookManager();




            MenuTypes selectedMenu;
            
            
            Author author;
            Book book;
            int id;




            l1:
            Console.WriteLine("### Edeceyiniz emeliyyati siytahidan secin:");
            selectedMenu = EnumHelper.ReadEnum<MenuTypes>("Menu:");

            switch (selectedMenu)
            {
                case MenuTypes.MuellifiElaveEtmek:
                    author = new Author();
                    author.Ad = PrimiteHelper.ReadString("Muellifin Adi:");
                    author.Soyad = PrimiteHelper.ReadString("Muellifin Soyadi:");
                    authorManager.Add(author);

                    Console.Clear();
                    
                    goto l1;


                case MenuTypes.MuellifiRedakte:
                    Console.WriteLine("Redakte etmek istediyiniz muellifi secin:");
                    foreach (var item in authorManager)
                    {
                        Console.WriteLine(item);
                    }
                    id = PrimiteHelper.ReadInt("Muellif id");

                    if(id == 0)
             
                     goto l1;
                    

                    author=authorManager.GetById(id);

                    if(author == null)
                    {
                        Console.Clear();
                        goto case MenuTypes.MuellifiRedakte;
                    }
                    author.Ad = PrimiteHelper.ReadString("Muellifin Adi:");
                    author.Soyad = PrimiteHelper.ReadString("Muellifin Soyadi:");
                    Console.Clear();
                    goto case MenuTypes.MuellifinHerBiri;
                    


                case MenuTypes.MuellifiSilmek:
                    Console.WriteLine("Silmek istediyiniz muellifi secin:");
                    foreach (var item in authorManager)
                    {
                        Console.WriteLine(item);
                    }
                    id = PrimiteHelper.ReadInt("Muellif id");
                    author = authorManager.GetById(id);
                    if (author == null)
                    {
                        Console.Clear();
                        goto case MenuTypes.MuellifiSilmek;
                    }
                    authorManager.Remove(author);
                    Console.Clear();
                    goto case MenuTypes.MuellifinHerBiri;
                    


                case MenuTypes.MuellifinHerBiri:
                    Console.Clear();
                    foreach (var item in authorManager)
                    {
                        Console.WriteLine(item);
                    }
             
                    goto l1;


                case MenuTypes.MuellifinId:

                    id = PrimiteHelper.ReadInt("Muellif id");

                    if (id == 0)
                    {
                        Console.Clear();
                       
                        goto l1;
                    }

                    author = authorManager.GetById(id);
                    if (author == null)
                    {
                        Console.Clear();
                        Console.WriteLine("Tapilmadi...");
                        goto case MenuTypes.MuellifinId;
                    }
                    Console.WriteLine(author);
                    goto l1;


                case MenuTypes.MuellifinAdiniAxtarmaq:
                    string name = PrimiteHelper.ReadString("Axtaris ucun adi en az 3 herfini qeyd edin:");
                    var data = authorManager.FindByName(name);
                    if (data.Length == 0)
                    {
                        Console.WriteLine("Tapilmadi...");

                    }
                    foreach (var item in data)
                    {
                        Console.WriteLine(item);
                    }

                    goto l1;


                case MenuTypes.KitabElaveEtmek:
                    book = new Book();
                    book.Ad = PrimiteHelper.ReadString("Kitabin Adi:");
                    book.MuellifId = PrimiteHelper.ReadInt("Muellifin Idsi");
                    book.SehifeSayi = PrimiteHelper.ReadInt("Sehife sayi");
                    book.Qiymet = PrimiteHelper.ReadInt("Qiymeti");
                    var selectedJanr = EnumHelper.ReadEnum<Genre>("Janri secin");


                    bookManager.Add(book);

                    Console.Clear();
                    Console.WriteLine("### Edeceyiniz emeliyyati siytahidan secin:");
                    selectedMenu = EnumHelper.ReadEnum<MenuTypes>("Menu:");

                    goto l1;


                case MenuTypes.KitabiRedakte:
                    Console.WriteLine("Redakte etmek istediyiniz kitabi secin:");
                    foreach (var item in bookManager)
                    {
                        Console.WriteLine(item);
                    }
                    id = PrimiteHelper.ReadInt("Kitab id");

                    if (id == 0)

                        goto l1;


                    book = bookManager.GetById(id);

                    if (book == null)
                    {
                        Console.Clear();
                        goto case MenuTypes.MuellifiRedakte;
                    }
                    book.Ad = PrimiteHelper.ReadString("Kitabin Adi");
                    book.MuellifId = PrimiteHelper.ReadInt("Kitabin MuellifIdsi Adi");
                    book.SehifeSayi = PrimiteHelper.ReadInt("Kitabin Sehife sayi");
                    book.Qiymet = PrimiteHelper.ReadInt("Kitabin qiymeti");
                    book.Janr = EnumHelper.ReadEnum<Genre>("Janri secin");
                    Console.Clear();
                    goto case MenuTypes.MuellifinHerBiri;


                case MenuTypes.KitabiSilmek:

                    Console.WriteLine("Silmek istediyiniz kitabi secin:");
                    foreach (var item in bookManager)
                    {
                        Console.WriteLine(item);
                    }
                    id = PrimiteHelper.ReadInt("Kitab id");
                    book = bookManager.GetById(id);
                    if (book == null)
                    {
                        Console.Clear();
                        goto case MenuTypes.KitabiSilmek;
                    }
                    bookManager.Remove(book);
                    Console.Clear();
                    goto case MenuTypes.KitabinHerBiri;


                case MenuTypes.KitabinHerBiri:
                    Console.Clear();
                    foreach (var item in bookManager)
                    {
                        Console.WriteLine(item);
                    }

                    goto l1;


                case MenuTypes.KitabinId:
                    id = PrimiteHelper.ReadInt("Kitab id");

                    if (id == 0)
                    {
                        Console.Clear();

                        goto l1;
                    }

                    book = bookManager.GetById(id);
                    if (book == null)
                    {
                        Console.Clear();
                        Console.WriteLine("Tapilmadi...");
                        goto case MenuTypes.MuellifinId;
                    }
                    Console.WriteLine(book);
                    goto l1;


                case MenuTypes.KitabinAdiniAxtarmaq:
                    string bookName = PrimiteHelper.ReadString("Axtaris ucun adi en az 3 herfini qeyd edin:");
                    var data = bookManager.FindByName(bookName);
                    if (data.Length == 0)
                    {
                        Console.WriteLine("Tapilmadi...");

                    }
                    foreach (var item in data)
                    {
                        Console.WriteLine(item);
                    }

                    goto l1;




            }





        }
    }
}