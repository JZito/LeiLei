using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimateArrow : MonoBehaviour {

//	public Vector3[] p;
	public string pathName;
	public GameObject pathObject;
	public float timeCounter;
	public float trailTime;
	public int animationTime;
	public GameObject arrow;
	public GameObject fader;
	public GameObject point0;
	public GameObject point1;
	public GameObject faderArray;
	public TraceTrigger pointA;
	public TraceTrigger pointB;
	public bool curve;
	private List<GameObject> arrows = new List<GameObject>();
	private bool stop;

	// Use this for initialization
	void Start () {
		StartCoroutine ("PauseBriefly");
	}

	IEnumerator PauseBriefly() {

		yield return new WaitForSeconds (0.25f);
		GetComponent<AudioSource> ().Play ();
		point0.gameObject.SetActive (true);
		yield return new WaitForSeconds (0.125f);
		GetComponent<AudioSource> ().Play ();
		point1.gameObject.SetActive (true);

		yield return new WaitForSeconds (0.125f);
		if (!curve) {
			iTween.MoveTo (arrow, iTween.Hash ("path", iTweenPath.GetPath (pathName), "moveToPath", false, "easetype", "linear", "looptype", "none", "lookahead", 0.0001, "onComplete", "LastOne", "oncompletetarget", this.gameObject, "time", animationTime));
		}
		else if (curve) {
			for (int i = 0; i < faderArray.GetComponent<FaderArray>().faders.Length; i++) {
				faderArray.GetComponent<FaderArray>().faders[i].SetActive(true);
				faderArray.GetComponent<FaderArray>().faders[i].GetComponent<FadeMaterials>().FadeOut();
				yield return new WaitForSeconds(trailTime);
			}
		}
			Debug.Log ("second paused");
	}
	
	// Update is called once per frame
	void Update () {
		//

//		if (moveDirection != Vector3.zero) 
//		{
//
//			if (curve){
//				// update direction each frame:
//				Vector3 dir = target - arrow.transform.position;
//				// calculate desired rotation:
//				Vector3 dir2 = new Vector3(0,0,dir.z);
//				Quaternion rot = Quaternion.LookRotation(dir2);
//
//				// Slerp to it over time:
//				arrow.transform.rotation = Quaternion.Slerp(arrow.transform.rotation, rot, turnSpeed * Time.deltaTime);
//				// move in the current forward direction at specified speed:
//				arrow.transform.Translate(0, 0, speed * Time.deltaTime);
//				//if it's a curve we gotta make the arrow turn
////				float angle = Mathf.Atan2(moveDirection.y, moveDirection.x)* Mathf.Rad2Deg; // /(Mathf.PI * 180); //
////				arrow.transform.rotation = Quaternion.LookRotation(angle);
//				//arrow.transform.rotation = Quaternion.AngleAxis(angle - compensation, Vector3.forward);
//			}
//
//		}
		if (!curve) {
			timeCounter += Time.deltaTime;
			if (timeCounter >= trailTime)
			{
				if (!stop) {
	//				if (curve) {
	//					timeCounter = 0;
	//					GameObject f = Instantiate(fader, new Vector3(arrow2.transform.position.x, arrow2.transform.position.y, arrow2.transform.position.z + 1), arrow2.transform.rotation) as GameObject;
	//					SpriteRenderer faderSprite = f.GetComponent<SpriteRenderer>();
	//					faderSprite.sprite = arrow2.GetComponent<SpriteRenderer>().sprite;
	//					arrows.Add(f);
	//					f.GetComponent<FadeMaterials>().FadeOut();
	//					//further adjust for the curve if necessary based on each step
	//					compensation = compensation + moreCompensation ;
	//				}
				// create a new arrow prefab in a fading trail
				
					//Vector3 moveDirection = arrow.transform.position; 
					timeCounter = 0;
					GameObject f = Instantiate(fader, new Vector3(arrow.transform.position.x, arrow.transform.position.y, arrow.transform.position.z + 1), arrow.transform.rotation) as GameObject;
					SpriteRenderer faderSprite = f.GetComponent<SpriteRenderer>();
					faderSprite.sprite = arrow.GetComponent<SpriteRenderer>().sprite;
					arrows.Add(f);
					f.GetComponent<FadeMaterials>().FadeOut();
					

				}
				else if (stop) {
					
				}
			}
		}
	}
	IEnumerator LoopIt() {
		yield return new WaitForSeconds (5f);
		for (int j = 0; j < arrows.Count; j++) {
			GameObject.Destroy(arrows[j]);
			
			//			po  qintA.touched = false;
			//			pointB.touched = false;
		}
		//arrow.gameObject.SetActive (true);

		iTween.MoveTo (arrow, iTween.Hash ("path", iTweenPath.GetPath (pathName), "moveToPath", false, "easetype", "linear", "looptype", "none", "lookahead", 0.0001, "onComplete", "LastOne", "oncompletetarget", this.gameObject, "time", animationTime));
		stop = false;
	}

	IEnumerator ClearIt() {
		Debug.Log ("clearit triggered");
		if (curve) {
			iTween.Stop (this.gameObject, includechildren: true);
		}
		yield return new WaitForSeconds (2f);
		// get rid of the arrows and reset arrow curve compensation
		
		for (int j = 0; j < arrows.Count; j++) {
			GameObject.Destroy(arrows[j]);
		}
	}
	public void ClearArrows () {
		point0.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		point1.gameObject.GetComponent<SpriteRenderer> ().enabled = false;

		if (!curve) {
			arrow.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			LastOne ();
			StartCoroutine (ClearIt ());
		}
		else if (curve) {
			StopCoroutine("PauseBriefly");
			for (int i = 0; i < faderArray.GetComponent<FaderArray>().faders.Length; i++) {
				faderArray.GetComponent<FaderArray>().faders[i].SetActive(false);
			}

		}

	}

	public void LastOne() {
		//arrow.gameObject.SetActive(false);
		stop = true;
		//StartCoroutine (LoopIt ());
	}

//	void OnDrawGizmos()
//	{
//		iTween.DrawPath(p);
//	}
}
