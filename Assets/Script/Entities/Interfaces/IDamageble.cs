using System;
using UnityEngine;

namespace Entities.Interfaces
{
    /// <summary>
    /// Defines any GameObjects that can recieve damage
    /// </summary>
    public interface IDamageble
    {
        /// <summary>
        /// Events that happen when the IDamageble recieves damage using the damage value or health
        /// </summary>
        event Action<float> OnRecieveDamage;

        /// <summary>
        /// Health of the GameObject
        /// </summary>
        float Health { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phy"></param>
        #warning maybe this method is not necessary here
        void CollisionDamage(Rigidbody2D phy);

        /// <summary>
        /// Method of taking damage of the instance
        /// </summary>
        /// <param name="damage">Amount of damage recieved</param>
        void TakeDamage(float damage);
    }
}
