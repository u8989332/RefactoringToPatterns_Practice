namespace RSACwS.Tests
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
            Assert.AreEqual(SystemPermission.REQUESTED, permission.State);
            Assert.AreEqual(false, permission.IsGranted);
            permission.ClaimedBy(admin);
            permission.GrantedBy(admin);
            Assert.AreEqual(SystemPermission.GRANTED, permission.State);
            Assert.AreEqual(true, permission.IsGranted);
        }
    }
}