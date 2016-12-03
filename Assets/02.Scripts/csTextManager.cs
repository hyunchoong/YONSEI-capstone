using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.InteropServices;

public class csTextManager : MonoBehaviour {

    const string dll = "PedometerSO";

    [DllImport(dll)]
    private static extern void sensor_reset(int num);

    Text status;
    int current_money=0;

	void Start() {

		status = GetComponent<Text> ();
		print (status.text);
		
		switch (status.text) {
		case "   ":
			status.text = status.text +"    "+ PlayerPrefs.GetString ("name");
			break;
		case "LV.":
			status.text = status.text +" "+ PlayerPrefs.GetInt ("level") ;
			break;
		case "HP":
			status.text = status.text + "   " + PlayerPrefs.GetInt ("hp");
			break;
		case "DA":
			int avg = PlayerPrefs.GetInt ("damage");
			int min = (int)(avg * 0.5);
			int max = (int)(avg * 1.5);
			status.text = status.text + "  " + min.ToString () + " ~ " + max.ToString ();
			break;
		case "SA":
			status.text = status.text + "   " + PlayerPrefs.GetInt ("satiety") + "%";
			break;
		case "MO":
			status.text = status.text + "   " + PlayerPrefs.GetInt ("money");
            current_money = PlayerPrefs.GetInt("money");
            break;
		}
	}

	void Update() {
        print(status.text);
        if (status.text.Contains("HP"))
        {
            status.text = "HP" + "   " + PlayerPrefs.GetInt("hp");
        }

        if (status.text.Contains("DA"))
        {
            int avg = PlayerPrefs.GetInt("damage");
            int min = (int)(avg * 0.5);
            int max = (int)(avg * 1.5);
            status.text = "DA" + "  " + min.ToString() + " ~ " + max.ToString();
        }

        if (status.text.Contains("MO"))
        {
            status.text = "MO" + "   " + PlayerPrefs.GetInt("money");
        }      
    }

    public void upgrade_hp()
    {
        int money = PlayerPrefs.GetInt("money");
        if ( money >= 1000)
        {
            int current_hp = PlayerPrefs.GetInt("hp");
            current_hp += 20;
            PlayerPrefs.SetInt("hp", current_hp);
            PlayerPrefs.SetInt("money", money -= 1000);
        }
    }

    public void upgrade_damage()
    {
        int money = PlayerPrefs.GetInt("money");
        if (PlayerPrefs.GetInt("money") >= 1000)
        {
            int current_damage = PlayerPrefs.GetInt("damage");
            current_damage += 10;
            PlayerPrefs.SetInt("damage", current_damage);
            PlayerPrefs.SetInt("money", money -= 1000);
            sensor_reset(100);
        }
    }
}
