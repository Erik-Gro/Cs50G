using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody rb; 

    public Vector3 movementDirection = Vector3.down;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 movement = movementDirection.normalized * 2f * Time.fixedDeltaTime;

        // Apply the movement to the platform's Rigidbody
        rb.MovePosition(rb.position + movement);
    }
}
