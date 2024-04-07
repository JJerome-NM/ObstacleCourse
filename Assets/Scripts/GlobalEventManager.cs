using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static readonly UnityEvent OnGameStarted = new();
    public static readonly UnityEvent OnGameStopped = new();


    public static void StopGame()
    {
        OnGameStopped.Invoke();
    }

    public static void StartGame()
    {
        OnGameStarted.Invoke();
    }

}
