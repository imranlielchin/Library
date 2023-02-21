
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
    public class AuthorManager : IManager<Author>,IEnumerable<Author>
    {
        Author[] data = new Author[0];
        public void Add(Author item)
        {
           int len = data.Length;
           Array.Resize(ref data, len + 1);
           data[len] = item;
        }

        public void Edit(Author item)
        {
            var index = Array.IndexOf(data, item);
            if (index == -1)
                return;

            var tapdigimiz = data[index];
            tapdigimiz.Ad = item.Ad;
            tapdigimiz.Soyad= item.Soyad;
        }

        public void Remove(Author item)
        {
             int index=Array.IndexOf(data, item);
            if (index == -1)
                return;
            int len = data.Length - 1;

            for (int i=index; i< len; i++)
            {
                data[i] = data[i+1];
            }
            Array.Resize(ref data, len);
        }



        public Author this[int index]
        {
            get
            {
                return data[index];
            }
        }


        public IEnumerator<Author> GetEnumerator()
        {
            foreach (Author item in data)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public Author GetById(int id)
        {
            return Array.Find(data, item => item.Id == id);
        }

        public Author[] FindByName(string name)
        {
            return Array.FindAll(data, item => item.Ad.ToLower().StartsWith(name.ToLower()));
        }
    }
}
