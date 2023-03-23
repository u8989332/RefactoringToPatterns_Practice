namespace LIwS.Tests
{
    public class PermissionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GrantedByTest()
        {
            SystemUser user = new SystemUser();
            SystemProfile profile = new SystemProfile();
            SystemAdmin admin = new SystemAdmin();
            SystemPermission permission = new SystemPermission(admin, user, profile);
            permission.GrantedBy(admin);
            Assert.AreEqual(PermissionRequested.State, permission.PermissionState);
            Assert.AreEqual(false, permission.IsGranted);
            permission.ClaimedBy(admin);
            permission.GrantedBy(admin);
            Assert.AreEqual(PermissionGranted.State, permission.PermissionState);
            Assert.AreEqual(true, permission.IsGranted);
        }
    }
}