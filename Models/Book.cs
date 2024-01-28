namespace BookApi.Models
{
    public class Book {
        public string Title {get; set;}
        public int ReleaseYear {get; set;}
        public string Author {get; set;}
        public string Genre {get; set;}

        public override string ToString() {
            return $"{Title}, {Author}, {Genre}, {ReleaseYear}";    
        }
    }
}