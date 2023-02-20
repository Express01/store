using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests
{
    public class OrderTests
    {
        [Fact]
        public void Order_WithNullItems_ThrowsArgumensNullExeption()
        {
            Assert.Throws<ArgumentNullException>(() => new Order(1, null));
        }
        [Fact]
        public void TotalCount_WithEmptyItems_ReturnsZero()
        {
            var order = new Order(1, new OrderItem[0]);
            Assert.Equal(0, order.TotalCount);
        }
        [Fact]
        public void TotalPrice_WithEmptyItems_ReturnsZero()
        {
            var order = new Order(1, new OrderItem[0]);
            Assert.Equal(0m, order.TotalCount);
        }
        [Fact]
        public void TotalCount_WithNoEmptyItems_CalculatesTotalCount()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1,3,10m),
                new OrderItem(2,5,100m),
            });
            Assert.Equal(3 + 5, order.TotalCount);
        }
        [Fact]
        public void TotalPrice_WithNoEmptyItems_CalculatesTotalPrice()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1,3,10m),
                new OrderItem(2,5,100m),
            });
            Assert.Equal(3 * 10m + 5 * 100m, order.TotalPrice);
        }
        [Fact]
        public void GetItem_WithExistingItem_ReturnItem()
        {
            var order = new Order(1, new[]
           {
                new OrderItem(1,3,10m),
                new OrderItem(2,5,100m),
            });
            var orderItem = order.GetItem(1);
            Assert.Equal(3, orderItem.Count);
        }
        [Fact]
        public void GetItem_WithNonExistingItem_ThrowsInvalidOperationExeption()
        {
            var order = new Order(1, new[]
           {
                new OrderItem(1,3,10m),
                new OrderItem(2,5,100m),
            });
            Assert.Throws<InvalidOperationException>(() => order.GetItem(100));


        }
        [Fact]
        public void AddOrUpdateItem_WithExistingItem_UpdatesCount()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1,3,10m),
                new OrderItem(2,5,100m),
            });
            var book = new Book(1, null, null, null, null, 0m);
            order.AddOrUpdateItem(book, 10);
            Assert.Equal(13,order.GetItem(1).Count);
        }
        [Fact]
        public void AddOrUpdateItem_WithNonExistingItem_AddsCount()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1,3,10m),
                new OrderItem(2,5,100m),
            });
            var book = new Book(4, null, null, null, null, 0m);
            order.AddOrUpdateItem(book, 10);
           
            Assert.Equal(10, order.GetItem(4).Count);
        }
    }
}
