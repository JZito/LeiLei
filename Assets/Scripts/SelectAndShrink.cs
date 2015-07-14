using UnityEngine;
using System.Collections;

public class SelectAndShrink : MonoBehaviour {

	public GameObject letterToLoad;
	public GameObject selectionScreen;
	public GameObject gameplayScreen;

	private float curScale;
	private bool shrink;
	private bool unShrink;
	public float targetScale;
	public float shrinkSpeed;
	

	
	// Use this for initialization
	void Start () {
		curScale = .65f;
	
	}
	
	void Update() {
//		Debug.Log (curScale);
		if (shrink) {
			curScale = Mathf.MoveTowards (curScale, targetScale, Time.deltaTime * shrinkSpeed);
			gameObject.transform.localScale = new Vector3 (curScale, curScale, curScale);
			if (curScale <= targetScale) {
				Debug.Log ("<=");
				shrink = false;
				unShrink = true;

			}
		}
		else if (unShrink) {
			targetScale = .65f;
			//curScale = .5f;
			curScale = Mathf.MoveTowards (curScale, targetScale, Time.deltaTime * shrinkSpeed);
			gameObject.transform.localScale = new Vector3 (curScale, curScale, curScale);
			if (curScale >= targetScale){
				unShrink = false;
				LoadLetter();
			}
		}
	}

	void OnTouchDown () {
		shrink = true;
	}

	void LoadLetter() {
		//GameObject gameScreen = GameObject.Instantiate(gameplayScreen, Vector3., Quaternion.identity) as GameObject;
		gameplayScreen.gameObject.SetActive (true);
		selectionScreen.gameObject.SetActive (false);

	}
}
