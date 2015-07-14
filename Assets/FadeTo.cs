using UnityEngine;
using System.Collections;

public class FadeTo : MonoBehaviour {

	public bool fadeTrigger;
	public bool zoomIn;
	public GameObject solidLetter;

	private float curScale;
	private float targetScale;
	private float targetScale2;
	private float shrinkSpeed;

	// Use this for initialization
	void Start () {

		targetScale = .9f;
		targetScale2 = 1.1f;
		shrinkSpeed = .45f;
		zoomIn = true;
		//curScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (zoomIn) {
			curScale = Mathf.MoveTowards (curScale, targetScale, Time.deltaTime * shrinkSpeed);
			gameObject.transform.localScale = new Vector3 (curScale, curScale, curScale);
			if (curScale >= targetScale) {
				Debug.Log ("<=");
				StartCoroutine (Fade(0, 1.5f));
				zoomIn = false;
				fadeTrigger = true;
			}		
		}
	}

	public IEnumerator Fade(float aValue, float aTime)
	{
		print ("started");
		//if (fadeTrigger) {
		print ("continued");
		GameObject sl = Instantiate(solidLetter, solidLetter.transform.position, solidLetter.transform.rotation) as GameObject;
		sl.gameObject.SetActive (true);
		sl.gameObject.transform.localScale = new Vector3(targetScale2, targetScale2, 0);
		float alpha = transform.GetComponent<Renderer>().material.color.a;
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime) {
			Color newColor = new Color (1, 1, 1, Mathf.Lerp (alpha, aValue, t));
			transform.GetComponent<Renderer>().material.color = newColor;
			yield return null;
		}
		this.gameObject.SetActive (false);
		//}
	}
}
