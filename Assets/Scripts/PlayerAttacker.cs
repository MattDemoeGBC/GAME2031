using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField]
    GameObject projectilePrefab;

    public void Attack()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 10, 0);
    }
}
