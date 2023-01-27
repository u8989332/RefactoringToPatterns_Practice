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

        public static AttributeDescriptor ForInteger(string name, Type instanceType)
        {
            return new DefaultDescriptor(name, instanceType, typeof(int));
        }

        public static AttributeDescriptor ForDateTime(string name, Type instanceType)
        {
            return new DefaultDescriptor(name, instanceType, typeof(DateTime));
        }

        public static AttributeDescriptor ForRemoteUser(string name, Type instanceType)
        {
            return new ReferenceDescriptor(name, instanceType, typeof(User), typeof(RemoteUser));
        }

        public static AttributeDescriptor ForBoolean(string name, Type instanceType)
        {
            return new BooleanDescriptor(name, instanceType);
        }
    }
}
