using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Tracer : MonoBehaviour {
	
	//each strike in order
	public TraceTrigger[] triggers;
	public List<TraceTrigger> connectedTriggers = new List<TraceTrigger>();
	public RectTransform imageRectTransform;
	public GameObject letter;
	public GameObject lineCanvas;
	TraceTrigger nextTrigger;

	
	// Update is called once per frame
	void Update () {
		// reset on touch release
		if (Input.GetMouseButtonUp (0)) {
			imageRectTransform.sizeDelta = new Vector2 (0, 0);
			for (int i = 0; i < triggers.Length; i++){
				var trig = triggers[i];
				trig.touched = false;
				trig.gameObject.GetComponent<SpriteRenderer>().color= trig.untouchedColor;
				
			}
			
		} else if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0)){
			//Check if there are more triggers to connect
			if (connectedTriggers.Count + 1 < triggers.Length) {

				TraceTrigger currentTrigger = triggers[connectedTriggers.Count];
				
				if (currentTrigger.touched) {
					//advance trigger in array
					nextTrigger = triggers[connectedTriggers.Count + 1];
					// turn on next trigger
					nextTrigger.gameObject.SetActive (true);
					
					//Draw line from current trigger to mouse position
					Vector2 screenPoint = Camera.main.WorldToScreenPoint(currentTrigger.gameObject.transform.position); 
					DrawLine (screenPoint, Input.mousePosition, 5);
					
					if (nextTrigger.touched) {
						//WHEN next trigger touched , connect current trigger with next trigger and start a new line
						Vector2 nextTriggerScreenPoint = Camera.main.WorldToScreenPoint(nextTrigger.gameObject.transform.position); 
						DrawLine (screenPoint, nextTriggerScreenPoint, 5);
						
						//connect next trigger and add it into list of connected triggers
						if (!connectedTriggers.Contains(nextTrigger)) { 
							connectedTriggers.Add(nextTrigger);
							StartNewLine();
						}
					}
				}
			}
			
			else if (connectedTriggers.Count == triggers.Length - 1)
			{
				connectedTriggers.Clear ();
				letter.gameObject.SetActive (false);
				for (int i = 0; i < triggers.Length; i++){
					var trig = triggers[i];
					trig.touched = false;
					trig.gameObject.GetComponent<SpriteRenderer>().color= trig.untouchedColor;
				}
				DestroyChildren (lineCanvas);
				lineCanvas.SetActive(false);
				this.gameObject.SetActive (false);
				letter.gameObject.SetActive (true);

			}
		}
	}
	
	void StartNewLine() {
		if (connectedTriggers.Count < triggers.Length) {
			//assign most recent 
			RectTransform finishedLine = imageRectTransform;

			//create new gameobject for Line but with transform containing unity 5 gui element
			GameObject newLine = new GameObject("Line", typeof(RectTransform));
			newLine.AddComponent<Image>();
			newLine.transform.SetParent(finishedLine.gameObject.transform.parent);
			imageRectTransform = newLine.GetComponent<RectTransform>();
		}
	}
	
	void DrawLine(Vector3 pointA, Vector3 pointB, int lineWidth ) {
		
		Vector3 differenceVector = pointB - pointA;
		imageRectTransform.sizeDelta = new Vector2( differenceVector.magnitude, lineWidth);
		imageRectTransform.pivot = new Vector2(0, 0.5f);
		imageRectTransform.position = pointA;
		float angle = Mathf.Atan2(differenceVector.y, differenceVector.x) * Mathf.Rad2Deg;
		imageRectTransform.rotation = Quaternion.Euler(0,0, angle);
	}

	public static void DestroyChildren(GameObject go)
	{
		List<GameObject> children = new List<GameObject>();
		foreach (Transform tran in go.transform)
		{      
			children.Add(tran.gameObject); 
		}
		children.ForEach(child => GameObject.Destroy(child));  
	}
	
	
}