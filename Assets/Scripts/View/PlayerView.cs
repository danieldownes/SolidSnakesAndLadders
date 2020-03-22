using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public int Id;
    private float positionOffset = 0.2f;

    internal void MoveTo(Vector3 pos)
    {
        transform.position = pos;
        transform.Translate(0, positionOffset, Id == 0 ? positionOffset : -positionOffset);
    }
}
