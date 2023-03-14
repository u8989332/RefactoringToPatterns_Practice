namespace UIwA.Tests
{
    public class BuilderTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestXMLBuilderBuildChildSibling()
        {
            // arrange
            string expectedXml =
                "<flavors name='F_Top'><flavor1 name='F1'>IDE1</flavor1><flavor2 name='F2'>IDE2</flavor2></flavors>";

            // act
            var builder = new XMLBuilder("flavors");
            builder.AddAttribute("name", "F_Top");
            builder.AddChild("flavor1");
            builder.AddAttribute("name", "F1");
            builder.AddValue("IDE1");
            builder.AddSibling("flavor2");
            builder.AddAttribute("name", "F2");
            builder.AddValue("IDE2");
            string actualXml = builder.ToXml();

            // assert
            Assert.AreEqual(expectedXml, actualXml);
        }

        [Test]
        public void TestDOMBuilderBuildChildSibling()
        {
            // arrange
            string expectedXml =
                "<flavors name='F_Top'><flavor1 name='F1'>IDE1</flavor1><flavor2 name='F2'>IDE2</flavor2></flavors>";

            // act
            var builder = new DOMBuilder("flavors");
            builder.AddAttribute("name", "F_Top");
            builder.AddBelow("flavor1");
            builder.AddAttribute("name", "F1");
            builder.AddValue("IDE1");
            builder.AddBeside("flavor2");
            builder.AddAttribute("name", "F2");
            builder.AddValue("IDE2");
            string actualXml = builder.ToXml();

            // assert
            Assert.AreEqual(expectedXml, actualXml);
        }
    }
}