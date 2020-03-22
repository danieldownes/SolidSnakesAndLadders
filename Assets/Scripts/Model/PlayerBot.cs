namespace SnakesAndLadders
{
    internal class PlayerBot : Player
    {
        public override void StartTurn()
        {
            Roll?.Invoke();
        }
    }
}