using UnityEngine;
using System.Collections;

public class FadeScript : MonoBehaviour {

	public bool FadeTrigger;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine (FadeTo (0f, 1.5f));
	}
		
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator FadeTo(float aValue, float aTime)
	{
		print ("started");
		if (FadeTrigger) {
			print ("continued");
			float alpha = transform.GetComponent<Renderer>().material.color.a;
			for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime) {
				Color newColor = new Color (1, 1, 1, Mathf.Lerp (alpha, aValue, t));
				transform.GetComponent<Renderer>().material.color = newColor;
				yield return null;
			}
		}
	}
}
