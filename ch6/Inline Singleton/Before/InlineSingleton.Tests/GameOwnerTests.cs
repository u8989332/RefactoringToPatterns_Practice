namespace InlineSingleton.Tests
{
    public class GameOwnerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestDealerStandsPlayerBusts()
        {
            // arrange
            GameOwner.SetPlayerResponse(new TestAlwaysHitResponse());
            int[] deck = { 10, 9, 7, 2, 6 };
            Blackjack blackjack = new Blackjack(deck);
            blackjack.Play();

            Assert.IsTrue(blackjack.DidDealerWin(), "dealer wins");
            Assert.IsTrue(!blackjack.DidPlayerWin(), "player loses");
            Assert.AreEqual(11, blackjack.GetDealerTotal(), "dealer total");
            Assert.AreEqual(23, blackjack.GetPlayerTotal(), "player total");
        }
    }
}