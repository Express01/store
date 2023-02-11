namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1,"ISBN 12312-56371","D. Knuth","Art of Programing"),
            new Book(1,"ISBN 12312-56372","M. Fowler","Refactoring"),
            new Book(1,"ISBN 12312-56373","B. Kernighan, D. Rithie","C Programing Language"),

        };

        public Book[] GetAllByIsbn(string isbn)
        {
           return books.Where(book=>book.Isbn == isbn).ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book=>book.Author.Contains (query)||book.Title.Contains(query)).ToArray();
        }
    }
}