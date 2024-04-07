using UnityEngine;

public class GlobalStatesManager : MonoBehaviour
{
    public static bool IsGameStopped { get; private set; }

    private void Start()
    {
        GlobalEventManager.OnGameStarted.AddListener(() => IsGameStopped = false);   
        GlobalEventManager.OnGameStopped.AddListener(() => IsGameStopped = true);   
    }
}
