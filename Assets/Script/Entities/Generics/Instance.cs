using System;
using UnityEngine;
using Entities.Interfaces;
using Equipments.Weapons;
using Equipments.Weapons.Interfaces;

namespace Entities.Generics
{
    public abstract class BaseInstance : MonoBehaviour, IDamageble
    {
        public float Speed;

        public Weapon weapon;

        protected Vector3 Target;

        #region Basics
        protected void Start()
        {
            weapon = gameObject.GetComponentInChildren<Weapon>();
        }

        protected void Update()
        {

        }

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            GameObject other = collision.transform.gameObject;
            switch (other.tag)
            {
                case "Bullet":
                    if (!other.GetComponent<IBullet>().Owner.Equals(this))
                    {
                        CollisionDamage(collision.attachedRigidbody);
                        Destroy(collision.gameObject);
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Methods
        protected virtual void Move()
        {
            throw new System.NotImplementedException();
        }

        protected virtual void LookTo(Vector3 target)
        {
            this.weapon.Aim(Target);
        }
        #endregion

        #region IDamageble implementation

        [SerializeField]
        protected float health;

        public float Health => this.health;

        public event Action<float> OnRecieveDamage;

        public void CollisionDamage(Rigidbody2D phy)
        {
            float collForce = phy.velocity.magnitude;
            Vector3 dir = phy.transform.position - transform.position;

            Vector3 force = -(dir * collForce);
            this.TakeDamage(Math.Abs(force.magnitude) * 10);

            this.GetComponent<Rigidbody2D>().AddForce(force);
        }

        public void TakeDamage(float damage)
        {
            this.health -= damage;
            this.OnRecieveDamage?.Invoke(damage);
        }
        #endregion
    }
}
