namespace ECwB.Tests
{
    [TestFixture]
    public class TagBuilderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestBuildOneNode()
        {
            // arrange
            string expectedXml =
                "<flavors/>";

            // act
            string actualXml = new TagBuilder("flavors").ToXml();

            // assert
            Assert.AreEqual(expectedXml, actualXml);
        }

        [Test]
        public void TestBuildOneChild()
        {
            // arrange
            string expectedXml =
                "<flavors><flavor/></flavors>";

            // act
            var builder = new TagBuilder("flavors");
            builder.AddChild("flavor");
            string actualXml = builder.ToXml();

            // assert
            Assert.AreEqual(expectedXml, actualXml);
        }

        [Test]
        public void TestBuildChildrenOfChildren()
        {
            // arrange
            string expectedXml =
                "<flavors><flavor><requirements><requirement/></requirements></flavor></flavors>";

            // act
            var builder = new TagBuilder("flavors");
            builder.AddChild("flavor");
            builder.AddChild("requirements");
            builder.AddChild("requirement");
            string actualXml = builder.ToXml();

            // assert
            Assert.AreEqual(expectedXml, actualXml);
        }

        [Test]
        public void TestBuildSibling()
        {
            // arrange
            string expectedXml =
                "<flavors><flavor1/><flavor2/></flavors>";

            // act
            var builder = new TagBuilder("flavors");
            builder.AddChild("flavor1");
            builder.AddSibling("flavor2");
            string actualXml = builder.ToXml();

            // assert
            Assert.AreEqual(expectedXml, actualXml);
        }

        [Test]
        public void TestParents()
        {
            // arrange
            TagNode root = new TagNode("root");
            TagNode childNode = new TagNode("child");

            // act
            root.Add(childNode);

            // assert
            Assert.IsNull(root.Parent);
            Assert.AreEqual(root, childNode.Parent);
            Assert.AreEqual(root.TagName, childNode.Parent.TagName);
        }

        [Test]
        public void TestParentNameNotFound()
        {
            // assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                // arrange && act
                TagBuilder builder = new TagBuilder("flavors");
                for (int i = 0; i < 2; ++i)
                {
                    builder.AddToParent("fllllavors", "flavor");
                    builder.AddChild("requirements");
                    builder.AddChild("requirement");
                }
            }, "Missing parent tag: fllllavors");
        }

        [Test]
        public void TestRepeatingChildrenAndGrandChildren()
        {
            // arrange
            string expectedXml =
                "<flavors><flavor>" + 
                "<requirements>" + 
                "<requirement/>" +
                "</requirements>" +
                "</flavor>"  + 
                "<flavor>" +
                "<requirements>" +
                "<requirement/>" +
                "</requirements>" +
                "</flavor>" + "</flavors>";

            // act
            var builder = new TagBuilder("flavors");
            for (int i = 0; i < 2; ++i)
            {
                builder.AddToParent("flavors", "flavor");
                builder.AddChild("requirements");
                builder.AddChild("requirement");
            }
            
            string actualXml = builder.ToXml();

            // assert
            Assert.AreEqual(expectedXml, actualXml);
        }

        [Test]
        public void TestAttributesAndValues()
        {
            // arrange
            string expectedXml =
                "<flavor name='Test-Driven Development'>" +
                "<requirements>" +
                "<requirement type='hardware'>" +
                "1 computer for every 2 participants" +
                "</requirement>" +
                "<requirement type='software'>" +
                "IDE" +
                "</requirement>" +
                "</requirements>" +
                "</flavor>";

            // act
            var builder = new TagBuilder("flavor");
            builder.AddAttribute("name", "Test-Driven Development");
            builder.AddChild("requirements");
            builder.AddToParent("requirements", "requirement");
            builder.AddAttribute("type", "hardware");
            builder.AddValue("1 computer for every 2 participants");
            builder.AddToParent("requirements", "requirement");
            builder.AddAttribute("type", "software");
            builder.AddValue("IDE");

            string actualXml = builder.ToXml();

            // assert
            Assert.AreEqual(expectedXml, actualXml);
        }

        [Test]
        public void TestToStringBufferSize()
        {
            // arrange
            string expectedXml =
                "<requirements>" +
                "<requirement type='software'>" +
                "IDE" +
                "</requirement>" +
                "</requirements>";

            // act
            var builder = new TagBuilder("requirements");
            builder.AddChild("requirement");
            builder.AddAttribute("type", "software");
            builder.AddValue("IDE");

            string actualXml = builder.ToXml();
            int stringSize = actualXml.Length;
            int computedSize = builder.BufferSize;

            // assert
            Assert.AreEqual(expectedXml, actualXml);
            Assert.AreEqual(stringSize, computedSize);
        }
    }
}