using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	enum eState
	{
		INVALID_STATE = -1,
		WAIT_TO_START,
		LOADING,
		INTRODUCE_LETTER,
		WAITING_FOR_USER,
		START_OVER,
		NUM_STATES
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
