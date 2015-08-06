using UnityEngine;
using System.Collections;

public class ParticleLayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<ParticleSystem> ().GetComponent<Renderer>().sortingLayerName = "tippy top";
		Debug.Log (GetComponent<ParticleSystem> ().GetComponent<Renderer> ().sortingLayerName);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
