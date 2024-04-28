using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wp : MonoBehaviour {

	// Use this for initialization
	public Text uiText;
	void Start () {
		//uiText = GetComponentInChildren<Text>();
		//uiText = GameObject.Find("Text");

        // Access and modify the text value
        //uiText.Text = "Hello, World!";
		//Debug.Log(uiText.text = "You Won!");
	}
	
	// Update is called once per frame
	void Update () {
	}
// -190.374
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.name == "PortalGunFPSController") {
			uiText.text = "You Won!";
		}
	}
}
