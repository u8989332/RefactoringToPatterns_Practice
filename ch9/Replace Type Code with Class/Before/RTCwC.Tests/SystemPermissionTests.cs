namespace RTCwC.Tests
{
    public class SystemPermissionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestDefaultState()
        {
            // arrange
            SystemPermission sp = new SystemPermission();

            // act
            var result = sp.State;
            var granted = sp.IsGranted();

            // assert
            Assert.AreEqual("REQUESTED", result);
            Assert.IsFalse(granted);
        }

        [Test]
        public void TestClaimedState()
        {
            // arrange
            SystemPermission sp = new SystemPermission();

            // act
            sp.Claimed();
            var result = sp.State;
            var granted = sp.IsGranted();

            // assert
            Assert.AreEqual("CLAIMED", result);
            Assert.IsFalse(granted);
        }

        [Test]
        public void TestDeniedState()
        {
            // arrange
            SystemPermission sp = new SystemPermission();

            // act
            sp.Claimed();
            sp.Denied();
            var result = sp.State;
            var granted = sp.IsGranted();

            // assert
            Assert.AreEqual("DENIED", result);
            Assert.IsFalse(granted);
        }

        [Test]
        public void TestGrantedState()
        {
            // arrange
            SystemPermission sp = new SystemPermission();

            // act
            sp.Claimed();
            sp.Granted();
            var result = sp.State;
            var granted = sp.IsGranted();

            // assert
            Assert.AreEqual("GRANTED", result);
            Assert.IsTrue(granted);
        }
    }
}