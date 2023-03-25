using System.Text;

namespace MAtCP
{
    public class OrdersWriter
    {
        private readonly Orders _orders;

        public OrdersWriter(Orders orders)
        {
            _orders = orders;
        }

        public string GetContent()
        {
            StringBuilder xml = new StringBuilder();
            WriteOrderTo(xml);
            return xml.ToString();
        }

        private void WriteOrderTo(StringBuilder xml)
        {
            TagNode ordersTag = new TagNode("orders");
            for (int i = 0; i < _orders.OrderCount; ++i)
            {
                Order order = _orders.GetOrder(i);
                TagNode orderTag = new TagNode("order");
                orderTag.AddAttribute("id", order.OrderId);
                WriteProductsTo(orderTag, order);
                ordersTag.Add(orderTag);
            }
            xml.Append(ordersTag);
        }

        private void WriteProductsTo(TagNode orderTag, Order order)
        {
            for (int j = 0; j < order.ProductCount; ++j)
            {
                Product product = order.GetProduct(j);
                TagNode productTag = new TagNode("product");
                productTag.AddAttribute("id", product.Id.ToString());
                productTag.AddAttribute("color", ColorFor(product));
                if (product.Size != ProductSize.NOT_APPLICABLE)
                {
                    productTag.AddAttribute("size", SizeFor(product));
                }

                WritePriceTo(productTag, product);
                productTag.AddValue(product.Name);
                orderTag.Add(productTag);
            }
        }

        private string SizeFor(Product product)
        {
            return "medium";
        }

        private void WritePriceTo(TagNode productTag, Product product)
        {
            TagNode priceNode = new TagNode("price");
            priceNode.AddAttribute("currency", CurrencyFor(product));
            priceNode.AddValue(product.Price.ToString());
            productTag.Add(priceNode);
        }

        private string CurrencyFor(Product product)
        {
            return "USD";
        }

        private string ColorFor(Product product)
        {
            return "red";
        }
    }
}
