using System.Text;

namespace ExtractComposite;

public class Bracket : CompositeTag
{
    public Bracket(string name) : base(name)
    {
    }


    protected override string StartTag => "[";
    protected override string EndTag => "]";
}