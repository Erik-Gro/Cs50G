using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource SoundObj;
    public static SoundManager instance;
    private void Awake(){
        if(instance == null){
            instance = this;
        }
    }

    public void PlaySoundFXClip (AudioClip audioClip, Transform spawnTransform, float volume)
{
    AudioSource audioSource = Instantiate (SoundObj, spawnTransform.position, Quaternion.identity);

    audioSource.clip = audioClip;

    audioSource.volume = volume;

    audioSource. Play();

    float clipLength = audioSource.clip.length;

    Destroy(audioSource.gameObject,clipLength);

}



}
