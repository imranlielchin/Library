using BookProject.Infrastrukturlar;
using BookProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject.Managers
{
    public class BookManager : IManager<Book>,IEnumerable<Book>
    {
        Book[] data=new Book[0];
        public void Add(Book item)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = item;
        }

        public void Edit(Book item)
        {
            var index=Array.IndexOf(data, item);
            if (index == -1)
                return;

            var tapdigimiz = data[index];
            tapdigimiz.Ad = item.Ad;
            tapdigimiz.MuellifId = item.MuellifId;
            tapdigimiz.SehifeSayi= item.SehifeSayi;
            tapdigimiz.Janr= item.Janr;
            tapdigimiz.Qiymet=item.Qiymet;

        }

        public void Remove(Book item)
        {
            int index = Array.IndexOf(data, item);
            if (index == -1)
                return;
            int len = data.Length - 1;
            Array.Resize(ref data, len);
            for (int i = index; i < len; i++)
            {
                data[i] = data[i + 1];
            }
        }

        public Book this[int index]
        {
            get
            {
                return data[index];
            }
        }


        public IEnumerator<Book> GetEnumerator()
        {
            foreach (Book item in data)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public Book GetById(int id)
        {
                return Array.Find(data, item => item.Id == id);
        }

        public Book[] FindByName(string name)
        {
            return Array.FindAll(data, item => item.Ad.ToLower().StartsWith(name.ToLower()));
        }
    }
}
