using Player;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Camera")] 
    [SerializeField] private Camera camera;
    [SerializeField] private int maxStandingTime = 30;
    
    private float _playerStandingTime;
    private Rigidbody _rb;

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

    private void FixedUpdate()
    {
        if (_playerStandingTime > maxStandingTime)
        {
            KillPlayer();
        }
    }

    public void DisablePlayerCamera()
    {
        camera.enabled = false;
    }

    public void EnablePlayerCamera()
    {
        camera.enabled = true;
    }
    
    private void KillPlayer()
    {
        gameObject.SetActive(false);
        PlayerEventManager.PlayerIsDead();
        Destroy(gameObject);
    }
}
