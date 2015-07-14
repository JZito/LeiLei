using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public GameObject gameplayScreen;
	public GameObject selectionScreen;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BackToSelection() {
		gameplayScreen.gameObject.SetActive (false);
		selectionScreen.gameObject.SetActive (true);
	}
}
