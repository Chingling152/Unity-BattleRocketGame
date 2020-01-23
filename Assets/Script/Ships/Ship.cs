using UnityEngine;

public class Ship : Entity
{

    Weapon weapon;

    public float Speed;

    private void Start()
    {
        weapon = gameObject.GetComponentInChildren<Weapon>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        throw new System.NotImplementedException();
    }
}
