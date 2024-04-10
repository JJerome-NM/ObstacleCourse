using Player;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        [Header("Text")] [SerializeField] private TextMeshProUGUI playerStandingTime;
        [SerializeField] private GameObject mainPanel;
        [SerializeField] private GameObject playerWin;
        [SerializeField] private GameObject playerLost;
        
        private void Start()
        {
            GlobalEventManager.OnGameStarted.AddListener(OnGameStarted);
            GlobalEventManager.OnGameStopped.AddListener(OnGameStopped);
            GlobalEventManager.OnPlayerFinished.AddListener(OnPlayerFinished);
            GlobalEventManager.OnPlayerLost.AddListener(OnPlayerLost);
            PlayerEventManager.OnPlayerStandingTimeChanged.AddListener(ShowPlayerStandingTime);
        }

        private void OnPlayerFinished()
        {
            playerWin.SetActive(true);
        }

        private void OnPlayerLost()
        {
            playerLost.SetActive(true);
        }

        private void OnGameStopped()
        {
            mainPanel.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            playerStandingTime.gameObject.SetActive(false);
        }

        private void OnGameStarted()
        {
            playerWin.SetActive(false);
            mainPanel.SetActive(false);
            playerLost.SetActive(false);
            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            playerStandingTime.gameObject.SetActive(true);
        }

        private void ShowPlayerStandingTime(float newTime)
        {
            playerStandingTime.SetText("Standing time: " + newTime.ToString("F1"));
        }
    }
}