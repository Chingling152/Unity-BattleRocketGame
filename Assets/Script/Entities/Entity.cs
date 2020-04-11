using System;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField]
    protected float Health;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.transform.gameObject;
        switch (other.tag)
        {
            case "Bullet":
                if (!other.GetComponent<Bullet>().Owner.Equals(this))
                {
                    CollisionDamage(collision.attachedRigidbody);
                    Destroy(collision.gameObject);
                }
                break;
            default:
                    break;
        }
    }

    protected void CollisionDamage(Rigidbody2D phy)
    {
        float collForce = phy.velocity.magnitude;
        Vector3 dir = phy.transform.position - transform.position;

        Vector3 force = -(dir * collForce);
        this.TakeDamage(Math.Abs(force.magnitude) * 10);

        this.GetComponent<Rigidbody2D>().AddForce(force);
    } 

    public virtual void TakeDamage(float damage)
    {
        this.Health -= damage;
    }
}
