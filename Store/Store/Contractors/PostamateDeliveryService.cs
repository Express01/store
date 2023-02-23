using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Store.Contractors
{
    public class PostamateDeliveryService : IDeliveryService
    {
        private static IReadOnlyDictionary<string, string> cities = new Dictionary<string, string>
        {
            { "1", "Минск" },
            { "2", "Бобруйск" },
        };

        private static IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> postamates = new Dictionary<string, IReadOnlyDictionary<string, string>>
        {
            {
                "1",
                new Dictionary<string, string>
                {
                    { "1", "Партизанский проспект" },
                    { "2", "Проспект победителей" },
                    { "3", "Денисовская улица" },
                }
            },
            {
                "2",
                new Dictionary<string, string>
                {
                    { "4", " Орджоникидзе улица" },
                    { "5", "Советская улица" },
                    { "6", "Комсомольская улица" },
                }
            }
        };
        public string UniqueCode => "Postamate";

        public string Title => "Доставка через постаматы в Минске и Бобруйске";

        public Form CreateForm(Order order)
        {
            return Form.CreateFirst(Name)
                      .AddParameter("orderId", order.Id.ToString())
                      .AddField(new SelectionField("Город", "city", "1", cities));
        }

        public Form MoveNext(int orderId, int step, IReadOnlyDictionary<string, string> values)
        {
            if (step == 1)
            {
                if (values["city"] == "1")
                {
                    return Form.CreateNext(Name, 2, values)
                               .AddField(new SelectionField("Постамат", "postamate", "1", postamates["1"]));
                }
                else if (values["city"] == "2")
                {
                    return Form.CreateNext(Name, 2, values)
                               .AddField(new SelectionField("Постамат", "postamate", "4", postamates["2"]));
                }
                else
                    throw new InvalidOperationException("Invalid postamate city.");
            }
            else if (step == 2)
            {
                return Form.CreateLast(Name, 3, values);
            }
            else
                throw new InvalidOperationException("Invalid postamate step.");
        }
        public OrderDelivery GetDelivery(Form form)
        {
            if (form.ServiceName != Name || !form.IsFinal)
                throw new InvalidOperationException("Invalid form.");

            var cityId = form.Parameters["city"];
            var cityName = cities[cityId];
            var postamateId = form.Parameters["postamate"];
            var postamateName = postamates[cityId][postamateId];

            var parameters = new Dictionary<string, string>
            {
                { nameof(cityId), cityId },
                { nameof(cityName), cityName },
                { nameof(postamateId), postamateId },
                { nameof(postamateName), postamateName },
            };

            var description = $"Город: {cityName}\nПостамат: {postamateName}";

            return new OrderDelivery(Name, description, 150m, parameters);
        }
    }
}
