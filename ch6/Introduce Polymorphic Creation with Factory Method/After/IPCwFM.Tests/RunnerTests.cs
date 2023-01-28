namespace IPCwFM.Tests
{
    public class RunnerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void XMLRunnerTest()
        {
            // arrange
            var runner = new XMLRunner();

            // act
            string result = runner.Run();
            
            // assert
            Assert.AreEqual("I am XMLorders<order>", result);
        }

        [Test]
        public void DOMRunnerTest()
        {
            // arrange
            var runner = new DOMRunner();

            // act
            string result = runner.Run();

            // assert
            Assert.AreEqual("I am DOMorders[order]", result);
        }
    }
}