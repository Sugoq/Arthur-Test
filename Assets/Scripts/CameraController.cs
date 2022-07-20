using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    [SerializeField] Vector3 positionForScale1;
    [SerializeField] Vector3 positionForScale5;
 
    private void Awake()
    {
        instance = this;  
    }
    private void OnDestroy()
    {
        instance = null;
    }
    
    public void UpdatePosition(float scale)
    {
        transform.position = (-scale * (positionForScale1 - positionForScale5) - positionForScale5 + 5 * positionForScale1) / 4;    
    }
}
