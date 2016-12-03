using UnityEngine;
using System.Collections;

public class trans1 : MonoBehaviour {

	// Use this for initialization
	public void SceneTrans1 () {
        Application.LoadLevel("scene1");
	}
	
	// Update is called once per frame
	public void SceneTrans_menu () {
        Application.LoadLevel("menu");

    }

    public void eat()
    {
        // scene transition and call 'doeat'
        Application.LoadLevel("scene1");
        csAnimation.condition = 3;

    }

    public void clean_poo()
    {
        // scene transition and call 'jumping'
        Application.LoadLevel("scene1");
        csAnimation.condition = 6;
    }

    public void status_menu()
    {
        // scene transition to status
        Application.LoadLevel("status");

    }
    
    public void go_battle()
    {
        //scene transition to battle mode.
        Application.LoadLevel("battle");
    }

    public void upgrade_hp()
    {
        int current_hp = PlayerPrefs.GetInt("hp");
        current_hp += 20;
        PlayerPrefs.SetInt("hp", current_hp);
    }

    public void upgrade_damage()
    {
        int current_damage = PlayerPrefs.GetInt("damage");
        current_damage += 10;
        PlayerPrefs.SetInt("damage", current_damage);
    }
}
