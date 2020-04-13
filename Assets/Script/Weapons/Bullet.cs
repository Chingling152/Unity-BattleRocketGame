using UnityEngine;

public sealed class Bullet : MonoBehaviour
{
    public float MaxTimer = 5f;

    [SerializeField]
    private float MaxSpeed = 5f;

    public Entity Owner;

    private void Awake()
    {
        this.GetComponent<Rigidbody2D>().AddForce( this.transform.right * MaxSpeed);
    }
}

