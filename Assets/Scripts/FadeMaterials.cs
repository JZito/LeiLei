using UnityEngine;
using System.Collections;

public class FadeMaterials : MonoBehaviour {

	public float fadeTime;
	
	public void FadeOut() {
		iTween.ValueTo(gameObject, iTween.Hash(
			"from", 1.0f, "to", 0.0f,
			"time", fadeTime, "easetype", "linear",
			"onupdate", "setAlpha"));
	}
		               
	public void FadeIn() {
		iTween.ValueTo(gameObject, iTween.Hash(
			"from", 0f, "to", 1f,
			"time", fadeTime, "easetype", "linear",
			"onupdate", "setAlpha"));
	}
			               
	public void setAlpha(float newAlpha) {
//		foreach (Material mObj in renderer.materials) {	
		var mObj = GetComponent<SpriteRenderer> ();
			mObj.color = new Color(
				mObj.color.r, mObj.color.g, 
				mObj.color.b, newAlpha);
					
//		}
				
	}
			
}
