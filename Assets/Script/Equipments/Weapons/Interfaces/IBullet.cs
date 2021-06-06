using Entities.Generics;
using UnityEngine;

namespace Equipments.Weapons.Interfaces
{
    public interface IBullet
    {
        /// <summary>
        /// Max Time the bullet will still alive
        /// </summary>
        float MaxTimer { get ; }

        /// <summary>
        /// Max speed of the Bullet
        /// </summary>
        float MaxSpeed { get; }
        
        /// <summary>
        /// The creator of the bullet, used so it cannot collides with the Bullet
        /// </summary>
        BaseInstance Owner { get; }
    }
}
