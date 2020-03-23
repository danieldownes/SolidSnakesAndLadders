namespace SnakesAndLadders
{
    public class PlayerBot : Player
    {
        public override void StartTurn()
        {
            OnRoll?.Invoke();
        }
    }
}