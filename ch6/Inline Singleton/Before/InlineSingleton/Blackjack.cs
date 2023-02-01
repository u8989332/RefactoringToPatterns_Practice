namespace InlineSingleton;

public class Blackjack
{
    private Player _player = new Player();
    private Dealer _dealer = new Dealer();
    private StreamReader _input;

    public Blackjack(int[] deck)
    {
        // simplify
    }

    public void Play()
    {
        Deal();
        WriteLine(_player.GetHandAsString());
        WriteLine(_dealer.GetHandAsStringWithFirstCardDown());

        HitStayResponse hitStayResponse;
        do
        {
            Write("H)it or S)tay: ");
            hitStayResponse = GameOwner.ObtainHitStayResponse(_input);
            Write(hitStayResponse.ToString());
            if (hitStayResponse.ShouldHit())
            {
                DealCardTo(_player);
                WriteLine(_player.GetHandAsString());
            }
        } while (CanPlayerHit(hitStayResponse));
    }

    private bool CanPlayerHit(HitStayResponse hitStayResponse)
    {
        // simplify
        return false;
    }

    private void DealCardTo(Player player)
    {
        // simplify
    }

    private void WriteLine(string str)
    {
        Console.WriteLine(str);
    }

    private void Write(string str)
    {
        Console.Write(str);
    }

    private void Deal()
    {
        // simplify
    }

    public bool DidDealerWin()
    {
        // simplify
        return true;
    }

    public bool DidPlayerWin()
    {
        // simplify
        return false;
    }

    public double GetDealerTotal()
    {
        // simplify
        return 11;
    }

    public double GetPlayerTotal()
    {
        // simplify
        return 23;
    }
}