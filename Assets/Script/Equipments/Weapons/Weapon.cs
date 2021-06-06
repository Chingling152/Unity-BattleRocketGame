using UnityEngine;
using Equipments.Weapons.Interfaces;
using Entities.Generics;

namespace Equipments.Weapons
{
    public sealed class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField]
        private float fireRate;

        [SerializeField]
        private int cadency;

        [SerializeField]
        private int ammo;

        [SerializeField]
        private IBullet bullet;

        [SerializeField]
        private BaseInstance owner;

        public float FireRate => this.fireRate;

        public int Cadency => this.cadency;

        public int Ammo => this.ammo;

        public IBullet Bullet => this.bullet;

        public BaseInstance Owner => this.owner;

        void Start()
        {
            owner = gameObject.GetComponentInParent<BaseInstance>();
        }

        // Update is called once per frame
        void Update()
        {
            if (FireRate < Cadency)
                fireRate += Time.deltaTime * 10;
        }

        public void Shoot(Vector3 target)
        {
            if (Ammo > 0 && FireRate > Cadency)
            {
                Quaternion rot = Quaternion.LookRotation(target - transform.position, Vector3.forward);
                Instantiate((Bullet)bullet, transform.GetChild(0).position, transform.rotation).Owner = this.owner;
                fireRate = 0;
                ammo--;
            }
        }

        public void Aim(Vector3 target)
        {
            throw new System.NotImplementedException();
        }
    }
}

