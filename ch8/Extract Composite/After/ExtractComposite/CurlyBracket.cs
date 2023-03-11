using System.Text;

namespace ExtractComposite;

public class CurlyBracket : CompositeTag
{
    public CurlyBracket(string name) : base(name)
    {
    }

    protected override string StartTag => "{";
    protected override string EndTag => "}";
}