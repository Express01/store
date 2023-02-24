using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Contractors                           //добаление служб сервисов доставки
{
    public interface IPaymentService
    {
      public   string UniqueCode { get;  }
       public string Title { get; }

        Form CreateForm(Order order);            //создаем первый экран

        Form MoveNextForm(int orderId,int step,IReadOnlyDictionary<string,string>values);
        OrderPayment GetPayment(Form form);

    }
}
