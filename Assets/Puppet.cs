using UnityEngine;
using System.Collections;

public class Puppet : MonoBehaviour {
	
	public Animator animatorPuppet;
	public Animator rightArm;
	//public Animator leftLeg;
	//public Animator rightLeg;
	public Animator mouth;
	public Animator eyes;
	public Animator eyebrows;
	// puppet bools
	public bool walkLeft = false;
	public bool tiltHead = false;
	// arms bools
	public bool armWave = false;
	public bool armPoint = false;
	// brows bools
	public bool raiseBrows;
	// eyes bools
	public bool closeEyes;
	// mouth bools
	public bool isSpeaking;
	//
	
	// Use this for initialization
	void Start () {
		
		animatorPuppet = GetComponent<Animator> ();
		//animatorArm.SetBool ("RaiseBrow", armWave);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
