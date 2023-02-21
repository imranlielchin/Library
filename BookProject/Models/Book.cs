using BookProject.Enums;

namespace BookProject.Models
{
    public class Book : IEquatable<Book>
    {

        static int counter = 0;
        public Book()
        {
            this.Id = ++counter;
        }
        public int Id { get; private set; }
        public string Ad { get; set; }
        public Genre Janr { get; set; }
        public int MuellifId { get; set; }
        public int SehifeSayi { get; set; }
        public decimal Qiymet { get; set; }

        public bool Equals(Book? other)
        {

            return other?.Id == this.Id;
        }

        public override string ToString()
        {
            return $"{Id} | {Ad} | {Janr} | {MuellifId} | {SehifeSayi} | {Qiymet}"; 
        }


    }
}
