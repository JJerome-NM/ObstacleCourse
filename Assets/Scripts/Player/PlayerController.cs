using Player;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Camera")] 
    [SerializeField] private Camera camera;
    [SerializeField] private int maxStandingTime = 30;

    private Rigidbody _rb;
    private float _playerStandingTime;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _playerStandingTime = 0;
    }
    
    private void Update()
    {
        _playerStandingTime = _rb.velocity.magnitude != 0 ? 0 : _playerStandingTime + Time.deltaTime;
        
        PlayerEventManager.ChangePlayerStandingTime(_playerStandingTime);
    }

    public void DisablePlayerCamera()
    {
        camera.enabled = false;
    }

    public void EnablePlayerCamera()
    {
        camera.enabled = true;
    }
    
    public void KillPlayer()
    {
        PlayerEventManager.PlayerIsDead(gameObject);
        GetComponentInParent<FullPlayerController>().DestoyMe();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("DeadZone"))
        {
            KillPlayer(); 
        }
        
        if (other.CompareTag("FinalSword"))
        {
            GlobalEventManager.PlayerTakeSword();
            other.gameObject.SetActive(false);
        }
        
        if (other.CompareTag("Finish") && GlobalStatesManager.IsPlayerTakenSword)
        {
            GlobalEventManager.PlayerFinished();
        }
    }
}
