// -------------------------------------------------------------------
// Because of EULA(End User License Agreement) problem,
// we deleted paid assets named "LittleCat" and "LittleDragons:Tiger".
// public variable "pet" will be attached to the "pet(LittleCat)".
// And all comments should be deleted. (like // public ... )
// -------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class csCake : MonoBehaviour {

	public GameObject food;
	// public GameObject pet;
	Vector3 pos = new Vector3(-0.47f,0.105f,-0.77f);
	Vector3 scale = new Vector3(0.2f, 0.1f, 0.2f);
    Quaternion rotate = new Quaternion(180,0,0,0);

	void Start() {

	}
	/*
	public void createCake() {
		GameObject clone = Instantiate (food, pet.transform.position + pos, Quaternion.identity) as GameObject;
		clone.transform.localScale = scale;
        clone.transform.localRotation = rotate;
		Destroy (clone, 6.0f);
	}
	*/
}
