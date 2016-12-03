using UnityEngine;
using System.Collections;

public class csGameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetString ("name") == null) {
			PlayerPrefs.SetString ("name", "GEAR PET");
			PlayerPrefs.SetInt ("level", 1);
			PlayerPrefs.SetInt ("hp", 100);
			PlayerPrefs.SetInt ("damage", 100);
			PlayerPrefs.SetInt ("satiety", 50);
			PlayerPrefs.SetInt ("poo", 50);
			PlayerPrefs.SetInt ("money", 0);
		}
      
	}

    // reset 
    void reset()
    {
        PlayerPrefs.SetString("name", null);
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.SetInt("hp", 100);
        PlayerPrefs.SetInt("damage", 30);
        PlayerPrefs.SetInt("satiety", 0);
        PlayerPrefs.SetInt("poo", 0);
        PlayerPrefs.SetInt("money", 0);
    }
}
