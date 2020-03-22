using System.Collections.Generic;

internal class Board
{
    private List<Place> places;
    private GameView gameView;

    public void Inject(GameView gameView, List<Place> places)
    {
        this.gameView = gameView;
        this.places = places;
    }

    internal void SetupFromView()
    {
        var placesJumpNextValues = gameView.PieceJumpNextValues();
        
        foreach( int jumpIndex in placesJumpNextValues )
            places.Add(new Place(jumpIndex));
    }

    internal int SnakeOrLadderMoveOffset(int placeId)
    {
        if( places[placeId].JumpTo == 0 )
            return 0;

        return places[placeId].JumpTo - placeId;
    }
}