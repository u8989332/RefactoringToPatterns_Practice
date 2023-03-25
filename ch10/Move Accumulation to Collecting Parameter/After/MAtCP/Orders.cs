namespace MAtCP;

public class Orders
{
    public int OrderCount => _orders.Count;
    private readonly List<Order> _orders  = new List<Order>();

    public Order GetOrder(int index)
    {
        return _orders[index];
    }

    public void Add(Order order)
    {
        _orders.Add(order);
    }
}