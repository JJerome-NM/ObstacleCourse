using UnityEngine;
using UnityEngine.UI;

namespace UI.MainPanel
{
    public class MainPanelController : MonoBehaviour
    {
        [Header("Button")] 
        [SerializeField] private Button startButton;

        private void Start()
        {
            startButton.onClick.AddListener(GlobalEventManager.StartGame);
        }
    }
}