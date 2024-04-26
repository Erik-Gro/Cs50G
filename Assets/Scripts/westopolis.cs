using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class westopolis : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

     void OnCollisionEnter(Collision collision)
    {
      if(collision.gameObject.name =="Player"){
      }
    
    }

      void OnCollisionStay(Collision collisionInfo)
    {
      // Debug.Log("hit");
    }
    void OnCollisionExit(Collision other)
    {
       // print("No longer in contact with " + other.transform.name);
    }
}
