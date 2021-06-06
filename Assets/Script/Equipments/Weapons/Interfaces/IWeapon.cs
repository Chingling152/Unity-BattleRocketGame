using UnityEngine;
using Entities.Generics;

namespace Equipments.Weapons.Interfaces
{
    public interface IWeapon
    {
        float FireRate { get; }

        int Cadency { get; }

        int Ammo { get; }

        IBullet Bullet { get; }

        BaseInstance Owner { get; }

        void Aim(Vector3 target);

        void Shoot(Vector3 target);
    }
}
