using UnityEngine;
using System.Collections;

public class AScriptOrange : MonoBehaviour {
	
	public bool ATrigger;
	
	public float minimum = 0.0f;
	public float maximum = 1f;
	public float duration = 5.0f;
	private float startTime;
	public SpriteRenderer sprite;

	void Start() {
		startTime = Time.time;
		ATrigger = false;

	}

	void Update() {
		if (ATrigger) {
			print (minimum + maximum + "min max");
						float t = (Time.time - startTime) / duration;
						sprite.color = new Color (1f, 1f, 1f, Mathf.SmoothStep (minimum, maximum, t));  
				} else {
						
				}
		}
}