using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

/*
 * This Script Manages Main player heli
 * 
 */
public class PlayerScript : MonoBehaviour
{

		public static int hp = 10;
		public static int ammo = 999;
		public static int cash = 1000;
		public static int fuel = 50;
		public static int rocket = 2;
        public static int landed = 0;

        public Rigidbody2D bulletPrefab;
		public Rigidbody2D rocketPrefab;
		public Rigidbody2D heli;
		public Rigidbody2D boomPrefab;
		public Rigidbody2D smokePrefab;
      
        public static float attackSpeed = .15f;
		float coolDown;
		float gasDown;
		float helispd = .3f;
		float degree = 0f;
        float x;
        float y;
		private float Timer;
        float wait;

        public Slider healthBarSlider;
		public Slider Fuel;
        public Text xCord;
        public Text yCord;


		Animator animator;

		const int STATE_IDLE = 0;
		const int STATE_FIRE = 1;
        const int STATE_LAND = 2;

		bool paused = false;

		int _currentAnimationState = STATE_IDLE;

        System.Random random = new System.Random();

    void Start ()
		{
                rocket = 2;
				hp = 10;
				fuel = 50;
				ammo = 999;
                animator = this.GetComponent<Animator> ();
				Time.timeScale = 1f;
				healthBarSlider.value = hp;
				Fuel.value = fuel;
         }
	
		void Update ()
		{
        /////cords//////////////////////////////////////////////////
                x =transform.position.x;
                y= transform.position.y;
                x = (float)(Math.Truncate((double)x * 1.0) / 1.0);
                y = (float)(Math.Truncate((double)y * 1.0) / 1.0);
                xCord.text = x.ToString();
                yCord.text = y.ToString();
        ////////////////////////////////////////////////////////////


                healthBarSlider.value = hp;
				Fuel.value = fuel;
				wait = Time.time + 1f;
        

        if (Input.GetKeyDown(KeyCode.L))
        {
            if (landed > 0)
            {
                landed = 0;
                changeState(STATE_IDLE);
                
            }
            else
            {
                changeState(STATE_LAND);
                landed = 1;
            }
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = togglePause();
        }


        if (Time.timeScale != 0f && landed!=1) {

         

            if (Input.GetKeyDown(KeyCode.R)) {
								fireRocket ();
						}

						if (Input.GetKey (KeyCode.E)) {
								// left angle
								transform.Rotate (0f, 0f, -1f); 
								degree = degree - 1f;

						}
	
						if (Input.GetKey (KeyCode.Q)) {
								// left angle
								transform.Rotate (0f, 0f, 1f); 
								degree = degree + 1f;
		
						}

						if (Input.GetKey (KeyCode.W)) {
                //Forward
                            //if (transform.position.x < 1240 && transform.position.x > -1240 && transform.position.y < 1240 && transform.position.y > -1240)
                           //     {
                                transform.position += transform.up * helispd;
                    //heli.AddForce(transform.up*100);
                             //   }
                }

						if (Input.GetKey (KeyCode.S)) {
								//Back
								transform.position -= transform.up * helispd;
						}

						if (Input.GetKey (KeyCode.A)) {
								// left 
								transform.position -= transform.right * helispd * .5f;
						}

						if (Input.GetKey (KeyCode.D)) {
								// Right 
								transform.position += transform.right * helispd * .5f;
						}
                        

                         if (Input.GetKey (KeyCode.LeftShift)) {
								//turbo
								if (helispd < 1f) {
										helispd = helispd + .1f;
								}
			
						} else {
								helispd = .6f;
						        }

        }		


				if (Time.time >= coolDown) {
						if (ammo > 0) {
								if (Input.GetKey (KeyCode.Space)) {
										changeState (STATE_FIRE);
										ammo = ammo - 1;
										Fire ();
                                      
                                } else {
                    if (landed < 1)
                    {
                        changeState(STATE_IDLE);
                    }
								}
						} 
				}

				if (Time.time >= gasDown) {
						fuel = fuel - 1;
						Fuel.value = fuel;
						gasDown = Time.time + 10f;
				}
		}
		
		void Fire ()
		{
				Vector2 bull = new Vector2 (transform.position.x, transform.position.y);
				//bull = Quaternion.Euler (heli.position.x-.25f, heli.position.y+2f, degree) * bull;
				Rigidbody2D bPrefab = Instantiate (bulletPrefab, bull, Quaternion.identity) as Rigidbody2D;
				bPrefab.GetComponent<Rigidbody2D> ().AddForce (transform.up * 5000);
				GetComponent<AudioSource> ().Play ();
				coolDown = Time.time + attackSpeed;
				Rigidbody2D smoke = Instantiate (smokePrefab, bull, Quaternion.identity) as Rigidbody2D;
		}
		
		void fireRocket ()
		{

				if (rocket > 0) {
						Vector3 shootDirection;
						shootDirection = Input.mousePosition;
						shootDirection.z = 0.0f;
						shootDirection = Camera.main.ScreenToWorldPoint (shootDirection);
						shootDirection = shootDirection - transform.position;
						//...instantiating the rocket
						Rigidbody2D bulletInstance = Instantiate (rocketPrefab, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
					
						bulletInstance.velocity = new Vector2 (shootDirection.x * 5, shootDirection.y * 5);
						rocket = rocket-1;
				}
		}

		void changeState (int state)
		{
				if (_currentAnimationState == state)
						return;
				switch (state) {

				case STATE_FIRE:
						animator.SetInteger ("State", STATE_FIRE);
						break;

				case STATE_IDLE:
						animator.SetInteger ("State", STATE_IDLE);
						break;

                case STATE_LAND:
                        animator.SetInteger("State", STATE_LAND);
                        break;
        }
				_currentAnimationState = state;

		}

		void OnTriggerEnter2D (Collider2D otherCollider)
		{
				if (otherCollider.gameObject.name == "eBullet(Clone)") {
						hp = hp - 1;
						healthBarSlider.value -= 1f;
						if (hp <= 0) {
								Vector2 bull = new Vector2 (heli.position.x, heli.position.y);
								Rigidbody2D bPrefab = Instantiate (boomPrefab, bull, Quaternion.identity) as Rigidbody2D;
								for (int i = 0; i<=20; i++) {

										//if (Time.time >= wait) {
										bull = new Vector2 (heli.position.x, heli.position.y);
										bPrefab = Instantiate (boomPrefab, bull, Quaternion.identity) as Rigidbody2D;
										transform.Rotate (0f, 0f, -6f);
										transform.position += transform.up * i;
										//}
								}
								paused = togglePause ();
						}		
				}
		}

		bool togglePause ()
		{
				if (Time.timeScale == 0f) {
						Time.timeScale = 1f;
						return(false);
				} else {
						Time.timeScale = 0f;

						return(true);    
				}
		}

		void OnGUI ()
		{
				if (paused) {
						if (hp > 0) {
								if (GUI.Button (new Rect (Screen.width / 2 - 60, Screen.height / 2 + 00, 100, 40), "Return to Game"))
										paused = togglePause ();
						}
					

						if (GUI.Button (new Rect (Screen.width / 2 - 60, Screen.height / 2 + 60, 100, 40), "Return to Menu"))
								Application.LoadLevel ("mainmenu");

						if (GUI.Button (new Rect (Screen.width / 2 - 60, Screen.height / 2 + 120, 100, 40), "Exit"))
								Application.Quit ();

				}
		}
	
}





