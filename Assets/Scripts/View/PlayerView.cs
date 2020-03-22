using UnityEngine;

public class PlayerView : MonoBehaviour
{
    internal void MoveTo(Vector3 pos)
    {
        transform.position = pos;
    }
}
