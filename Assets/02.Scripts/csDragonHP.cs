using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class csDragonHP : MonoBehaviour {

	Text dragonHP;

	// Use this for initialization
	void Start () {
		dragonHP = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (csBattle.DragonHP < 0)
        {
            dragonHP.text = "0";
        }
        else
            dragonHP.text = csBattle.DragonHP.ToString ();
	}
}
