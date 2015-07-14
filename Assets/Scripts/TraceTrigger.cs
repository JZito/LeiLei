using UnityEngine;
using System.Collections;

public class TraceTrigger : MonoBehaviour {

	public Color untouchedColor = new Color();
	public Color touchedColor =  new Color();
	public SpriteRenderer dot;
	public bool touched = false;

	// Use this for initialization
	void Start () {
		dot = this.GetComponent<SpriteRenderer> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTouchDown () {
//		Debug.Log ("ON COLLISION");
		dot.color = touchedColor;
		touched = true;

	}

	void OnTouchStay () {
		dot.color = touchedColor;
		touched = true;
	}

	void OnTouchExit () {
		dot.color = untouchedColor;
	//	touched = false;
	}

}
