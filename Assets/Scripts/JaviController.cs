using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class JaviController : MonoBehaviour {

	public List<AudioClip> dialogue = new List<AudioClip> ();
	public MouthScript mouth;
	public Eyebrows brows;
	public Eyeballs eyes;
	public GameObject letter;
	public GameObject trace;
	[SerializeField]
	public Button playButton;

	void Start () {
		mouth.isSpeaking = false;
		GetComponent<AudioSource>().clip = dialogue [0];
		playButton.onClick.AddListener (() => {
						StartCoroutineSpeak ();});
	}

	void StartCoroutineSpeak ()
		{
			StartCoroutine (JaviTalking());
		}
	
	void Update () {
		// Check for animation triggers
		brows.animatorBrows.SetBool ("RaiseBrow", brows.raiseBrows);
		mouth.animatorMouth.SetBool ("Speaking", mouth.isSpeaking);
		eyes.animatorEyes.SetBool ("EyesClosed", eyes.closeEyes);
	
	}
	
	IEnumerator JaviTalking ()
	{
		brows.raiseBrows = false;
		mouth.isSpeaking = false;
		eyes.closeEyes = false;
		GetComponent<AudioSource>().Play ();
		mouth.isSpeaking = true;
		yield return new WaitForSeconds (GetComponent<AudioSource>().clip.length);
		mouth.isSpeaking = false;
		yield return new WaitForSeconds (1f);
		GetComponent<AudioSource>().clip = dialogue [1];
		GetComponent<AudioSource>().Play ();
		mouth.isSpeaking = true;
		yield return new WaitForSeconds (GetComponent<AudioSource>().clip.length);
		mouth.isSpeaking = false;
		yield return new WaitForSeconds (1f);
		GetComponent<AudioSource>().clip = dialogue [2];
		GetComponent<AudioSource>().Play ();
		mouth.isSpeaking = true;
		brows.raiseBrows = true;
		eyes.closeEyes = true;
		letter.gameObject.SetActive (true); // turn on letter A
		yield return new WaitForSeconds (GetComponent<AudioSource>().clip.length);
		eyes.closeEyes = false;
		mouth.isSpeaking = false;
		brows.raiseBrows = false;
		trace.SetActive (true);
		yield return null;

	}
}
