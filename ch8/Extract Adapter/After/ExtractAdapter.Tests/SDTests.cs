namespace ExtractAdapter.Tests
{
    public class SDTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSD51Query()
        {
            // arrange
            IQuery q = new QuerySd51();
            string server = "127.0.0.1";
            string user = "admin";
            string password = "1234";

            // act
            q.Login(server, user, password);
            q.DoQuery();
            var castQuery = q as QuerySd51;
            var sdSession = castQuery.SdSession;
            var sdQuery = castQuery.SdQuery;

            // assert
            Assert.AreEqual(server, sdSession.Server);
            Assert.AreEqual(user, sdSession.User);
            Assert.AreEqual(password, sdSession.Password);
            Assert.AreEqual(server, sdQuery.Server);
            Assert.AreEqual(user, sdQuery.User);
            Assert.AreEqual(password, sdQuery.Password);
            Assert.AreEqual("QEURY", sdQuery.Query);
        }

        [Test]
        public void TestSD52Query()
        {
            // arrange
           
            string server = "127.0.0.1";
            string user = "admin";
            string password = "1234";
            string sdConfigFileName = "test.txt";
            IQuery q = new QuerySd52(sdConfigFileName);

            // act
            q.Login(server, user, password);
            q.DoQuery();
            var castQuery = q as QuerySd52;
            var sdQuery = castQuery.SdQuery;
            var sdLoginSession = castQuery.SdLoginSession;

            // assert
            Assert.AreEqual(server, sdLoginSession.Server);
            Assert.AreEqual(user, sdLoginSession.User);
            Assert.AreEqual(password, sdLoginSession.Password);
            Assert.AreEqual(sdConfigFileName, sdLoginSession.SdConfigFileName);
            Assert.AreEqual(server, sdQuery.Server);
            Assert.AreEqual(user, sdQuery.User);
            Assert.AreEqual(password, sdQuery.Password);
            Assert.AreEqual("QEURY", sdQuery.Query);
        }
    }
}