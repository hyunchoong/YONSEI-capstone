// -------------------------------------------------------------------
// Because of EULA(End User License Agreement) problem,
// we deleted paid assets named "LittleCat" and "LittleDragons:Tiger".
// This script will be attached to the "pet(LittleCat)".
// -------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class csAnimation : MonoBehaviour {

    Animator anim;
    public static int condition;
    GameObject food, poo;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
        food = GameObject.Find("Food");
        poo = GameObject.Find("Poo");
        switch (condition)
        {
            case 0:
                doIdle();
                break;
            case 1:
                doWalk();
                break;
            case 2:
                doRun();
                break;
            case 3:
                doEat();
                break;
            case 4:
                doLick();
                break;
            case 5:
                doPeeing();
                break;
            case 6:
                poo.SendMessage("cleanPoo", SendMessageOptions.DontRequireReceiver);
                condition = 10;
                doJump();
                break;
            case 7:
                doProwl();
                break;
            case 8:
                doDeath();
                break;
            case 9:
                doShake();
                break;
        }
    }

	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("satiety") <= 0)
        {
            doSleep();
        }
        
	}

    public void doSleep()
    {
        anim.SetInteger("condition", 15);
    }

	public void doIdle() {
        InvokeRepeating("doLick", 5, 10);
        InvokeRepeating("doShake", 10, 10);
        anim.SetInteger ("condition", 0);
        condition = 0;
	}

	public void doWalk() {
		anim.SetInteger ("condition", 1);
	}

	public void doRun() {
		anim.SetInteger ("condition", 2);
	}


	public void doEat() {
        food.SendMessage("createCake", SendMessageOptions.DontRequireReceiver);
        StartCoroutine ("coEat");
        PlayerPrefs.SetInt("satiety", Mathf.Min(PlayerPrefs.GetInt("satiety") + 30, 100));
       
	}

	public void doLick() {
		StartCoroutine ("coLick");
	}

	// 오줌을 싸다
	public void doPeeing() {
		StartCoroutine ("coPeeing");
	}

	public void doPooping() {
        // after eating food, it comes out.
        StartCoroutine("coPooping");
        poo.SendMessage("createPoo", SendMessageOptions.DontRequireReceiver);
	}

    public void doJump()
    {
        StartCoroutine("coJumping");
    }

	// 기어다니다
	public void doProwl() {
		anim.SetInteger ("condition", 7);
	}

	public void doDeath() {
		anim.SetInteger ("condition", 8);
	}

	public void doShake() {
		StartCoroutine ("coShake");
	}

	

	IEnumerator coEat() {
		anim.SetInteger ("condition", 3);
		yield return new WaitForSeconds (6.0f);
		if (anim.GetInteger ("condition") == 3) {
            //anim.SetInteger ("condition", 0);
            doIdle();
		}
        yield return new WaitForSeconds(Random.Range(10,12));
        doPooping();
	}
	IEnumerator coLick() {
		anim.SetInteger ("condition", 4);
		yield return new WaitForSeconds (1.8f);
		if (anim.GetInteger ("condition") == 4) {
			
			anim.SetInteger ("condition", 0);
		}
	}
	IEnumerator coPeeing() {
		anim.SetInteger ("condition", 5);
		yield return new WaitForSeconds (1.8f);
		if (anim.GetInteger ("condition") == 5) {
			
			anim.SetInteger ("condition", 0);
		}
	}
	IEnumerator coPooping() {
		anim.SetInteger ("condition", 6);
		yield return new WaitForSeconds (3.0f);
		if (anim.GetInteger ("condition") == 6) {

			anim.SetInteger ("condition", 0);
		}
	}
	IEnumerator coShake() {
		anim.SetInteger ("condition", 9);
		yield return new WaitForSeconds (0.6f);
		if (anim.GetInteger ("condition") == 9) {
			anim.SetInteger ("condition", 0);
		}
	}
    IEnumerator coJumping()
    {
        anim.SetInteger("condition", 10);
        yield return new WaitForSeconds(0.55f);
        if (anim.GetInteger("condition") == 10)
            //anim.SetInteger("condition", 0);
            doIdle();
    }


}
