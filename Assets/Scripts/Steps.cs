using UnityEngine;
using System.Collections;

public class Steps : MonoBehaviour {

	public GameObject loadingScreen;
	public GameObject selectionScreen;
	//public GameObject gameplayScreen;

	// Use this for initialization
	void Start () {
		StartCoroutine (TurnOffIntroScreen ());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTouchDown() {
		SkipAhead ();
	}

	void SkipAhead() {
		Application.LoadLevel ("selection");
	}

	public IEnumerator TurnOffIntroScreen() {
		yield return new WaitForSeconds(5);
		SkipAhead ();
//		selectionScreen.gameObject.SetActive (true);
//		loadingScreen.gameObject.SetActive (false);

	}
}
