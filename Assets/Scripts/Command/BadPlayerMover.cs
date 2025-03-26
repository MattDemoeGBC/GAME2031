using UnityEngine;

public class BadPlayerMover : MonoBehaviour
{
    public void Move(Vector3 direction)
    {
        transform.position += direction;
    }
}
