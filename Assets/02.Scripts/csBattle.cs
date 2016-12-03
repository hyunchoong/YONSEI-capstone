// -------------------------------------------------------------------
// Because of EULA(End User License Agreement) problem,
// we deleted paid assets named "LittleCat" and "LittleDragons:Tiger".
// This script will be attached to the "pet(LittleCat)" and the "dragon(LittleDragons:Tiger)" and the "colosseum.
// And all comments should be deleted. (like // DragoFire breath = ... )
// -------------------------------------------------------------------


using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.InteropServices;

public class csBattle : MonoBehaviour {

	const string dll = "PedometerSO";

	[DllImport (dll)]
	private static extern void damage_reset ();


	Animator anim;
//	DragoFire breath = new DragoFire ();

	public Slider CatHealthBar;
	public Slider DragonHealthBar;

    public static int CatHP, CatDamage, DragonHP, DragonDamage;


	// Use this for initialization
	void Start () {

        CatHP = PlayerPrefs.GetInt ("hp");
		CatDamage = PlayerPrefs.GetInt ("damage");
		DragonHP = PlayerPrefs.GetInt("dragon_hp");
		DragonDamage = PlayerPrefs.GetInt("dragon_damage");

		CatHealthBar.value = CatHealthBar.maxValue = CatHP;
		DragonHealthBar.value = DragonHealthBar.maxValue = DragonHP;

		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
        
		if (DragonHP <= 0 ) {
			doDragonDeath ();
			csBattleText.gameCondition = 1;
        }
		if (CatHP <= 0) {
			doCatDeath ();
			csBattleText.gameCondition = 2;
		}
	}


	public void DamageCalculate() {
		StartCoroutine ("coDamageCalculate");
	}

	IEnumerator coDamageCalculate() {
		yield return new WaitForSeconds (0.6f);
		if (CatHP > 0 && DragonHP > 0) {
            DragonHP -= Score_Manager.AttackDamage;
            DragonHealthBar.value -= Score_Manager.AttackDamage;
			damage_reset ();
		}

		yield return new WaitForSeconds (4.0f);
		if (CatHP > 0 && DragonHP > 0) {
			CatHP = CatHP - DragonDamage;
			CatHealthBar.value -= DragonDamage;
		}
	}



	public void doBattle() {
		StartCoroutine ("coBattle");
	}

	IEnumerator coBattle() {
		doCatAttack ();
		yield return new WaitForSeconds (2.0f);


		doDragonAttack ();
		yield return new WaitForSeconds (2.0f);

	}


	void doCatAttack() {
		if (CatHP > 0) {
			StartCoroutine ("coCatAttack");
			StartCoroutine ("coDragonHit");
		}
	}
	void doDragonAttack() {
		if (DragonHP > 0) {
			StartCoroutine ("coDragonAttack");
			StartCoroutine ("coCatHit");

		}
	}
	void doCatDeath() {
		StartCoroutine ("coCatDeath");
	}
	void doDragonDeath() {
		StartCoroutine ("coDragonDeath");
	}

	IEnumerator coCatAttack() {
		anim.SetInteger ("battleCat", 1);
		yield return new WaitForSeconds (0.01f);
		anim.SetInteger ("battleCat", 0);
	}
	IEnumerator coCatHit() {
		yield return new WaitForSeconds (0.4f);
		anim.SetInteger ("battleCat", 2);
		yield return new WaitForSeconds (2.5f);
		anim.SetInteger ("battleCat", 0);
	}
	IEnumerator coDragonAttack() {
		anim.SetInteger ("battleDragon", 1);
		yield return new WaitForSeconds (0.01f);
//		breath.FireAttack (2);
		anim.SetInteger ("battleDragon", 0);
	}
	IEnumerator coDragonHit() {
		anim.SetInteger ("battleDragon", 2);
		yield return new WaitForSeconds (0.01f);
		anim.SetInteger ("battleDragon", 0);
	}
	IEnumerator coCatDeath() {
		yield return new WaitForSeconds (0.4f);
		anim.SetInteger ("battleCat", 3);
	}
	IEnumerator coDragonDeath() {
		yield return new WaitForSeconds (0.4f);
		anim.SetInteger ("battleDragon", 3);
	}
}