using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField]float rotateSpeed;
    Transform myTransform;

    private void Start()
    {
        myTransform = transform;   
    }

    private void OnMouseDrag()
    {
        float xAxis = Input.GetAxis("Mouse X") * rotateSpeed;
        float yAxis = Input.GetAxis("Mouse Y") * rotateSpeed;
        myTransform.Rotate(Vector3.down, xAxis , Space.World);
        myTransform.Rotate(Vector3.right, yAxis , Space.World);
    }  
}
