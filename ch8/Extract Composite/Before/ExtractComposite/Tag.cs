namespace ExtractComposite;

public abstract class Tag
{
    protected readonly string Name;

    protected Tag(string name)
    {
        Name = name;
    }

    public abstract string ToTagString();
}