using System;

namespace SnakesAndLadders
{
    public abstract class Player
    {
        public Action OnRoll;

        public int Id;
        public int PlaceId { get; private set; }

        public virtual void StartTurn()
        { }

        public void MoveBy(int d)
        {
            PlaceId += d;
        }

        public void MoveTo(int placeId)
        {
            PlaceId = placeId;
        }
    }
}