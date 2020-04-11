using UnityEngine;

public class Instance : Entity
{
    protected Ship ship;

    protected Vector3 Target;


    protected void Start()
    {
        ship = gameObject.GetComponentInChildren<Ship>();
    }

    protected void OnSpace()
    {
        Health -= 1;
    }

    // Instances can move
    protected virtual void Move()
    {
        throw new System.NotImplementedException();
    }
}