using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public LayerMask mask;
    public FacePoint[] facePoints;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        int index = -1;
        if (Physics.Raycast(ray, out hit, 100,mask))
        {
            index = hit.collider.gameObject.layer;    
        }

        for(int i = 0; i< facePoints.Length; i++)
        {
            if (facePoints[i].point.isScaling) return;
        }
        
        for (int i = 0; i < facePoints.Length; i++)
        {
            facePoints[i].point.gameObject.SetActive(facePoints[i].layer == index);
        }
    }   
}

[Serializable]
public class FacePoint
{
    public int layer;
    public Scaler point;
    public Transform face;
   
}

