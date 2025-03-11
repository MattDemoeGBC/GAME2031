using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public void Move(Vector2 direction)
    {
        Vector3 dir = direction;
        transform.position += dir;
    }
}
