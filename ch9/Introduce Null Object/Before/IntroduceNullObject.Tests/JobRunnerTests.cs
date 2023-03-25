namespace IntroduceNullObject.Tests
{
    public class JobRunnerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestRunner()
        {
            // arrange
            JobRunner jr = new JobRunner();

            // act
            var result1 = jr.Start();
            var result2 = jr.AnySetting();
            var result3 = jr.Stop();
            jr.Initialize();
            var result4 = jr.Start();
            var result5 = jr.AnySetting();
            var result6 = jr.Stop();

            // assert
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
            Assert.IsTrue(result4);
            Assert.IsTrue(result5);
            Assert.IsTrue(result6);
        }
    }
}