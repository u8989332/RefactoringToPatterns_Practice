namespace InlineSingleton
{
    public class GameOwner
    {
        private static HitStayResponse _hitStayResponse = new HitStayResponse();

        private GameOwner()
        {

        }

        public static HitStayResponse ObtainHitStayResponse(StreamReader input)
        {
            _hitStayResponse.ReadFrom(input);
            return _hitStayResponse;
        }

        public static void SetPlayerResponse(HitStayResponse newHitStayResponse)
        {
            _hitStayResponse = newHitStayResponse;
        }
    }
}
