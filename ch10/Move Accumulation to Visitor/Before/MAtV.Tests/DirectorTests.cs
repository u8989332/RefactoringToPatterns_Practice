namespace MAtV.Tests
{
    public class DirectorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestDirector()
        {
            // arrange
            Director director = new Director();
            string expectResult = 
                "Bug resolved: 5" + Environment.NewLine +
                "Code line changed: 204" + Environment.NewLine +
                "Task on time? Yes" + Environment.NewLine +
                "Resource enough? No" + Environment.NewLine + 
                "Increase fans: 3167" + Environment.NewLine +
                "Transactions ok? Yes" + Environment.NewLine +
                "Balance: 9741526" + Environment.NewLine;

                // act
            var result = director.TodayWorkReport();

            // assert
            Assert.AreEqual(expectResult, result);
        }
    }
}