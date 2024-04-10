using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static readonly UnityEvent OnGameStarted = new();
    public static readonly UnityEvent OnGameStopped = new();
    public static readonly UnityEvent OnPlayerTakenSword = new();
    public static readonly UnityEvent OnPlayerFinished = new();
    public static readonly UnityEvent OnPlayerLost = new();
    
    public static void StopGame()
    {
        OnGameStopped.Invoke();
    }

    public static void StartGame()
    {
        OnGameStarted.Invoke();
    }

    public static void PlayerTakeSword()
    {
        OnPlayerTakenSword.Invoke();
    }

    public static void PlayerFinished()
    {
        OnPlayerFinished.Invoke();
    }

    public static void PlayerLost()
    {
        OnPlayerLost.Invoke();
    }
}
