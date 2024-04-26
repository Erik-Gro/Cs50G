using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    // Start is called before the first frame update
    private float count = 0f;
    private float secondsToDestroy = 100f;
    public string owner;
    private string enemy;
    void Start()
    {
        if(owner=="Player"){
            enemy = "Enemy";
        }
        else{
            enemy = "Player";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (count > secondsToDestroy){
            Destroy(transform.parent.gameObject);
        } 
        else count += Time.deltaTime;
    }
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);
    if (other.tag == "Map"){
            Destroy(transform.parent.gameObject);
        }
    if (other.tag == enemy){
            Destroy(other.gameObject);
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
