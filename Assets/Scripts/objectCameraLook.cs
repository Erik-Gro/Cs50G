using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectCameraLook : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Transform target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = target.position;
        transform.position = new Vector3(p.x, p.y, p.z);
    }
}
