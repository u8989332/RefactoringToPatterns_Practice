using System.Text;

namespace RITwC
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
            xml.Append("<orders>");
            for (int i = 0; i < _orders.OrderCount; ++i)
            {
                Order order = _orders.GetOrder(i);
                xml.Append("<order");
                xml.Append(" id='");
                xml.Append(order.OrderId);
                xml.Append("'>");
                WriteProductsTo(xml, order);
                xml.Append("</order>");
            }
            xml.Append("</orders>");
        }

        private void WriteProductsTo(StringBuilder xml, Order order)
        {
            for (int j = 0; j < order.ProductCount; ++j)
            {
                Product product = order.GetProduct(j);
                xml.Append("<product");
                xml.Append(" id='");
                xml.Append(product.Id);
                xml.Append("'");
                xml.Append(" color='");
                xml.Append(ColorFor(product));
                xml.Append("'");
                if (product.Size != ProductSize.NOT_APPLICABLE)
                {
                    xml.Append(" size='");
                    xml.Append(SizeFor(product));
                    xml.Append("'");
                }

                xml.Append(">");
                WritePriceTo(xml, product);
                xml.Append(product.Name);
                xml.Append("</product>");
            }
        }

        private string SizeFor(Product product)
        {
            return "medium";
        }

        private void WritePriceTo(StringBuilder xml, Product product)
        {
            xml.Append("<price");
            xml.Append(" currency='");
            xml.Append(CurrencyFor(product));
            xml.Append("'>");
            xml.Append(product.Price);
            xml.Append("</price>");
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
