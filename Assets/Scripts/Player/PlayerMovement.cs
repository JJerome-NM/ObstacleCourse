using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Movement")] 
    [SerializeField] private float moveSpead;
    [SerializeField] private float groundDrag;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCooldown;
    [SerializeField] private float airMultiplier;
    [SerializeField] private Transform orientation;
    
    [Header("KeyBinds")] 
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")] 
    [SerializeField] private LayerMask whatIsGround;

    private float _playerHeight;
    private float _horizontalInput;
    private float _verticalInput;
    private Vector3 _moveDirection;
    private Rigidbody _rb;

    private bool _readyToJump;
    private bool _grounded;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
        _readyToJump = true;

        _playerHeight = transform.localScale.y;
    }

    void Update()
    {
        if (GlobalStatesManager.IsGameStopped) return;
        
        _grounded = Physics.Raycast(transform.position, Vector3.down, _playerHeight + 0.01f, whatIsGround);
        
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        
        if (Input.GetKey(jumpKey) && _readyToJump && _grounded)
        {
            Jump();
        }
        
        SpeedControl();

        _rb.drag = _grounded ? groundDrag : 0;
    }

    private void SpeedControl()
    {
        Vector3 oldVelocity = _rb.velocity;
        Vector3 flatVel = new Vector3(oldVelocity.x, 0f, oldVelocity.z);

        if (flatVel.magnitude > moveSpead)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpead;
            _rb.velocity = new Vector3(limitedVel.x, _rb.velocity.y, limitedVel.z);
        }
    }
    
    private void Jump()
    {
        _readyToJump = false;
        
        Vector3 oldVelocity = _rb.velocity;
        _rb.velocity = new Vector3(oldVelocity.x, 0f, oldVelocity.z);
        
        _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        
        Invoke(nameof(ResetJump), jumpCooldown);
    }

    private void ResetJump()
    {
        _readyToJump = true;
    }

    private void FixedUpdate()
    {
        if (GlobalStatesManager.IsGameStopped) return;
        
        MovePlayer();
    }

    private void MovePlayer()
    {
        _moveDirection = orientation.forward * _verticalInput + orientation.right * _horizontalInput;

        if (_grounded)
        {
            _rb.AddForce(_moveDirection.normalized * moveSpead * 10f, ForceMode.Force);
        }
        else
        {
            _rb.AddForce(_moveDirection.normalized * moveSpead * 10f * airMultiplier, ForceMode.Force);
        }
    }
}
