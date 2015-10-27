using UnityEngine;
using System.Collections;

public class LetterSelection : MonoBehaviour {

	public GameObject soundArray;
	private float curScale;
	private int idInt;
	private bool shrink;
	private bool unShrink;
	public float targetScale;
	public float shrinkSpeed;
	public float shrinkVariable;
	
	
	
	// Use this for initialization
	void Start () {
		//curScale = .65f;
		//shrinkVariable = .9f;
		targetScale = this.gameObject.transform.localScale.x;
		// declare a string variable with a value that represents a valid integer
		string idString = this.gameObject.name;
		
		
		// attempt to parse the value using the TryParse functionality of the integer type
		int.TryParse(idString, out idInt);
		
		Debug.Log(idInt);//9001		this.gameObject.name;
		
	}
	
	void Update() {
		//		Debug.Log (curScale);
		if (shrink) {
			curScale = this.gameObject.transform.localScale.x * shrinkVariable;
			curScale = Mathf.MoveTowards (curScale, targetScale, Time.deltaTime * shrinkSpeed);
			gameObject.transform.localScale = new Vector3 (curScale, curScale, curScale);
			if (curScale <= targetScale) {
				Debug.Log ("<=");
				shrink = false;
				unShrink = true;
				
			}
		}
		else if (unShrink) {
			//targetScale = .65f;
			//curScale = .5f;
			curScale = Mathf.MoveTowards (curScale, targetScale, Time.deltaTime * shrinkSpeed);
			gameObject.transform.localScale = new Vector3 (curScale, curScale, curScale);
			if (curScale >= targetScale){
				unShrink = false;
				
			}
		}
	}
	
	public void ButtonTouch () {
		StartCoroutine ( PlaySound () );
		
	}
	
	IEnumerator PlaySound() {
		PlayerPrefs.SetInt ("letterInt", idInt);
		bool span = GameObject.Find ("UIManage").GetComponent<UIManager>().spanish;
		if (!span) {
			Debug.Log ("spanish");
			soundArray.GetComponent<AudioSource>().clip = soundArray.GetComponent<SoundArray>().englishSounds[idInt];
		}
		else if (span) {
			Debug.Log ("english");
			soundArray.GetComponent<AudioSource>().clip = soundArray.GetComponent<SoundArray>().spanishSounds[idInt];
		}
		soundArray.GetComponent<AudioSource> ().Play ();
		
		shrink = true;
		
		yield return new WaitForSeconds (soundArray.GetComponent<AudioSource>().clip.length + .5f);
		LoadLetter ();
		
		
	}
	
	void LoadLetter() {
		//GameObject gameScreen = GameObject.Instantiate(gameplayScreen, Vector3., Quaternion.identity) as GameObject;
		//		gameplayScreen.gameObject.SetActive (true);
		//		selectionScreen.gameObject.SetActive (false);
		Application.LoadLevel ("letterA");
	}
}
