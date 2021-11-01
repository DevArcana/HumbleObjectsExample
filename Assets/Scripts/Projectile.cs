using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    public Vector3 velocity;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
    }
}