using UnityEngine;
using System.Collections;

public class Score_Init : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetString("name") != "GEAR PET")
        {
            PlayerPrefs.SetString("name", "GEAR PET");
            PlayerPrefs.SetInt("level", 1);
            PlayerPrefs.SetInt("hp", 100);
            PlayerPrefs.SetInt("damage", 100);
            PlayerPrefs.SetInt("satiety", 50);
            PlayerPrefs.SetInt("poo", 50);
            PlayerPrefs.SetInt("money", 0);
            // dragon
            PlayerPrefs.SetInt("dragon_hp", 100);
            PlayerPrefs.SetInt("dragon_damage", 40);

        }


    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
