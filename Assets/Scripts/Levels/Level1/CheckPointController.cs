using Level1;
using UnityEngine;

namespace Levels.Level1
{
    public class CheckPointController : MonoBehaviour
    {
        private int _checkPointNumber = 0;
        
        public void SetCheckPointNumber(int newNumber)
        {
            _checkPointNumber = newNumber;
        }

        public Vector3 GetPosition()
        {
            return gameObject.transform.position;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Level1EventManager.PlayerTriggeredCheckPoint(_checkPointNumber);
            }
        }
    }
}