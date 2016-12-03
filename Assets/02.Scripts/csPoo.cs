// -------------------------------------------------------------------
// Because of EULA(End User License Agreement) problem,
// we deleted paid assets named "LittleCat" and "LittleDragons:Tiger".
// public variable "pet" will be attached to the "pet(LittleCat)".
// And all comments should be deleted. (like // public ... )
// -------------------------------------------------------------------


using UnityEngine;
using System.Collections;

public class csPoo : MonoBehaviour {
    GameObject clone;
    public GameObject poo;
    // public GameObject pet;
    Vector3 pos = new Vector3(-0.45f, 0.0f, 0.4f);
    Vector3 scale = new Vector3(0.03f, 0.024f, 0.03f);

	/*
    public void createPoo()
    {
        clone = Instantiate(poo, pet.transform.position + pos, Quaternion.identity) as GameObject;
        clone.transform.localScale = scale;
        Destroy(clone, 6.0f);
    }
	*/
    
	public void cleanPoo()
    {
        Destroy(clone, 1.0f);
    }
}
