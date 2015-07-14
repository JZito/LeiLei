using UnityEngine;
using System.Collections;

public class TraceOutlineCheck : MonoBehaviour {

	public PolygonCollider2D polyCol;
	public bool insideLines = false;


	// Use this for initialization
	void Start () {
		polyCol = GetComponent<PolygonCollider2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTouchStay () {
		insideLines = true;

	}

	void OnTouchExit () {
		insideLines = false;
	}

	void OnTouchUp () {
		insideLines = false;
	}
}
