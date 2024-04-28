using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetAxis("Submit") == 1)
		{
			MazeCounter.inPlay = true;
			SceneManager.LoadScene("Play");
		}
	}
}
