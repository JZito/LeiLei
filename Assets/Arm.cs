using UnityEngine;
using System.Collections;

public class Arm : MonoBehaviour {

	public Animator animatorArm;
	public bool armWave = false;
	
	// Use this for initialization
	void Start () {
		
		animatorArm = GetComponent<Animator> ();
		//animatorArm.SetBool ("RaiseBrow", armWave);
	}
	
	// Update is called once per frame
	void Update () {
		
		//animatorArm.SetBool ("armWaving", armWave);
		
	}
}
