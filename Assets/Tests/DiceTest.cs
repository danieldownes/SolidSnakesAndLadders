using NUnit.Framework;
using UnityEngine;
using SnakesAndLadders;

[TestFixture]
public class DiceTest : MonoBehaviour
{
    [Test]
    public void DiceRandomness()
    {
        var d = new DiceUnityRandom();
        int r;
        
        for( int i = 0; i < 50; i++ )
        {
            r = d.Roll();
            Assert.LessOrEqual(r, 6);
            Assert.GreaterOrEqual(r, 1);
        }
    }
}
