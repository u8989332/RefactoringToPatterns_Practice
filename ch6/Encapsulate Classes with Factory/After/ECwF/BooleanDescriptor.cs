namespace ECwF;

public class BooleanDescriptor : AttributeDescriptor
{
    internal BooleanDescriptor(string name, Type instanceType) : base(name, instanceType, typeof(bool))
    {
    }
}