using UnityEngine;
using System.Collections;

public class RecordPlayerScript : MonoBehaviour {
	AudioSource melody;
	public float timeBetweenSounds = 5.0f;

	void Start () {
        melody = GetComponent<AudioSource>();
        StartCoroutine(SoundLoop());

	}
	
     IEnumerator SoundLoop(){
         while(true) {
             yield return new WaitForSeconds(melody.clip.length + timeBetweenSounds);
             melody.Play();
         }
     }
}
