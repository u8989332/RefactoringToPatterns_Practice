namespace ECwF;

public class BooleanDescriptor : AttributeDescriptor
{
    public BooleanDescriptor(string name, Type instanceType) : base(name, instanceType, typeof(bool))
    {
    }
}