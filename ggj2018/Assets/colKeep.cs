using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colKeep : MonoBehaviour {
	public Rigidbody2D mop;
	private Rigidbody2D m_Rigidbody2D;
	// Use this for initialization
	void Start () {
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		m_Rigidbody2D.transform.position = new Vector2(mop.position.x, mop.position.y);
	}
}