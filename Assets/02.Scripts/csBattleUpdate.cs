using UnityEngine;
using System.Collections;

public class csBattleUpdate : MonoBehaviour {

	bool isWin;
	bool isLose;

	// Use this for initialization
	void Start () {
		isWin = false;
		isLose = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (csBattle.DragonHP <= 0 && !isWin) {
			PlayerPrefs.SetInt("dragon_hp", (int)(PlayerPrefs.GetInt("dragon_hp") * 1.5));
			PlayerPrefs.SetInt("dragon_damage", (int)(PlayerPrefs.GetInt("dragon_damage") * 1.5));
			PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level")+1);
			isWin = true;
		}
		if (csBattle.CatHP <= 0 && !isLose) {
			isLose = true;
		}
	}
}
