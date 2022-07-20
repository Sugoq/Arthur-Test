using UnityEngine;
public class Scaler : MonoBehaviour
{
    public Transform target;
    Vector2 lastPosition;
    [SerializeField] float scaleSpeed;
    [SerializeField] float maxScaleLimit;
    [SerializeField] float minScaleLimit;
    [SerializeField] bool x, y, z;
    [SerializeField] Transform face;
    [SerializeField] Camera cam;
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Color emissionColor;
    public bool isScaling;
    
    private void OnMouseDown()
    {
        lastPosition = Input.mousePosition;
        isScaling = true;
    }

    private void Update()
    {
        if (isScaling)
        {
            Scale(x ? Vector3.right : y ? Vector3.up : Vector3.forward);
            CameraController.instance.UpdatePosition(Mathf.Max(target.localScale.x, Mathf.Max(target.localScale.y, target.localScale.z)));
        }
    }
    private void OnMouseUp()
    {
        isScaling = false;
        meshRenderer.material.SetColor("_EmissionColor", Color.black);
    }
    void Scale(Vector3 scaleDirection)
    {
        Vector3 deltaPosition = ((Vector2)Input.mousePosition - lastPosition).normalized;
        Vector3 begin = cam.WorldToScreenPoint(face.position);
        Vector3 end = cam.WorldToScreenPoint(face.position - face.forward);
        Vector3 direction = (end - begin).normalized;
        float dot = Vector3.Dot(deltaPosition, direction);
        DrawArrow.ForDebug(face.position, direction, Color.white);
        DrawArrow.ForDebug(face.position, deltaPosition, Color.red);
        Vector3 scale = target.localScale + scaleDirection * dot * scaleSpeed * Time.deltaTime;
        if (scale.x < minScaleLimit || scale.y < minScaleLimit || scale.z < minScaleLimit) return;
        if (scale.x > maxScaleLimit || scale.y > maxScaleLimit || scale.z > maxScaleLimit) return;
        target.localScale = scale;
    }
    private void OnMouseEnter()
    {
        meshRenderer.material.SetColor("_EmissionColor", emissionColor);
    }

    private void OnMouseExit()
    {
        if(!isScaling)
            meshRenderer.material.SetColor("_EmissionColor", Color.black);
    }
}