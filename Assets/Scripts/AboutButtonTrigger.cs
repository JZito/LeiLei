using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AboutButtonTrigger : MonoBehaviour {

	public UIManager uiManage;
	public GameObject aboutSpanishScreen;
	public GameObject aboutEnglishScreen;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTouchDown() {
		uiManage.SwitchToAboutPage ();
	}
}
