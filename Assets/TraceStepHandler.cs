using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TraceStepHandler : MonoBehaviour {

	public AnimateArrow[] steps;
	public bool complete;
	public List<AnimateArrow> completedSteps = new List<AnimateArrow>();
	private int counter = 0;
	private AnimateArrow currentStep;
	//public GameObject letter;

	// Use this for initialization
	void Start () {
		counter = 0;
		complete = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (counter >= steps.Length) {
			complete = true;
		} 
		else if (counter < steps.Length) {
			currentStep = steps [counter];
			if (Input.GetMouseButtonUp (0)) {
				currentStep.pointA.GetComponent<SpriteRenderer> ().color = currentStep.pointA.untouchedColor;
			}
			else if (Input.GetMouseButton (0) || Input.GetMouseButtonDown (0)) {
				if (currentStep.pointA.touched) { 
					if (currentStep.pointB.touched) {
						currentStep.gameObject.SetActive (false);
						counter++;
						steps [counter].gameObject.SetActive (true);
					}
				}
			}
		}
	}
}
