﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchInput : MonoBehaviour {

	public LayerMask touchInputMask;

	private List<GameObject> touchList = new List<GameObject>();
	private GameObject[] touchesOld;
	private RaycastHit hit;
	
	// Update is called once per frame
	void Update () {

#if UNITY_EDITOR

		if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0)) {

			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo(touchesOld);
			touchList.Clear();
				
			RaycastHit2D hit = Physics2D.Raycast(GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), Vector2.zero);   
				
			if(hit.collider!=null) {
					
				GameObject recipient = hit.transform.gameObject;
				touchList.Add(recipient);
				
				if (Input.GetMouseButtonDown(0)) {
					recipient.SendMessage("OnTouchDown",hit.point,SendMessageOptions.DontRequireReceiver);
				}
				if (Input.GetMouseButtonUp(0)) {
					recipient.SendMessage("OnTouchUp",hit.point,SendMessageOptions.DontRequireReceiver);
				}
				if (Input.GetMouseButton(0)) {
					recipient.SendMessage("OnTouchStay",hit.point,SendMessageOptions.DontRequireReceiver);
				}
			}
		}

#endif 

		if (Input.touchCount > 0) {

			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo(touchesOld);
			touchList.Clear();

		foreach (Touch touch in Input.touches) {

			RaycastHit2D hit = Physics2D.Raycast(GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), Vector2.zero);   
			
				if(hit.collider!=null) {

					GameObject recipient = hit.transform.gameObject;
					touchList.Add (recipient);

					if (touch.phase == TouchPhase.Began) {
						recipient.SendMessage("OnTouchDown", hit.point,SendMessageOptions.DontRequireReceiver);
					}
					if (touch.phase == TouchPhase.Ended) {
						recipient.SendMessage("OnTouchUp",hit.point,SendMessageOptions.DontRequireReceiver);	
					}
					if (touch.phase == TouchPhase.Stationary) {
						recipient.SendMessage("OnTouchStay",hit.point,SendMessageOptions.DontRequireReceiver);	
					}
					if (touch.phase == TouchPhase.Moved) {
						recipient.SendMessage("OnTouchStay",hit.point,SendMessageOptions.DontRequireReceiver);	
					}
					if (touch.phase == TouchPhase.Canceled) {
						recipient.SendMessage("OnTouchExit",hit.point,SendMessageOptions.DontRequireReceiver);
					}
				}
			}
		}
	}
}