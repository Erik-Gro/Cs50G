using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingHolder : MonoBehaviour
{
    // Start is called before the first frame update
    private RaycastHit hit;
    [SerializeField] private GameObject Ring;
    private Rigidbody rb;
    [SerializeField] public float maxYrotation ;
    [SerializeField] public float minYrotation ;
    [SerializeField] private bool leavitate = true;
    void Awake()
    {
        if (!leavitate) return;
        Physics.Raycast(Ring.transform.position, transform.TransformDirection(Vector3.down), out hit,  Mathf.Infinity * 10f );
        transform.position = hit.point;
        transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        //Debug.DrawRay(transform.position, new Vector3(0, -30f, 0), Color.yellow);
    }
    void Start()
    {
        // maxYrotation = 90;
        // minYrotation = -90;
        //Debug.Log(transform.rotation.y);
        minYrotation = transform.rotation.eulerAngles.y - 90;
        maxYrotation = transform.rotation.eulerAngles.y + 90;
        //Debug.Log(transform.eulerAngles.y);
        // rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 forwardVelocity = transform.forward * 1f;
        // rb.velocity = forwardVelocity;
    }
}
