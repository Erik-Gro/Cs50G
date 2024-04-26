using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RingTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Player ;
    [SerializeField] private Player playerScript;
    [SerializeField] private AudioClip RingCollect;
    [SerializeField] private GameObject Parent;
    [SerializeField] private DroppingRing ParentScript;
    private TextMeshProUGUI textElement;
    void Start()
    {
        ParentScript = Parent.GetComponent<DroppingRing>();
        GameObject textObject = GameObject.Find("Text (TMP)");
        textElement = textObject.GetComponent<TextMeshProUGUI>();
        Player = GameObject.FindWithTag("Player");
        playerScript = Player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }
     void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player"&&ParentScript.canBeDestruyed){
            playerScript.rings++;
            textElement.text = "rings : " + playerScript.rings.ToString();
            SoundManager.instance.PlaySoundFXClip(RingCollect,transform,0.1f);
            Destroy(transform.parent.gameObject);
    }
    }
    //  void OnTriggerStay(Collider other)
    // {
    //     if (other.tag == "Player"&&ParentScript.canBeDestruyed){
    //         // Destroy(transform.parent.gameObject);
    // }
    // }
}
