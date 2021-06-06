using UnityEngine;
using Entities.Generics;

namespace Equipments.Weapons.Interfaces
{
    /// <summary>
    /// Any weapon of the game
    /// </summary>
    public interface IWeapon
    {
        /// <summary>
        /// Time between any shoots
        /// </summary>
        int Cadency { get; }

        int Ammo { get; }

        IBullet Bullet { get; }

        BaseInstance Owner { get; }

        void Aim(Vector3 target);

        void Shoot(Vector3 target);
    }
}
