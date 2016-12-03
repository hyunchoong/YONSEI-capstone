using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.InteropServices;


public class csBattleManager : MonoBehaviour {

	Text damageText;
	 
	const string dll = "PedometerSO";

	[DllImport (dll)]
	private static extern void damage_main ();
	[DllImport (dll)]
	private static extern void damage_reset ();
	[DllImport (dll)]
	private static extern int pedometer_damage ();


	// Use this for initialization
	void Start () {
		damageText = GetComponent<Text> ();

		damage_main ();
		damage_reset ();
	}

	// Update is called once per frame
	void Update () {
		Score_Manager.AttackDamage = (int)((PlayerPrefs.GetInt ("damage") * 0.5) + (PlayerPrefs.GetInt ("damage") * Mathf.Min(5000, pedometer_damage()) / 5000));
		damageText.text = "Damage: " + Score_Manager.AttackDamage.ToString ();
	}
}
