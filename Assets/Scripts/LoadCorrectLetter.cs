using UnityEngine;
using System.Collections;

public class LoadCorrectLetter : MonoBehaviour {

	public GameObject[] letters;
	public int letterInt;
	public bool overrider;

	void Awake () {
		if (!overrider) { 
			int pp = PlayerPrefs.GetInt ("letterInt");
			letters [pp].gameObject.SetActive (true);
		}
		else if (overrider) {
			letters[letterInt].gameObject.SetActive(true);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
