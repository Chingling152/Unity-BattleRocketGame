namespace Entities.Enemies.Interfaces
{
    /// <summary>
    /// Any Instance that attacks the Player
    /// </summary>
    public interface IEnemy
    {
        /// <summary>
        /// Vision detect radius of the Enemy
        /// </summary>
        float VisionRadius { get; }
    }
}
