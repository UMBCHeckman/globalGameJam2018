using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {
	public Camera myCamera;
	public Rigidbody2D myBody;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		myCamera.transform.position = new Vector3 (myBody.position.x, myBody.position.y, -12);
	}
}
