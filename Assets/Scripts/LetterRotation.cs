using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LetterRotation : MonoBehaviour {

	public TraceStepHandler[] letters;
	private int counter;

	// Use this for initialization
	void Start () {
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (counter < letters.Length) {
			if (letters[counter].complete) {
				letters[counter].gameObject.SetActive(false);
				counter++;
				if (counter >= letters.Length) {
					print("zero zero");
					Application.LoadLevel(Application.loadedLevel);
					//counter = 0;
				}
				letters[counter].gameObject.SetActive(true);
			}
		}
	}
}
