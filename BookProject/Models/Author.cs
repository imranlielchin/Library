namespace BookProject.Models
{
    public class Author : IEquatable<Author>
    {
        static int counter = 0;
        public Author()
        {
            
            this.Id= ++counter;
        }
        public Author(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public bool Equals(Author? other)
        {
            
            return other?.Id == this.Id;
        }

        public override string ToString()
        {
            return $"{Id}|{Ad} {Soyad}"; 
        }
    }
}
