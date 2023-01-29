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
    }
}