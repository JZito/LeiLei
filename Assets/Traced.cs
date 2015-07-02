using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Traced : MonoBehaviour {
	
	//each strike in order
	//public TraceTrigger[] triggers;
	//public List<TraceTrigger> connectedTriggers = new List<TraceTrigger>();
	//public RectTransform imageRectTransform;
	public GameObject letter;
	//public GameObject lineCanvas;
	//TraceTrigger nextTrigger;
	//bool inLines = false;
	TraceOutlineCheck traceCheck;
	
	void Start () {
		traceCheck = letter.GetComponent<TraceOutlineCheck> ();
	}
	
	
	// Update is called once per frame
	void Update () {
		if (traceCheck.insideLines) {
			print ("inLines");		
		}

		else if (!traceCheck.insideLines) {
			print ("false dude");
		}
		// reset on touch release
	
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