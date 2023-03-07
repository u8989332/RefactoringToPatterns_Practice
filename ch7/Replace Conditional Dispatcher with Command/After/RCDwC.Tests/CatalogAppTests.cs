namespace RCDwC.Tests
{
    public class CatalogAppTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ExecuteActionAndGetResponse_Return_Correct_Response()
        {
            // arrange
            CatalogApp app = new CatalogApp();
            
            // act
            var result = app.ExecuteActionAndGetResponse(CatalogApp.NewWorkshop, new Dictionary<string, string>());

            // assert
            Assert.AreEqual("<workshops name=\"D:\\Shop1\">\r\n  <workshop id=\"1\" name=\"myWorkshop\" status=\"Open\" duration=\"2023/03/07 11:22:45\" />\r\n</workshops>", 
                result.StringBuilder.ToString());
        }
    }
}