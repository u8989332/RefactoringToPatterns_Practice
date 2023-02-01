namespace ComposedMethod.Tests
{
    public class MyListTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestMyListAddElements()
        {
            // arrange
            MyList list = new MyList(false);
            TestObject oneObj = new TestObject();
            
            // act
            list.Add(1);
            list.Add("2");
            list.Add(true);
            list.Add(oneObj);
            var result = list.Elements;

            // assert
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual("2", result[1]);
            Assert.AreEqual(true, result[2]);
            Assert.AreEqual(oneObj, result[3]);
        }
    }

    public class TestObject
    {

    }
}