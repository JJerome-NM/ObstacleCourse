using Player;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Player")] 
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private float maxStandingTime = 5;
    
    [Header("Camera")] 
    [SerializeField] private Camera generalCamera;

    [Header("Game")] 
    [SerializeField] private GameObject sword;
    
    private GameObject _player;
    private PlayerController _playerController;
    
    void Start()
    {
        GlobalEventManager.OnGameStarted.AddListener(OnGameStarted);
        GlobalEventManager.OnGameStopped.AddListener(OnGameStopped);
        GlobalEventManager.OnPlayerFinished.AddListener(GlobalEventManager.StopGame);
        PlayerEventManager.OnPlayerStandingTimeChanged.AddListener(CheckPlayerStandingTime);
        
        GlobalEventManager.StopGame();
    }

    private void CheckPlayerStandingTime(float time)
    {
        if (time > maxStandingTime)
        {
            GlobalEventManager.StopGame();
            GlobalEventManager.PlayerLost();
        }
    }
    
    private void OnGameStarted()
    {
        SpawnPlayer();
        
        if (!_playerController) return;
        
        _playerController.EnablePlayerCamera();
        generalCamera.enabled = false;
        
        sword.SetActive(true);
    }

    private void OnGameStopped()
    {
        if (!_playerController) return;
        
        _playerController.DisablePlayerCamera();
        generalCamera.enabled = true;
        
        _player.GetComponentInParent<FullPlayerController>().DestoyMe();
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