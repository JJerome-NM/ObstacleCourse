using Level1;
using Levels;
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
        PlayerEventManager.PlayerIsSpawned(SpawnPlayer(spawnPosition.position));
    }

    public GameObject SpawnPlayer(Vector3 spawnPosition)
    {
        _player = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
        _playerController = _player.GetComponentInChildren<PlayerController>();
        return _player;
    }
}