using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerEventManager : MonoBehaviour
    {
        public static readonly UnityEvent<float> OnPlayerStandingTimeChanged = new();
        public static readonly UnityEvent OnPlayerDied = new();
        public static readonly UnityEvent OnPlayerSpawned = new();
        
        
        public static void ChangePlayerStandingTime(float newTime)
        {
            OnPlayerStandingTimeChanged.Invoke(newTime);
        }
        
        public static void PlayerIsDead()
        {
            OnPlayerDied.Invoke();
        }

        public static void PlayerIsSpawned()
        {
            OnPlayerSpawned.Invoke();
        }
    }
}