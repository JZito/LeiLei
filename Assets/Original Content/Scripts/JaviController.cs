using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class JaviController : MonoBehaviour {

	public List<AudioClip> dialogue = new List<AudioClip> ();
//	public MouthScript mouth;
//	public Eyebrows brows;
//	public Eyeballs eyes;
	public Puppet puppet;
//	public Arm rightArm;
	public GameObject letter;
	public float amp;
	private float[] smooth = new float[2];
//	public GameObject trace;
	[SerializeField]
//	public Button playButton;

	void Start () {
		puppet.isSpeaking = false;
		GetComponent<AudioSource>().clip = dialogue [0];
		print ("ok i'm working");
		for (int i = 0; i < 2; i++) {
			smooth [i] = 0.0f;	
		}
		StartCoroutineSpeak ();
	}

	void StartCoroutineSpeak ()	{
		print ("start coroutine in method");
			StartCoroutine (JaviTalking());
	}
	
	void Update () {
		// Check for animation triggers
		puppet.eyebrows.SetBool ("browsRaise", puppet.raiseBrows);
		puppet.rightArm.SetBool ("armWaving", puppet.armWave);
		puppet.rightArm.SetBool ("armPointing", puppet.armPoint);
		puppet.mouth.SetBool ("speaking", puppet.isSpeaking);
		puppet.eyes.SetBool ("eyesClosed", puppet.closeEyes);
		puppet.animatorPuppet.SetBool ("walkingLeft", puppet.walkLeft);
		puppet.animatorPuppet.SetBool ("headTilt", puppet.tiltHead);
		if (amp >= .55) {
			puppet.isSpeaking = true;
		}
		else {
			puppet.isSpeaking = false;
		}

	
	}
	
	IEnumerator JaviTalking ()
	{
		puppet.tiltHead = true;
		puppet.raiseBrows = true;
		puppet.armWave = true;
		puppet.closeEyes = true;
		yield return new WaitForSeconds (2f);
		puppet.raiseBrows = false;
		//mouth.isSpeaking = false;
		puppet.closeEyes = false;
		GetComponent<AudioSource>().Play ();
		//mouth.isSpeaking = true;
		puppet.tiltHead = false;
		puppet.raiseBrows = false;

		yield return new WaitForSeconds (GetComponent<AudioSource>().clip.length);
		//mouth.isSpeaking = false;
		yield return new WaitForSeconds (1f);
		GetComponent<AudioSource>().clip = dialogue [1];
		GetComponent<AudioSource>().Play ();
		puppet.armWave = false;

		puppet.walkLeft = true;
		//mouth.isSpeaking = true;
		yield return new WaitForSeconds (GetComponent<AudioSource>().clip.length);
		//mouth.isSpeaking = false;
		puppet.armPoint = true;
		yield return new WaitForSeconds (1f);
		puppet.raiseBrows = true;
		GetComponent<AudioSource>().clip = dialogue [2];

		GetComponent<AudioSource>().Play ();
		//mouth.isSpeaking = true;

		puppet.closeEyes = true;
		letter.gameObject.SetActive (true); // turn on letter A
		yield return new WaitForSeconds (GetComponent<AudioSource>().clip.length);
		puppet.closeEyes = false;
		//mouth.isSpeaking = false;
		puppet.raiseBrows = false;
		puppet.armPoint = false;
//		trace.SetActive (true);
		yield return null;

	}

	void OnAudioFilterRead (float[] data, int channels)
	{		
		for (var i = 0; i < data.Length; i = i + channels) {
			// the absolute value of every sample
			float absInput = Mathf.Abs(data[i]);
			// smoothening filter doing its thing
			smooth[0] = ((0.01f * absInput) + (0.99f * smooth[1]));
			// exaggerating the amplitude
			amp = smooth[0]*7;
			// it is a recursive filter, so it is doing its recursive thing
			smooth[1] = smooth[0];
		}
	}


}
