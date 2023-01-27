namespace ECwF.Tests
{
    public class AttributeDescriptorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAllDescriptor()
        {
            // arrange && act
            List<AttributeDescriptor> result = new List<AttributeDescriptor>();
            result.Add(AttributeDescriptor.ForInteger("remoteId", GetType()));
            result.Add(AttributeDescriptor.ForDateTime("createdDate", GetType()));
            result.Add(AttributeDescriptor.ForRemoteUser("createdBy", GetType()));
            result.Add(AttributeDescriptor.ForBoolean("isAdmin", GetType()));

            // assert
            var item1 = result[0] as DefaultDescriptor;
            var item2 = result[1] as DefaultDescriptor;
            var item3 = result[2] as ReferenceDescriptor;
            var item4 = result[3] as BooleanDescriptor;

            Assert.IsNotNull(item1);
            Assert.IsNotNull(item2);
            Assert.IsNotNull(item3);
            Assert.IsNotNull(item4);

            Assert.AreEqual("remoteId", item1.Name);
            Assert.AreEqual(GetType(), item1.InstanceType);
            Assert.AreEqual(typeof(int), item1.DataType);

            Assert.AreEqual("createdDate", item2.Name);
            Assert.AreEqual(GetType(), item2.InstanceType);
            Assert.AreEqual(typeof(DateTime), item2.DataType);

            Assert.AreEqual("createdBy", item3.Name);
            Assert.AreEqual(GetType(), item3.InstanceType);
            Assert.AreEqual(typeof(User), item3.DataType);
            Assert.AreEqual(typeof(RemoteUser), item3.ReferenceType);

            Assert.AreEqual("isAdmin", item4.Name);
            Assert.AreEqual(GetType(), item4.InstanceType);
            Assert.AreEqual(typeof(bool), item4.DataType);
        }
    }
}