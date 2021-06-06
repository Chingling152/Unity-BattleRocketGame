using UnityEngine;
using Entities.Generics;
using Equipments.Weapons.Interfaces;

public sealed class Bullet : MonoBehaviour, IBullet
{
    [SerializeField]
    public float maxTimer = 5f;

    [SerializeField]
    private float maxSpeed = 5f;

    [SerializeField]
    public BaseInstance owner;

    public float MaxTimer => this.maxSpeed;
    public float MaxSpeed => this.maxTimer;
    public BaseInstance Owner {
        get => this.owner; 
        set => this.owner = value;
    }

    private void Awake()
    {
        this.GetComponent<Rigidbody2D>().AddForce( Vector3.forward * MaxSpeed);
    }
}

