namespace RHCNwO.Tests
{
    public class ReportTests
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

            // act
            var result = director.AcceptContent;

            // assert
            Assert.AreEqual("New Report: Urgent", result);
        }

        [Test]
        public void TestManager()
        {
            // arrange
            Manager manager = new Manager();

            // act
            var result = manager.AcceptContent;

            // assert
            Assert.AreEqual("Process Report: Urgent", result);
        }
    }
}