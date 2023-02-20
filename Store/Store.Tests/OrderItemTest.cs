using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests
{
    public class OrderItemTest
    {
        [Fact]
        public void OrderItem_WithZeroCount_ThrowsArgumentOutOfRangeExeption()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int count = 0;
                new OrderItem(1, count, 0m);
            });
        }
        [Fact]
        public void OrderItem_WithNegativeCount_ThrowsArgumentOutOfRangeExeption()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int count = -1;
                new OrderItem(1, count, 0m);
            });
        }
        [Fact]
        public void OrderItem_WithPositiveCount_SetsCount()
        {
            var orderItem = new OrderItem(1, 2, 3m);
            Assert.Equal(1, orderItem.BookId);
            Assert.Equal(2, orderItem.Count);
            Assert.Equal(3m, orderItem.Price);

        
        }
        [Fact]
        public void Count_WithNegativeValue_ThrowsArgumentOfRangeExeption()
        {
            var orderitem = new OrderItem(0, 5, 0m);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                orderitem.Count = -1;

            });

            
        }
        [Fact]
        public void Count_WithZeroValue_ThrowsArgumentOfRangeExeption()
        {
            var orderitem = new OrderItem(0, 5, 0m);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                orderitem.Count = 0;

            });


        }
        [Fact]
        public void Count_WithPosiiValue_SetsValue()
        {
            var orderitem = new OrderItem(0, 5, 0m);
            orderitem.Count = 10;
            Assert.Equal(10, orderitem.Count);
           


        }

    }
}
