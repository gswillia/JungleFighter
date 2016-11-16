using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Carrier : MonoBehaviour
{
		public Slider Fuel;
		public static bool buymenu = false;
        static bool landed = false;
        static bool trigg = false;
        public GameObject menu;
       

    void Start ()
		{
	
		}
			
		// Update is called once per frame
		void Update ()
		{
	    if (PlayerScript.landed >0)
        {
            landed = true;
            GetComponent<AudioSource>().Pause();
        }
        else
        {
            GetComponent<AudioSource>().UnPause();
            landed = false;
        }

        if (landed && trigg)
        {
            
            menu.SetActive(true);
            buymenu = true;
            gameObject.GetComponent<CanvasGroup>().alpha = 1f;

        }
        else
        {
            buymenu = false;
            gameObject.GetComponent<CanvasGroup>().alpha = 0f;
            menu.SetActive(false);
        }

		}

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.name == "Heli")
        {
            trigg = true;

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        trigg = false;
    }
    void OnGUI ()
		{
				if (buymenu) {
						//heli

						if (GUI.Button (new Rect (Screen.width / 2 - 880, Screen.height / 2 - 325, 100, 40), "Heal $100")) {
								if (PlayerScript.cash >= 100) {
										PlayerScript.hp = 10;
										PlayerScript.cash = PlayerScript.cash - 100;
								}
				
						}
			
						
			
						if (GUI.Button (new Rect (Screen.width / 2 - 880, Screen.height / 2 - 275, 100, 40), "Refill Fuel $100")) {
								if (PlayerScript.cash >= 100) {
										PlayerScript.fuel = 50;
										PlayerScript.cash = PlayerScript.cash - 100;
								}
				
						}


						if (GUI.Button (new Rect (Screen.width / 2 - 880, Screen.height / 2 - 225, 100, 40), "Refill MG $150")) {
								if (PlayerScript.cash >= 150) {
										PlayerScript.ammo = 999;
										PlayerScript.cash = PlayerScript.cash - 150;
								}
								
						}

						if (GUI.Button (new Rect (Screen.width / 2 - 880, Screen.height / 2 - 175, 150, 40), "Upgrade MG $500")) {
								if (PlayerScript.cash >= 500) {
										PlayerScript.attackSpeed = .08f;
										PlayerScript.cash = PlayerScript.cash - 500;
								}
				
						}
			if (GUI.Button (new Rect (Screen.width / 2 - 880, Screen.height / 2 - 125, 150, 40), "Rockets $50")) {
				if (PlayerScript.cash >= 50) {
					PlayerScript.attackSpeed = .08f;
					PlayerScript.cash = PlayerScript.cash - 50;
					PlayerScript.rocket = PlayerScript.rocket + 1;
				}
				
			}


				}	
		}
}
