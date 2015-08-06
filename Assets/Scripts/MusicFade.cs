using UnityEngine;
using System.Collections;

public class MusicFade : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void FadeMusicOut (float seconds)
	{
		StartCoroutine (FadeMusicOutCoroutine (seconds));
	}

	IEnumerator FadeMusicOutCoroutine(float seconds)
	{
		var audioSourceVolume = GetComponent<AudioSource> ();
		float volume = 1;
		float t = 0;
		//print ("fade out");
		yield return new WaitForSeconds (5f);
		//print ("fade out waited");
		while(t < 1)
		{
			t += Time.deltaTime/seconds;
			volume = Mathf.Lerp(0.8f, 0, t);
			audioSourceVolume.volume = volume;
			yield return null;
		}
		//	print ("finished fade out");
	}
}
