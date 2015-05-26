using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LanguageSelect : MonoBehaviour {

	//public Button spanishButton;
	public bool english;
	public Button englishButton;
	public Button spanishButton;
	public Animator animatorSpanish;
	public Animator animatorEnglish;
	public GameObject puppet;
	public GameObject set;


	// Use this for initialization
	void Start () {
		animatorEnglish.SetBool ("slideOver", false);
		animatorSpanish.SetBool ("panelMove", false);
		english = false;

		spanishButton.onClick.AddListener (() => {
			BeginAppisode(false);});
		englishButton.onClick.AddListener (() => {
			BeginAppisode(true);

		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void BeginAppisode (bool eng) {
		puppet.gameObject.SetActive (true); 
		set.gameObject.SetActive (true);
		//if (eng == true) {
		english = eng;
		animatorEnglish.SetBool ("slideOver", true);
		animatorSpanish.SetBool ("panelMove", true);
		
//		else 
//		{
//			animatorSpanish.SetBool ("slideNow", true);
//			animatorEnglish.SetBool ("slideOver", true);
//		}

	}
}
