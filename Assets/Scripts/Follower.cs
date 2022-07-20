using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] Transform target;
    Transform myTransform;
   
    void Start()
    {
        myTransform = transform;
    }

    void Update()
    {
        myTransform.position = target.position;
    }
}
