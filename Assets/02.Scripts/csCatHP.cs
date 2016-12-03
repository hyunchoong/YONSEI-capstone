using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class csCatHP : MonoBehaviour {

	Text catHP;

	// Use this for initialization
	void Start () {
		catHP = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (csBattle.CatHP < 0)
        {
            catHP.text = "0";
        }
        else
		    catHP.text = csBattle.CatHP.ToString ();
	}
}
