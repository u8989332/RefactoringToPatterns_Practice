using System.Text;

namespace ExtractComposite;

public abstract class CompositeTag : Tag
{
    protected CompositeTag(string name) : base(name)
    {
    }

    public List<Tag> Tags { get; } = new();
    protected abstract string StartTag { get; }
    protected abstract string EndTag { get; }

    public override string ToTagString()
    {
        var sb = new StringBuilder();
        sb.Append(Name + ":");
        foreach (var tag in Tags)
        {
            sb.Append(StartTag + tag.ToTagString() + EndTag);
        }

        return sb.ToString();
    }
}