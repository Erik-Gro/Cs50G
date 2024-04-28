using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;

//[RequireComponent(typeof(Text))]
public class MazeCounter : MonoBehaviour
{

	// Use this for initialization

	public static MazeCounter Mazeecount = null;
	public static int coins = 0;

	public static bool inPlay;

	public GameObject txt;
	//private Text text;
	void Awake()
	{
		if (Mazeecount == null)
		{
			Mazeecount = this;
			Debug.Log("me0");
			DontDestroyOnLoad(gameObject);
			//coins = 0;
			inPlay = true;
			//txt.text = "Coins: " + coins;
		}
		if (Mazeecount == this)
		{
			Debug.Log("me2");
			//coins++;
		}
		if (Mazeecount != this)
		{
			Debug.Log("me1");
			//coins++;
			//txt.text = "Coins: " + coins;
			Destroy(gameObject);
		}
	}
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}

// using UnityEngine;
// using UnityEngine.UI;
// using System.Collections;

// [RequireComponent(typeof(Text))]
// public class CoinText : MonoBehaviour {

// 	public GameObject helicopter;
// 	private Text text;
// 	private int coins;

// 	// Use this for initialization
// 	void Start () {
// 		text = GetComponent<Text>();
// 	}

// 	// Update is called once per frame
// 	void Update () {
// 		if (helicopter != null) {
// 			coins = helicopter.GetComponent<HeliController>().coinTotal;
// 		}
// 		text.text = "Coins: " + coins;
// 	}
// }
