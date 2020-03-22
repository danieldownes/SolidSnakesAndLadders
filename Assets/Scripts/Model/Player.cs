using System;

internal abstract class Player
{
    public Action Roll;

    public int Id;
    public int PlaceId;

    public virtual void StartTurn()
    {

    }

    internal void MoveTo(int d)
    {
        PlaceId += d;
    }
}