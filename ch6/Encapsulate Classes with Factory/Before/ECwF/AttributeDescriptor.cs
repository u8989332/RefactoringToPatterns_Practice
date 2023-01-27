namespace ECwF
{
    public abstract class AttributeDescriptor
    {
        internal string Name { get; }
        internal Type InstanceType { get; }
        internal Type DataType { get; }

        protected AttributeDescriptor(string name, Type instanceType, Type dataType)
        {
            Name = name;
            InstanceType = instanceType;
            DataType = dataType;
        }
    }
}
