using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [SerializeField] private Transform cameraPosition;
    
    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
