using System;

internal abstract class Player
{
    public Action OnRoll;

    public int Id;
    public int PlaceId { get; private set; }

    public virtual void StartTurn()
    {

    }

    internal void MoveBy(int d)
    {
        PlaceId += d;
    }

    internal void MoveTo(int placeId)
    {
        PlaceId = placeId;
    }
}