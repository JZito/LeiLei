using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimateArrow : MonoBehaviour {

	public Vector3[] p;
	public string pathName;
	public float timeCounter;
	public float trailTime;
	public int animationTime;
	public GameObject arrow;
	public GameObject fader;
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
		iTween.MoveTo(arrow, iTween.Hash("path",iTweenPath.GetPath(pathName),"lookTime", 0.2,"moveToPath", false,"easetype",  "linear", "looptype", "none", "lookahead", 0.0001, "onComplete", "ClearArrows", "oncompletetarget", this.gameObject,"time",animationTime));
		//p = iTweenPath.GetPath("pathroll");
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

	public void ClearArrows () {
		arrow.gameObject.SetActive(false);
		// get rid of the arrows and reset arrow curve compensation
		for (int j = 0; j < arrows.Count; j++) {
			GameObject.Destroy(arrows[j]);

			pointA.touched = false;
			pointB.touched = false;
			compensation = ogCompensation;
		}
		stop = true;
	}

//	void OnDrawGizmos()
//	{
//		iTween.DrawPath(p);
//	}
}
