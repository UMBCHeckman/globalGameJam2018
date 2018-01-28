using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class start : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float L = Input.GetAxis ("Loot");
		if (L != 0) {
			SceneManager.LoadScene ("mainScene");
		}
	}
}
