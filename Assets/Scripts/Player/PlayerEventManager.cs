using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerEventManager : MonoBehaviour
    {
        public static readonly UnityEvent<float> OnPlayerStandingTimeChanged = new();
        public static readonly UnityEvent<GameObject> OnPlayerDied = new();
        public static readonly UnityEvent<GameObject> OnPlayerSpawned = new();
        
        
        public static void ChangePlayerStandingTime(float newTime)
        {
            OnPlayerStandingTimeChanged.Invoke(newTime);
        }
        
        public static void PlayerIsDead(GameObject player)
        {
            OnPlayerDied.Invoke(player);
        }

        public static void PlayerIsSpawned(GameObject player)
        {
            OnPlayerSpawned.Invoke(player);
        }
    }
}