using Player;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Player")] 
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPosition;

    [Header("Camera")] 
    [SerializeField] private Camera generalCamera;

    private GameObject _player;
    private PlayerController _playerController;

    void Start()
    {
        GlobalEventManager.OnGameStarted.AddListener(OnGameStarted);
        GlobalEventManager.OnGameStopped.AddListener(OnGameStopped);
        PlayerEventManager.OnPlayerDied.AddListener(OnPlayerDied);

        GlobalEventManager.StopGame();
    }

    private void OnPlayerDied()
    {
        GlobalEventManager.StopGame();
    }

    private void OnGameStarted()
    {
        SpawnPlayer();
        
        if (!_playerController) return;
        
        _playerController.EnablePlayerCamera();
        generalCamera.enabled = false;
    }

    private void OnGameStopped()
    {
        if (!_playerController) return;
        
        _playerController.DisablePlayerCamera();
        generalCamera.enabled = true;
    }

    private void SpawnPlayer()
    {
        _player = Instantiate(playerPrefab, spawnPosition.position, Quaternion.identity);
        _playerController = _player.GetComponentInChildren<PlayerController>();
    }
}