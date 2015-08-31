using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TraceStepHandler : MonoBehaviour {

	public List<AnimateArrow> allSteps = new List<AnimateArrow>();
	public GameObject soundArray;
	public bool complete;
	public List<AnimateArrow> completedSteps = new List<AnimateArrow>();
	public Material mat;
	private int counter = 0;
	private AnimateArrow currentStep;
	private GameObject finalStep;
	private bool aTouched = false;
	private bool bTouched = false;
	//public GameObject trail;
	private GameObject texturedLetter;

	// RENDERER
	public Color c1;
	public Color c2;
	private GameObject lineGO;
	private LineRenderer lineRenderer;
	private int i = 0;
	private bool drawLine;


	//public GameObject letter;

	// Use this for initialization
	void Start () {
		texturedLetter = GameObject.Find ("TexturedLetter");
		counter = 0;
		complete = false;

		// RENDERER
		lineGO = new GameObject("Line");
		lineGO.AddComponent<LineRenderer>();
		lineRenderer = lineGO.GetComponent<LineRenderer>();
		lineRenderer.material = mat;
		lineRenderer.SetColors(c2, c1);
		lineRenderer.SetWidth(0.25F, .35f);
		lineRenderer.SetVertexCount(0);
		lineRenderer.sortingLayerName = "tippy top";

// 		StartCoroutine (FadeTo (0f, 1.5f));
//		finalStep = steps [steps.Length];
	
	}

	void Complete () {
		//Application.LoadLevel ("selection");
		Debug.Log ("complete function");
		StartCoroutine (PlaySound ());
		texturedLetter.GetComponent<FadeTo> ().fadeFinish = true;
	}

	void RenderLine () {
		lineRenderer.SetVertexCount(i+1);
		Vector3 mPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
		lineRenderer.SetPosition(i, Camera.main.ScreenToWorldPoint(mPosition));
		i++;
	}
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			
			if(touch.phase == TouchPhase.Moved)
			{
				if (aTouched) {
					lineRenderer.SetVertexCount(i+1);
					Vector3 mPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
					lineRenderer.SetPosition(i, Camera.main.ScreenToWorldPoint(mPosition));
					i++;
				}
			}
			if(touch.phase == TouchPhase.Ended)
			{
				/* Remove Line */
				currentStep.pointA.touched = false;
				lineRenderer.SetVertexCount(0);
				i = 0;
			}
		}
//		if (Input.GetMouseButtonUp(0)){
//
//		}
		if (aTouched && bTouched) {
			Debug.Log ("a and b, finished");
			currentStep.ClearArrows();
			lineRenderer.SetVertexCount(0);
			i = 0;
			aTouched=false;
			bTouched=false;
			if (counter + 1 < allSteps.Count){
				counter++;
				allSteps [counter].gameObject.SetActive (true);
			}
			else if (counter + 1 >= allSteps.Count){
				Complete ();	
				complete = true;
			}
		}
		currentStep = allSteps [counter];
//		Debug.Log("atouched");
		if (currentStep.pointA.touched) {
		//	RenderLine ();
		//	trail.GetComponent<Renderer>().enabled = true;
			aTouched = true;
			if (currentStep.pointB.touched) {
				Debug.Log("btouched");
				bTouched= true;
			}
		}
	}

	IEnumerator PlaySound() {
		int span = PlayerPrefs.GetInt ("Spanish");
		int idNum = PlayerPrefs.GetInt ("letterInt");
		if (span == 1) {
			//Debug.Log ("english");
			soundArray.GetComponent<AudioSource>().clip = soundArray.GetComponent<SoundArray>().englishSounds[idNum];
		}
		else if (span == 0) {
			//Debug.Log ("spanish");
			soundArray.GetComponent<AudioSource>().clip = soundArray.GetComponent<SoundArray>().spanishSounds[idNum];
		}
		yield return new WaitForSeconds (.1f);
		soundArray.GetComponent<AudioSource> ().Play ();
		yield return null;
		
		
	}
}