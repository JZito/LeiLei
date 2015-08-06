using UnityEngine;
using System.Collections;

public class FadeTo : MonoBehaviour {

	public bool fadeTrigger;
	public bool zoomIn;
	public bool zoomBack = false;
	public bool fadeFinish = false;
	public GameObject solidLetter;
	public GameObject window;
	public Sprite completeSpriteSpanish;
	public Sprite completeSpriteEnglish;

	private float curScale;
	private float targetScale;
	private float targetScale2;
	private float targetScale3;
	private float shrinkSpeed;

	// Use this for initialization
	void Start () {

		targetScale = 1f;
		targetScale3 = .9f;
		targetScale2 = 1.075f;
		shrinkSpeed = 4f;
		zoomIn = true;
		//curScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (zoomIn) {
			curScale = Mathf.MoveTowards (curScale, targetScale, Time.deltaTime * shrinkSpeed);
			gameObject.transform.localScale = new Vector3 (curScale, curScale, curScale);
			if (curScale >= targetScale) {
				zoomIn=false;
				zoomBack = true;
				Debug.Log("zoom");
			}		
		}
		else if (zoomBack){
			Debug.Log("boo");
//			if (curScale <= targetScale) {
				curScale = Mathf.MoveTowards (curScale, targetScale3, Time.deltaTime * shrinkSpeed);
				gameObject.transform.localScale = new Vector3 (curScale, curScale, curScale);
			if (curScale <= targetScale3) {
				Debug.Log("yooo");
				StartCoroutine (Fade(0, .5f));
				//zoomIn = false;
				zoomBack = false;
				fadeTrigger = true;
			}	
		}
		else if (fadeFinish) {
			StartCoroutine (FadeEnd (1, .5f));
			fadeFinish = false;
		}
	}

	public IEnumerator FadeEnd(float aValue, float aTime)
	{
		print ("started");
		int languageTicker = PlayerPrefs.GetInt ("Spanish");
		if (languageTicker == 0) {
			window.GetComponent<SpriteRenderer>().sprite = completeSpriteSpanish;	
		} 
		else if (languageTicker == 1) {
			window.GetComponent<SpriteRenderer>().sprite = completeSpriteEnglish;
		}

		this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
		float alpha = transform.GetComponent<Renderer>().material.color.a;
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime) {
			Color newColor = new Color (1, 1, 1, Mathf.Lerp (alpha, aValue, t));
			transform.GetComponent<Renderer>().material.color = newColor;
			yield return null;
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
		this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
		//}
	}
}
