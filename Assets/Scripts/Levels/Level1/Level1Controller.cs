using System.Collections.Generic;
using Level1;
using Player;
using UnityEngine;

namespace Levels.Level1
{
    public class Level1Controller : MonoBehaviour, ILevelController
    {
        [Header("Camera")] 
        [SerializeField] private Camera previewCamera;

        [Header("Player")] 
        [SerializeField] private List<CheckPointController> checkPointPositions;

        [Header("Game")] 
        [SerializeField] private GameController gameController;

        private int _currentCheckPoint;
        private PlayerController _playerController;

        private void Start()
        {
            _currentCheckPoint = 0;

            int index = 0;
            checkPointPositions.ForEach(pos => pos.SetCheckPointNumber(index++));

            Level1EventManager.OnPlayerTriggeredCheckPoint.AddListener(num => _currentCheckPoint = num);
            Level1EventManager.OnPlayerSpawnedOnCheckPoint.AddListener((_, player) =>
            {
                PlayerEventManager.PlayerIsSpawned(player);
            });
            PlayerEventManager.OnPlayerDied.AddListener(PlayerIsDied);
            PlayerEventManager.OnPlayerSpawned.AddListener(OnPlayerSpawned);
            GlobalEventManager.OnPlayerTakenSword.AddListener(() => _currentCheckPoint = checkPointPositions.Count - 1);
        }

        public void EnableLevelPreviewCamera()
        {
            previewCamera.enabled = true;
        }

        public void DisableLevelPreviewCamera()
        {
            previewCamera.enabled = false;
        }

        public Vector3 GetSpawnPosition()
        {
            return checkPointPositions.Count > 0 ? checkPointPositions[0].GetPosition() : new Vector3(0, 0, 0);
        }

        private void OnPlayerSpawned(GameObject player)
        {
            _playerController = player.GetComponentInChildren<PlayerController>();

            previewCamera.enabled = false;
            _playerController.EnablePlayerCamera();
        }

        public void PlayerIsDied(GameObject player)
        {
            player.GetComponent<PlayerController>().DisablePlayerCamera();

            GameObject newPlayer = gameController.SpawnPlayer(checkPointPositions[_currentCheckPoint].GetPosition());

            _playerController = newPlayer.GetComponentInChildren<PlayerController>();
            _playerController.EnablePlayerCamera();

            Level1EventManager.PlayerIsSpawnedOnCheckPoint(_currentCheckPoint, player);
        }
    }
}