using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingRing : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public bool once = false;
    public float initialBounceForce = 5f;
    public float bounceDamping = 0.9f;
    public GameObject map;
    public bool canBeDestruyed = false;
    public float counter = 15f;
    public bool WasVisible = true;
    public GameObject child;
    public float threshold = 0f;
    //Renderer rendererComponent = gameObject.GetComponent<Renderer>();
    //public Collider myCollider;
    void Start()
    {
        //Collider mapCollider = map.GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
       // myCollider = GetComponent<Collider>();
        //Physics.Ignoreother(mapCollider, myCollider, false);
    }

    // Update is called once per frame
    void Update()
    {

        if(counter<=0)
        {
        child.SetActive(true);
        Destroy(gameObject);
        }
        else {
        if (threshold >= 0.3f&& counter <=5f ) {
            canBeDestruyed = true;
            threshold =  threshold % 0.3f ;
            if (WasVisible) {
                WasVisible = false;
            }
            else{
                WasVisible = true;
            }
            //child.SetActive(false);
        }
        else {
            threshold += Time.deltaTime;
            //child.SetActive(true);
        } 
        }
        counter -= Time.deltaTime;
        if (counter <= 14){
            canBeDestruyed = true;
        }
        child.SetActive(WasVisible);
    }
    //  void OnTriggerStay(Collider other)
    // {
    //    if (other.gameObject.layer == LayerMask.NameToLayer("player")&&canBeDestruyed)
    // {
    //    Destroy(gameObject);
    // }
    // }
}
