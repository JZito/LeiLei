using UnityEngine;
using System.Collections;

public class Eyebrows : MonoBehaviour {

	public Animator animatorBrows;
	public bool raiseBrows;

	void Awake ()
	{
		raiseBrows = false;
		print ("Awake");
	}

	// Use this for initialization
	void Start () 
	{
		animatorBrows = GetComponent<Animator>();

	}

	void MakeAnimationGo() 
	{

	}
	
	// Update is called once per frame
	void Update () {


	
	}
}
