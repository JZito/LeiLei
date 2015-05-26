using UnityEngine;
using System.Collections;

public class MouthScript : MonoBehaviour {

	public bool isSpeaking;
	public Animator animatorMouth;

	// Use this for initialization
	void Start () 
	{
		animatorMouth = GetComponent<Animator>();
		//animatorMouth.SetBool ("isSpeaking", true);
	
	}
}
