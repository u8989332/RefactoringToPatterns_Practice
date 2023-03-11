using System.Text;

namespace ExtractComposite;

public class Bracket : Tag
{
    public Bracket(string name) : base(name)
    {
    }

    public List<Tag> MyNodes { get; } = new();

    public override string ToTagString()
    {
        var sb = new StringBuilder();
        sb.Append(Name + ":");
        foreach (var tag in MyNodes)
        {
            sb.Append("[" + tag.ToTagString() + "]");
        }

        return sb.ToString();
    }
}