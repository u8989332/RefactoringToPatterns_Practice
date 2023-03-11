using System.Collections.ObjectModel;

namespace ROMDwC;

public class CompositeSpec : Spec
{
    private readonly List<Spec> _specs = new List<Spec>();
    public IReadOnlyList<Spec> Specs => new ReadOnlyCollection<Spec>(_specs);

    public void Add(Spec spec)
    {
        _specs.Add(spec);
    }

    public override bool IsSatisfiedBy(Product product)
    {
        return _specs.All(x => x.IsSatisfiedBy(product));
    }
}