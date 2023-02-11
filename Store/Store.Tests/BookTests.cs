namespace Store.Tests
{
    public class BookTests
    {
        [Fact]
        public void IsIsbn_withNull_ReturnFalse()
        {
            bool actual=Book.IsIsbn(null);    
            Assert.False(actual);
        }
        [Fact]
        public void IsIsbn_withInvalidIsbn_ReturnFalse()
        {
            bool actual = Book.IsIsbn("   ");
            Assert.False(actual);
        }
        [Fact]
        public void IsIsbn_withBlankString_ReturnFalse()
        {
            bool actual = Book.IsIsbn("ISBN 123");
            Assert.False(actual);
        }
        [Fact]
        public void IsIsbn_withIsbn10_ReturnTrue()
        {
            bool actual = Book.IsIsbn("IsBn 123-456-789 0");
            Assert.True(actual);
        }
        [Fact]
        public void IsIsbn_withIsbn13_ReturnTrue()
        {
            bool actual = Book.IsIsbn("IsBn 123-456-789 0123");
            Assert.True(actual);
        }
        [Fact]
        public void IsIsbn_WithTrashStart_ReturnFalse()
        {
            bool actual = Book.IsIsbn("xxx IsBn 123-456-789 012   yyy");
            Assert.False(actual);
        }

    }
}