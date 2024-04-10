using UnityEngine;

namespace Player
{
    public class MainWeaponController : MonoBehaviour
    {
        [SerializeField] private GameObject swordPrefab;
        [SerializeField] private Transform swordPosition;
        [SerializeField] private GameObject weaponParen;
        
        private void Start()
        {
            if (GlobalStatesManager.IsPlayerTakenSword)
            {
                ShowSword();
            }
            
            GlobalEventManager.OnPlayerTakenSword.AddListener(ShowSword);
        }

        private void ShowSword()
        {
            GameObject mainWeapon = Instantiate(swordPrefab, swordPosition.position, Quaternion.identity);
            mainWeapon.transform.SetParent(weaponParen.transform);
            mainWeapon.transform.rotation = swordPosition.rotation;
        }
    }
}