using System;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
	[RequireComponent(typeof (PlatformerCharacter2D))]
	public class platform : MonoBehaviour
	{
		private PlatformerCharacter2D m_Character;
		private Rigidbody2D m_body;
		public GameObject m_tower;
		public Animator m_animator;
		//public Rigidbody2D m_body;
		//private bool m_Jump;
		private float hbuff;
		private float jbuff;
		private float lbuff;
		private bool bool_runright;
		private bool bool_rundown;
		private bool bool_runleft;
		private bool bool_runup;
		private bool bool_idle;
		//rudimentary kill floor setup (KF)
		//public Transform respawn;
		//private float killFloor;
		//public int AP = 50;
		//public int APStart = 50;

		void Start () {
			m_body = GetComponent<Rigidbody2D>();
			//	killFloor = -25.0f;
			//APStart = 50;
			//AP = 50;
		}
		private void Awake()
		{
			m_Character = GetComponent<PlatformerCharacter2D>();
		}


		private void Update()
		{
			//m_body.mass = 0;
			//m_body.velocity = Vector2.zero;
			//m_Character.Move(0,m_body.gravityScale);
			/*if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
				if (Input.touchCount > 0)
					m_Jump = true;
            }*/
			//if (!m_Jump)
			//	m_Jump = Input.GetAxis ("Jump") > 0;
			//if (AP <= 0) {
			//print ("out of ap!");
			//	return;
			//}
			//(KF)
			//if (killFloor < (transform.position.y - 25.0f))
			//	killFloor = transform.position.y - 25.0f;
			//if (transform.position.y < killFloor)
			//{
			/*
				this.transform.position = respawn.position; 	//respawn at beginning
				this.transform.rotation = respawn.rotation;
				killFloor = transform.position.y - 25.0f;
				*/
			//	Application.LoadLevel ("Game Over");
			//}
		}


		private void FixedUpdate()
		{
			//if (AP <= 0) {
			//	print ("out of ap!");
			//	m_Character.Move(0, false, false);
			//	return;
			//}
			// Read the inputs.
			//bool crouch = false;//Input.GetKey(KeyCode.LeftControl);
			float h = Input.GetAxis("Horizontal"); // We're not using andriod anymore so fuck this -> Input.acceleration.x; 
			float input = h;
			if (Mathf.Abs(hbuff) > Mathf.Abs(input))
				h = 0;
			float j = Input.GetAxis("Vertical"); // We're not using andriod anymore so fuck this -> Input.acceleration.x; 
			float inputj = j;
			if (Mathf.Abs(jbuff) > Mathf.Abs(inputj))
				j = 0;
			float L = Input.GetAxis ("Loot");
			float inputL = L;
			if (Mathf.Abs(lbuff) > Mathf.Abs(inputL))
				L = 0;
			//if (h != 0) {
			//	AP -= 1;
			//}
			//print ("fuckyou");
			//print (AP);
			//print(h);
			//print("are u getting called?!?!?" + " " + h + " " + m_Jump);
			// Pass all parameters to the character control script.
			//print(h);
			if (L == 1) {
				h = 0;
				j = 0;
			}
			m_Character.Move(h,j, 1f);//, crouch, m_Jump);
			if ((h > 0) && (!bool_runright)) {
				m_animator.Play ("protag_runright", -1, 0f);
				bool_runright = true;
				bool_rundown = false;
				bool_runleft = false;
				bool_runup = false;
				bool_idle = false;
			}
			else if ((h < 0) && (!bool_runleft)) {
				m_animator.Play ("protag_runleft", -1, 0f);
				bool_runleft = true;
				bool_rundown = false;
				bool_runup = false;
				bool_runright = false;
				bool_idle = false;
			}
			else if ((j > 0) && (!bool_runup)) {
				m_animator.Play ("protag_runup", -1, 0f);
				bool_runup = true;
				bool_rundown = false;
				bool_runleft = false;
				bool_runright = false;
				bool_idle = false;
			}
			else if ((j < 0) && (!bool_rundown)) {
				m_animator.Play ("protag_rundown", -1, 0f);
				bool_rundown = true;
				bool_runleft = false;
				bool_runup = false;
				bool_runright = false;
				bool_idle = false;
			} else if (j == 0 && h == 0 && !bool_idle) {
				m_animator.Play ("protag_idle", -1, 0f);
				bool_idle = true;
				bool_rundown = false;
				bool_runleft = false;
				bool_runup = false;
				bool_runright = false;
			}
			m_Character.Loot(L);
			//m_Jump = false;
			hbuff = input;
			jbuff = inputj;
			lbuff = inputL;
		}
	}
}
