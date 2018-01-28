using System;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
	[RequireComponent(typeof (enemyCharacter2D))]
	public class ai : MonoBehaviour
	{
		private enemyCharacter2D m_Character;
		private Rigidbody2D m_body;
		//public Rigidbody2D m_body;
		//private bool m_Jump;
		private int counter;
		private int counter2;
		private float hbuff;
		private float jbuff;
		public Rigidbody2D theBoy;
		private Animator m_animator;
		public V1col wallcheckV;
		public H1col wallcheckH;
		public V2col wallcheckV2;
		public H2col wallcheckH2;
		//rudimentary kill floor setup (KF)
		//public Transform respawn;
		//private float killFloor;
		//public int AP = 50;
		//public int APStart = 50;

		void Start () {
			m_body = GetComponent<Rigidbody2D>();
			m_animator = GetComponent<Animator> ();
			//	killFloor = -25.0f;
			//APStart = 50;
			//AP = 50;
		}
		private void Awake()
		{
			m_Character = GetComponent<enemyCharacter2D>();
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
			int r = UnityEngine.Random.Range (0, 60);
			if (r == 1)
				m_animator.Play ("glitch", -1, 0f);
			//if (AP <= 0) {
			//	print ("out of ap!");
			//	m_Character.Move(0, false, false);
			//	return;
			//}
			// Read the inputs.
			//bool crouch = false;//Input.GetKey(KeyCode.LeftControl);
			//float h = Input.GetAxis("Horizontal"); // We're not using andriod anymore so fuck this -> Input.acceleration.x;
			float h = 0;
			float j = 0;
			if(theBoy.position.x > m_body.position.x){
				h = 1;
			}
			else if(theBoy.position.x < m_body.position.x){
				h = -1;
			}
			//if ((Mathf.Abs (theBoy.position.x) - Mathf.Abs (m_body.position.x)) < 1)
			//	h = 0;
			float input = h;
			if (Mathf.Abs(hbuff) > Mathf.Abs(input))
				h = 0;
			//float j = Input.GetAxis("Vertical"); // We're not using andriod anymore so fuck this -> Input.acceleration.x; 
			if(theBoy.position.y > m_body.position.y){
				j = 1;
			}
			else if(theBoy.position.y < m_body.position.y){
				j = -1;
			}
			//if ((Mathf.Abs (theBoy.position.y) - Mathf.Abs (m_body.position.y)) < 1)
			//	j = 0;
			float inputj = j;
			if (Mathf.Abs(jbuff) > Mathf.Abs(inputj))
				j = 0;
			//if (h != 0) {
			//	AP -= 1;
			//}
			//print ("fuckyou");
			//print (AP);
			//print(h);
			//print("are u getting called?!?!?" + " " + h + " " + m_Jump);
			// Pass all parameters to the character control script.
			//print(h);
			//if(OnTriggerEnter2D(wallcheckH)){
			//	h = 0;
			//	j = -1;
			//}
			//OnTriggerStay2D(wallcheckV);

			if (wallcheckV.vCol || wallcheckV2.vCol) {
				h = 1;
			}
			if (wallcheckH.hCol || wallcheckH2.hCol) {
				j = 1;
			}
			m_Character.Move(h,j, .2f);//, crouch, m_Jump);
			//m_Jump = false;
			hbuff = input;
			jbuff = inputj;
		}
	}
}
