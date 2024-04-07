using Player;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        [Header("Text")] 
        [SerializeField] private TextMeshProUGUI playerStandingTime;
        [SerializeField] private GameObject mainPanel;

        private void Start()
        {
            GlobalEventManager.OnGameStarted.AddListener(OnGameStarted);
            GlobalEventManager.OnGameStopped.AddListener(OnGameStopped);
            PlayerEventManager.OnPlayerStandingTimeChanged.AddListener(ShowPlayerStandingTime);
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
            mainPanel.SetActive(false);
            
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