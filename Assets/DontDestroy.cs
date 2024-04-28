using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{

	// make this static so it's visible across all instances
	public static DontDestroy instance = null;
	public static int num = 0;

	//public static Text text;
	// singleton pattern; make sure only one of these exists at one time, else we will
	// get an additional set of sounds with every scene reload, layering on the music
	// track indefinitely
	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
		else if (instance = this)
		{
			num++;
		}
	}

	// Use this for initialization
	void Start()
	{

	}
}
