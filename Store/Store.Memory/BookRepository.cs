namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1,"Art of Programing"),
            new Book(1,"Refactoring"),
            new Book(1,"C Programing Language"),

        };
        public Book[] GetAllByTitle(string titlePart)
        {
            return books.Where(book=>book.Title.Contains(titlePart)).ToArray();
        }
    }
}