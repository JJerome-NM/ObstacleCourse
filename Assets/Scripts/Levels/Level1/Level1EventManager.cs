using UnityEngine;
using UnityEngine.Events;

namespace Level1
{
    public class Level1EventManager : MonoBehaviour
    {
        public static readonly UnityEvent OnLevelRestarted = new();
        public static readonly UnityEvent<int, GameObject> OnPlayerSpawnedOnCheckPoint = new();
        public static readonly UnityEvent<int> OnPlayerTriggeredCheckPoint = new();

        public static void RestartLevel()
        {
            OnLevelRestarted.Invoke();
        }

        public static void PlayerIsSpawnedOnCheckPoint(int checkPointNumber, GameObject player)
        {
            OnPlayerSpawnedOnCheckPoint.Invoke(checkPointNumber, player);
        }

        public static void PlayerTriggeredCheckPoint(int checkPointNumber)
        {
            OnPlayerTriggeredCheckPoint.Invoke(checkPointNumber);
        }
    }
}