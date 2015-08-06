using UnityEngine;
using System.Collections;

public class CameraPreserver : MonoBehaviour {

	//public GameObject letter;

	private static CameraPreserver instance = null;
	public static CameraPreserver Instance 
	{
		get { return instance; }
	}
	
	void Awake() 
	{
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
}
