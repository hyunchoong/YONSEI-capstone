using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class csBattleText : MonoBehaviour {

	public Text textWin;
	public Text textLose;
	public static int gameCondition;

	// Use this for initialization
	void Start () {
		gameCondition = 0;
		textWin.enabled = false;
		textLose.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		switch (gameCondition) {
		case 1:
			textWin.enabled = true;
			break;
		case 2:
			textLose.enabled = true;
			break;
		}
	}
}
