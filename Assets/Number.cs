using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Number : MonoBehaviour
{
	public Text text;
	public GameObject count;

	public GameObject person;

	//private int coins;
	// Use this for initialization
	void Start()
	{
		//coins = helicopter.GetComponent<HeliController>().coinTotal;
		//coins = count.GetComponent<MazeCounter>().coins;
		// mazenumber++;
		// text.text = "Coins: " + MazeCounter.coins;
	}

	// Update is called once per frame
	void Update()
	{
		if (MazeCounter.inPlay == true)
		{
			text.text = "Maze: " + MazeCounter.coins;
		}
		else
		{
			text.text = " ";
		}
	}
}
