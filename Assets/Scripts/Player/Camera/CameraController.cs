using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [Header("Sensitivity")]
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    [Header("Other")] 
    [SerializeField] private Transform orientation;
    
    private float _xRotation;
    private float _yRotation;

    void Update()
    {
        _yRotation += Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        _xRotation -= Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        
        transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, _yRotation, 0);
    }
}
