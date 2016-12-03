using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.InteropServices;

public class Score_Update : MonoBehaviour {

	const string dll = "PedometerSO";


	[DllImport (dll)]
	private static extern int pedometer ();
	[DllImport (dll)]
	private static extern void sensor_main ();


	Text scoreText;

	void Awake() {
		scoreText = GetComponent<Text> ();
	}

	void Start() {
		sensor_main ();
	}

	// Update is called once per frame
	void Update () {
		Score_Manager.score = pedometer ()*10;
		scoreText.text = Score_Manager.score.ToString ();
        PlayerPrefs.SetInt("money", Score_Manager.score);	
	}
}
