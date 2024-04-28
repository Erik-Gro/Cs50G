using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrabPickups : MonoBehaviour
{

	private AudioSource pickupSoundSource;

	void Awake()
	{
		pickupSoundSource = DontDestroy.instance.GetComponents<AudioSource>()[1];
	}
	void Update()
	{
		if (transform.position.y < -15.5f)
		{
			MazeCounter.coins = 0;
			MazeCounter.inPlay = false;
			Destroy(GameObject.Find("WhisperSource"));
			SceneManager.LoadScene("GameOver");
		}
	}
	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.gameObject.tag == "Pickup")
		{
			MazeCounter.coins++;
			pickupSoundSource.Play();
			SceneManager.LoadScene("Play");
		}
	}
}
