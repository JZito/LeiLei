using UnityEngine;
using System.Collections;

public class TraceTrigger : MonoBehaviour {

	public Color untouchedColor = new Color();
	public Color touchedColor =  new Color();
	public SpriteRenderer dot;
	public bool touched = false;
	public bool pointA;
	private bool zoomIn;
	private float curScale;
	private float targetScale;
	private float zoomSpeed;

	// Use this for initialization
	void Start () {
		dot = this.GetComponent<SpriteRenderer> ();
		curScale = 0f;
		targetScale = 1.25f;
		zoomSpeed = 8f;
		zoomIn = true;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (zoomIn) {
			curScale = Mathf.MoveTowards (curScale, targetScale, Time.deltaTime * zoomSpeed);
			gameObject.transform.localScale = new Vector3 (curScale, curScale, curScale);		
		}
		if (touched) {
			if (pointA){
				dot.color = touchedColor;
			}
		}
		else if (!touched) {
			dot.color = untouchedColor;
		}
	
	}
	

	void OnTouchDown () {
		if (pointA) {
		//	dot.color = touchedColor;
			touched = true;
		}
	}

	void OnTouchStay () {
		if (!pointA) {
			//dot.color = touchedColor;
			touched = true;
		}
	}

	void OnTouchUp () {
		Debug.Log ("EXIT");
		//dot.color = untouchedColor;
		touched = false;
	}

}
