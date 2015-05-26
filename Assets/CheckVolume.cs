using UnityEngine;
using System.Collections;

public class CheckVolume : MonoBehaviour {

	public AudioSource aud;
	private int qSamples = 1024;  // array size
	private float refValue = 0.1f; // RMS value for 0 dB
	private float rmsValue;   // sound level - RMS
	private float dbValue;    // sound level - dB
	private float vol = 2; // set how much the scale will vary

	
	//private float samples: float[]; // audio samples
	private float[] samples;
	
	void Start () {
		aud = GetComponent<AudioSource>();
		samples = new float[aud.clip.samples * aud.clip.channels];


	}
	
//	void GetVolume(){
//		print ("hi");
//		aud.clip.GetData(samples, 0);
//		int i;
//		float sum = 0;
//		//var sum: float = 0;
//		for (i=0; i < qSamples; i++){
//			sum += samples[i]*samples[i]; // sum squared samples
//		}
//		rmsValue = Mathf.Sqrt(sum/qSamples); // rms = square root of average
//		dbValue = 100*Mathf.Log10(rmsValue/refValue); // calculate dB
//		if (dbValue < -160) dbValue = -160; // clamp it to -160dB min
//
//
//	}


	
	void Update () {
//		GetVolume();
//		var boop = vol * rmsValue;
//		print (dbValue + " dbvalue " + boop);
//		//transform.localScale.y = volume * rmsValue;

	}
}
