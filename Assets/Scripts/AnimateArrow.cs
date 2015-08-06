using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimateArrow : MonoBehaviour {

	public Vector3[] p;
	public string pathName;
	public GameObject pathObject;
	public float timeCounter;
	public float trailTime;
	public float lookTime;
	public int animationTime;
	public GameObject arrow;
	public GameObject fader;
	public GameObject point0;
	public GameObject point1;
	public TraceTrigger pointA;
	public TraceTrigger pointB;
	public bool curve;
	public int compensation;
	public int moreCompensation;
	private int ogCompensation;
	private List<GameObject> arrows = new List<GameObject>();
	private bool stop;
	//public float fader;

	// Use this for initialization
	void Start () {
		ogCompensation = compensation;
		//set original compensation so animation resets, determine itween path params

		//p = iTweenPath.GetPath("pathroll");
		StartCoroutine (PauseBriefly ());
	}

	IEnumerator PauseBriefly() {

		yield return new WaitForSeconds (0.25f);
		GetComponent<AudioSource> ().Play ();
		point0.gameObject.SetActive (true);
		yield return new WaitForSeconds (0.125f);
		GetComponent<AudioSource> ().Play ();
		point1.gameObject.SetActive (true);

		yield return new WaitForSeconds (0.125f);

		iTween.MoveTo(arrow, iTween.Hash("path",iTweenPath.GetPath(pathName),"lookTime", lookTime,"moveToPath", false,"easetype",  "linear", "looptype", "none", "lookahead", 0.0001, "onComplete", "LastOne", "oncompletetarget", this.gameObject,"time",animationTime));
		Debug.Log ("second paused");
	}
	
	// Update is called once per frame
	void Update () {
		//
		Vector3 moveDirection = arrow.transform.position; 
		if (moveDirection != Vector3.zero) 
		{

			if (curve){
				//if it's a curve we gotta make the arrow turn
				float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
				arrow.transform.rotation = Quaternion.AngleAxis(angle - compensation, Vector3.forward);
			}

		}

		timeCounter += Time.deltaTime;
		if (timeCounter >= trailTime)
		{
			if (!stop) {
			// create a new arrow prefab in a fading trail
				timeCounter = 0;
				GameObject f = Instantiate(fader, new Vector3(arrow.transform.position.x, arrow.transform.position.y, arrow.transform.position.z + 1), arrow.transform.rotation) as GameObject;
				SpriteRenderer faderSprite = f.GetComponent<SpriteRenderer>();
				faderSprite.sprite = arrow.GetComponent<SpriteRenderer>().sprite;
				arrows.Add(f);
				f.GetComponent<FadeMaterials>().FadeOut();
				//further adjust for the curve if necessary based on each step
				compensation = compensation + moreCompensation ;
			}
			else if (stop) {
				
			}
		}
	}
	IEnumerator LoopIt() {
		yield return new WaitForSeconds (5f);
		for (int j = 0; j < arrows.Count; j++) {
			GameObject.Destroy(arrows[j]);
			
			//			po  qintA.touched = false;
			//			pointB.touched = false;
			compensation = ogCompensation;
		}
		//arrow.gameObject.SetActive (true);

		iTween.MoveTo (arrow, iTween.Hash ("path", iTweenPath.GetPath (pathName), "lookTime", lookTime, "moveToPath", false, "easetype", "linear", "looptype", "none", "lookahead", 0.0001, "onComplete", "LastOne", "oncompletetarget", this.gameObject, "time", animationTime));
		stop = false;
	}

	IEnumerator ClearIt() {

		iTween.Stop (this.gameObject, includechildren: true);
//		
		yield return new WaitForSeconds (2f);
		// get rid of the arrows and reset arrow curve compensation
		
		for (int j = 0; j < arrows.Count; j++) {
			GameObject.Destroy(arrows[j]);
			
			//			po  qintA.touched = false;
			//			pointB.touched = false;
			compensation = ogCompensation;
		}
		//stop = true;
	}
	public void ClearArrows () {

		point0.gameObject.GetComponent<SpriteRenderer>().enabled = false;
		point1.gameObject.GetComponent<SpriteRenderer>().enabled = false;
		arrow.gameObject.GetComponent<SpriteRenderer>().enabled = false;
		LastOne ();
		StartCoroutine (ClearIt ());
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
