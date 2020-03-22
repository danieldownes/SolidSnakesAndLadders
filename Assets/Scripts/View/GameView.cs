using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal class GameView : MonoBehaviour
{
    public Action PlayerMoveCompleted;
    public PlaceView[] Places;
    public PlayerView[] Players;
    
    public void Init()
    {
        Places = GetComponentsInChildren<PlaceView>();
        for( int i = 0; i < Places.Length; i++ )
            Places[i].Init(i);
    }

    // Return a list of pieces, each key is a position on the board
    //  the value is jump index set by the level designer
    internal List<int> PieceJumpNextValues()
    {
        var ids = Places.Select(x => x.JumpToId);
        return ids.ToList();
    }

    public void PositionPlayer(int playerId, int placeId)
    {
        Vector3 pos = Places[placeId].transform.position;
        Players[playerId].MoveTo(pos);

        // For simplicity, I'll use this.
        // Normally would be replaced with a Tweener animation callback
        Invoke("completedMove", 2);
    }

    private void completedMove()
    {
        PlayerMoveCompleted?.Invoke();
    }
}