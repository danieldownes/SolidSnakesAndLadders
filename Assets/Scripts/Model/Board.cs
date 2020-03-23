using System.Collections.Generic;

namespace SnakesAndLadders
{
    public class Board
    {
        private List<Place> places;
        private GameView gameView;

        public int EndPlace
        {
            get
            {
                return places.Count - 1;
            }
        }

        public void Inject(GameView gameView, List<Place> places)
        {
            this.gameView = gameView;
            this.places = places;
        }

        public void SetupFromView()
        {
            var placesJumpNextValues = gameView.PieceJumpNextValues();

            foreach( int jumpIndex in placesJumpNextValues )
                places.Add(new Place(jumpIndex));
        }

        public int SnakeOrLadderMoveOffset(int placeId)
        {
            if( places[placeId].JumpTo == 0 )
                return 0;

            return places[placeId].JumpTo - placeId;
        }

        public bool ReachedEndPlace(int placeId)
        {
            return placeId >= EndPlace;
        }
    }
}