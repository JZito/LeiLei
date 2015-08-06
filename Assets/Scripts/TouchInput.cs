using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchInput : MonoBehaviour {

	public LayerMask touchInputMask;
	public GameObject trail;

	private List<GameObject> touchList = new List<GameObject>();
	private GameObject[] touchesOld;
	private RaycastHit hit;
	
	// Update is called once per frame
	void Update () {
		// START OFF TOMORROW DOING THE FOLLOWING
		// ATTACH PREFAB
		//BREAK APART FUNCTIONS, IF DOWN INSTANTIATE PREFAB
		// IF UP DESTROY IT
		// IF CURRENT EVERYTHING ELSE
		//ADAPT FOR TOUCH AS WELL
#if UNITY_EDITOR


		if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0)) {

			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo(touchesOld);
			touchList.Clear();

			RaycastHit2D hit = Physics2D.Raycast(GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), Vector2.zero);   
			//trail.transform.position = Vector3.Lerp(trail.transform.position, GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), Time.deltaTime * 100f );
			if(hit.collider!=null) {
					
				GameObject recipient = hit.transform.gameObject;
				touchList.Add(recipient);
				
				if (Input.GetMouseButtonDown(0)) {
					recipient.SendMessage("OnTouchDown",hit.point,SendMessageOptions.DontRequireReceiver);
				//	trail.gameObject.SetActive(true);
				//	trail.transform.position = hit.point;
				}
				if (Input.GetMouseButtonUp(0)) {
					recipient.SendMessage("OnTouchUp",hit.point,SendMessageOptions.DontRequireReceiver);
					Debug.Log ("up");
				//	trail.gameObject.SetActive(false);
					//trail.GetComponent<ParticleSystem>().enableEmission = false;
					//trail.transform.position = hit.point;
				}
				if (Input.GetMouseButton(0)) {
					recipient.SendMessage("OnTouchStay",hit.point,SendMessageOptions.DontRequireReceiver);
				//	trail.transform.position = Vector3.Lerp(trail.transform.position, hit.point, Time.deltaTime * 100f );

				}
			}
		}

#endif 
	
		if (Input.touchCount > 0) {

			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo(touchesOld);
			touchList.Clear();
			Touch touch = Input.GetTouch(0);
	//	foreach (Touch touch in Input.touches) {

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
	//		}
		}
	}
}