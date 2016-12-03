using UnityEngine;
using System.Collections;

public class csTimer : MonoBehaviour {

	double timer;
	int period;

	// Use this for initialization
	void Start () {
		timer = 0.0;
		period = 10;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > period) {
			if (PlayerPrefs.GetInt("satiety") > 0)
				PlayerPrefs.SetInt ("satiety", PlayerPrefs.GetInt ("satiety") - 1);
			timer = 0.0;
		}
	}
}
