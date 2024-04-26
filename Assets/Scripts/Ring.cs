using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ring : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private GameObject Player ;
    [SerializeField] private Player playerScript;
    [SerializeField] private AudioClip RingCollect;
    private TextMeshProUGUI textElement;
    void Start()
    {
        GameObject textObject = GameObject.Find("Text (TMP)");
        textElement = textObject.GetComponent<TextMeshProUGUI>();
        Player = GameObject.FindWithTag("Player");
        playerScript = Player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        
    }
     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"){
            playerScript.rings++;
            textElement.text = "rings : " + playerScript.rings.ToString();
            SoundManager.instance.PlaySoundFXClip(RingCollect,transform,0.1f);
            Destroy(transform.parent.gameObject);
    }
    }
    //  void OnTriggerStay(Collider other)
    // {
    //     if (other.tag == "Player"){
    //         Destroy(transform.parent.gameObject);
    //     }
    // }
    //  void OnTriggerExit(Collider other)
    // {
    //     if (other.tag == "Player"){
    //         Destroy(transform.parent.gameObject);
    //     }
    // }
}
