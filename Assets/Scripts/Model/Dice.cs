namespace SnakesAndLadders
{
    public class DiceUnityRandom : IDice
    {
        public int Roll()
        {
            return UnityEngine.Random.Range(1, 7);
        }
    }
}