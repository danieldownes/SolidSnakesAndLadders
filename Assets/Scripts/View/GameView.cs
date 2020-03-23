using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SnakesAndLadders
{
    public class GameView : MonoBehaviour
    {
        public Action OnMoveCompleted;
        public PlaceView[] Places;
        public PlayerView[] Players;

        public void Init()
        {
            Places = GetComponentsInChildren<PlaceView>();
            for( int i = 0; i < Places.Length; i++ )
                Places[i].Init(i);
        }

        public void ResetView()
        {
            for( int i = 0; i < Players.Length; i++ )
                movePlayer(i, 0);
        }

        // Return a list of pieces, each key is a position on the board
        //  the value is jump index set by the level designer
        public List<int> PieceJumpNextValues()
        {
            var ids = Places.Select(x => x.JumpToId);
            return ids.ToList();
        }

        public void PositionPlayer(int playerId, int placeId)
        {
            movePlayer(playerId, placeId);

            // For simplicity, I'll use this.
            // Normally would be replaced with a Tweener animation callback
            Invoke("completedMove", 2);
        }

        private void movePlayer(int playerId, int placeId)
        {
            Vector3 pos = Places[placeId].transform.position;
            Players[playerId].MoveTo(pos);
        }

        private void completedMove()
        {
            OnMoveCompleted?.Invoke();
        }
    }
}