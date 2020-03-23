using NUnit.Framework;
using UnityEngine;
using SnakesAndLadders;
using System.Collections.Generic;

[TestFixture]
public class BoardTest : MonoBehaviour
{
    [Test]
    public void SnakeOrLadderMoveOffset_UpBy2()
    {
        var board = new Board();
        board.Inject(null, new List<Place>() { new Place(2), new Place(0), new Place(0), new Place(0) });

        Assert.AreEqual(2, board.SnakeOrLadderMoveOffset(0));
    }

    [Test]
    public void SnakeOrLadderMoveOffset_DownBy2()
    {
        var board = new Board();
        board.Inject(null, new List<Place>() { new Place(2), new Place(0), new Place(0), new Place(1) });

        Assert.AreEqual(-2, board.SnakeOrLadderMoveOffset(3));
    }
}
