using UnityEngine;
using System.Collections;

public class LetterRotation : MonoBehaviour {

	public TraceStepHandler[] letters;
	private int counter;

	// Use this for initialization
	void Start () {
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (counter > letters.Length) {
			counter = 0;
		}
		else if (counter <= letters.Length) {
			if (letters[counter].complete) {
				letters[counter].gameObject.SetActive(false);
				counter++;
				letters[counter].gameObject.SetActive(true);
			}
		}
	}
}
