using System;
using UnityEngine;
using Entities.Interfaces;
using System.Collections.Generic;
using Equipments.Weapons;
using Equipments.Weapons.Interfaces;

namespace Entities.Generics
{
    public abstract class BaseInstance : MonoBehaviour, IDamageble
    {
        [System.Obsolete]
        public float Speed;

        [System.Obsolete]
        public Weapon weapon;

        [System.Obsolete]
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

        // Instances can move
        protected virtual void Move()
        {
            throw new System.NotImplementedException();
        }

        #region Search methods
        //TODO: future extension methods
        public T FindNearestByTag<T>(string tag, float maxDistance = float.PositiveInfinity) where T : MonoBehaviour
        {
            var objects = GameObject.FindGameObjectsWithTag(tag);

            if (objects != null)
            {
                List<T> selectedObjects = new List<T>();
                foreach (var item in objects)
                {
                    if (item.TryGetComponent<T>(out var component))
                        selectedObjects.Add(component);
                }

                return FindNearests<T>(selectedObjects, maxDistance);
            }
            return null;
        }

        public T FindNearestByType<T>(float maxDistance = float.PositiveInfinity) where T : MonoBehaviour
        {
            var objects = GameObject.FindObjectsOfType<T>();
            return null;
        }

        protected T FindNearests<T>(List<T> objects, float maxDistance = float.PositiveInfinity) where T : MonoBehaviour
        {
            if (objects.Count == 0)
                return null;

            T nearestObject = null;
            foreach (T item in objects)
            {
                var dist = Vector2.Distance(this.transform.position, item.transform.position);

                if (dist <= maxDistance)
                {
                    if (nearestObject == null)
                    {
                        nearestObject = item;
                    }
                    else
                    {
                        var dist2 = Vector2.Distance(this.transform.position, nearestObject.transform.position);
                        nearestObject = dist < dist2 ? item : nearestObject;
                    }
                }
            }
            return nearestObject;
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
