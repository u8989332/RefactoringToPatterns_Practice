namespace ExtractComposite.Tests
{
    public class TagTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAllTags()
        {
            // arrange
            Bracket b1 = new Bracket("B1");
            CurlyBracket c1 = new CurlyBracket("C1");
            Bracket b2 = new Bracket("B2");
            CurlyBracket c2 = new CurlyBracket("C2");
            b1.MyNodes.Add(c1);
            c1.Tags.Add(b2);
            c1.Tags.Add(c2);

            // act
            var result = b1.ToTagString();

            // assert
            Assert.AreEqual("B1:[C1:{B2:}{C2:}]", result);
        }
    }
}