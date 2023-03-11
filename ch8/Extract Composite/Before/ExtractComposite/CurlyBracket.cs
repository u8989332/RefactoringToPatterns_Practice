using System.Text;

namespace ExtractComposite;

public class CurlyBracket : Tag
{
    public CurlyBracket(string name) : base(name)
    {
    }

    public List<Tag> Tags { get; } = new();

    public override string ToTagString()
    {
        var sb = new StringBuilder();
        sb.Append(Name + ":");
        foreach (var tag in Tags)
        {
            sb.Append("{" + tag.ToTagString() + "}");
        }

        return sb.ToString();
    }
}