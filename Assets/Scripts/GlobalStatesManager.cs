using UnityEngine;

public class GlobalStatesManager : MonoBehaviour
{
    public static bool IsGameStopped { get; private set; }
    public static bool IsPlayerTakenSword { get; private set; }
    
    private void Start()
    {
        GlobalEventManager.OnGameStopped.AddListener(OnGameStopped);
        GlobalEventManager.OnGameStarted.AddListener(() => IsGameStopped = false);
        GlobalEventManager.OnPlayerTakenSword.AddListener(() => IsPlayerTakenSword = true);
    }

    private void OnGameStopped()
    {
        IsGameStopped = true;
        IsPlayerTakenSword = false;
    }
}
