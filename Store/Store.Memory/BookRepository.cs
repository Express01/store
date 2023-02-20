using System.Threading.Tasks.Sources;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1,"ISBN 12312-56371","D. Knuth","Art of Programing","Cool bookghwdbhdfbhhdbf",7.19m),
            new Book(2,"ISBN 12312-56372","M. Fowler","Refactoring","Cool book23dsfsffggsda",12.45m),
            new Book(3,"ISBN 12312-56373","B. Kernighan, D. Rithie","C Programing Language","Cool bookggggggsdeefdfd",14.98m),

        };

        public Book[] GetAllById(IEnumerable<int> bookIds)
        {
            var foundBooks=from book in books
                           join bookId in bookIds on book.Id equals bookId select book;
            return foundBooks.ToArray();
        }

        public Book[] GetAllByIsbn(string isbn)
        {
           return books.Where(book=>book.Isbn == isbn).ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book=>book.Author.Contains (query)||book.Title.Contains(query)).ToArray();
        }

        public Book GetById(int id)
        {
            return books.Single(book=>book.Id == id);
        }
    }
}

