namespace ECwF;

public class ReferenceDescriptor : AttributeDescriptor
{
    internal Type ReferenceType { get; }

    internal ReferenceDescriptor(string name, Type instanceType, Type dataType, Type referenceType) : base(name, instanceType, dataType)
    {
        ReferenceType = referenceType;
    }
}