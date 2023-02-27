using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Contractors                           //добаление служб сервисов доставки
{
    public interface IDeliveryService                  //изменено
    {
        string Name { get; }

        string Title { get; }

        Form FirstForm(Order order);

        Form NextForm(int step, IReadOnlyDictionary<string, string> values);

        OrderDelivery GetDelivery(Form form);

    }
}
