using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    [SerializeField] private float forwardforce;
    [SerializeField] private AudioClip Dash;
    [SerializeField] private int speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("onplatrofm");
        if (other.tag == "Player"){
        Player script = other.GetComponent<Player>();
        other.transform.position = transform.position;
        SoundManager.instance.PlaySoundFXClip(Dash,transform,0.3f);
        other.transform.rotation = transform.rotation;
        script.forwardforce = forwardforce;
        script.speed = speed;
        //other.transform.position += (transform.TransformDirection(Vector3.up) * 0.08800001f);
        }
    }
}
