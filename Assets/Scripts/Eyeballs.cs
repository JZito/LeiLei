using UnityEngine;
using System.Collections;

public class Eyeballs : MonoBehaviour {

	public Animator animatorEyes;
	public bool closeEyes;
	
	// Use this for initialization
	void Start () {
		animatorEyes = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
