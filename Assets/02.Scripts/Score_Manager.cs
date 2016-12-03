using UnityEngine;
using System.Collections;

public class Score_Manager : MonoBehaviour {

	public static int score;
    public static int AttackDamage;

	void Awake () {
		score = 0;
        AttackDamage = 0;
	}
}
