using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class springCollider : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private Player script;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject dummy;
    [SerializeField] private Sphere sphereScript;
    [SerializeField] private AudioClip SpringSound;
    [SerializeField] private GameObject Parent;
    void Start()
    {
        script = playerTransform.gameObject.GetComponent<Player>();
        Player = GameObject.FindWithTag("Player");
        script = Player.GetComponent<Player>();
        //sphereScript = sphere.gameObject.GetComponent<Sphere>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.layer == LayerMask.NameToLayer("player"))
    {
       SoundManager.instance.PlaySoundFXClip(SpringSound,transform,0.1f);
       Debug.Log(other.gameObject.name + "");
       playerTransform.position = transform.position+(transform.TransformDirection(Vector3.up) * 0.08800001f);
       script.attaking = false;
       script.attack = false;
       script.jumpSpeed = jumpSpeed;
    }
    }
     void OnTriggerStay(Collider other)
    {
       if (other.gameObject.layer == LayerMask.NameToLayer("player"))
    {
      //script.jumpSpeed = jumpSpeed;
    }
    }
     void OnTriggerExit(Collider other)
    {
       if (other.gameObject.layer == LayerMask.NameToLayer("player"))
    {
      script.jumpSpeed = jumpSpeed;
      //sphereScript.closestEnemyInDirection = dummy;
    }
    }
}
