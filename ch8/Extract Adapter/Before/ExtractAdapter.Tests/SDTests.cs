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
            Query q = new Query();
            string server = "127.0.0.1";
            string user = "admin";
            string password = "1234";

            // act
            q.Login(server, user, password);
            q.DoQuery();
            var sd52 = q.Sd52;
            var sdSession = q.SdSession;
            var sdQuery = q.SdQuery;
            var sdLoginSession = q.SdLoginSession;

            // assert
            Assert.IsNull(sdLoginSession);
            Assert.IsFalse(sd52);
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
            Query q = new Query();
            string server = "127.0.0.1";
            string user = "admin";
            string password = "1234";
            string sdConfigFileName = "test.txt";

            // act
            q.Login(server, user, password, sdConfigFileName);
            q.DoQuery();
            var sd52 = q.Sd52;
            var sdSession = q.SdSession;
            var sdQuery = q.SdQuery;
            var sdLoginSession = q.SdLoginSession;

            // assert
            Assert.IsNull(sdSession);
            Assert.IsTrue(sd52);
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