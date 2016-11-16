using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
 * This Script Manages AMMO for the GUI panel.
 * modifies PlayerScript.cash
 * 
 */
public class ammoScript : MonoBehaviour
{

		int Ammo;
		Text text;

		// Use this for initialization
		void Start ()
		{
				text = GetComponent<Text> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				Ammo = PlayerScript.ammo;
				text.text = "" + Ammo;
		}
}
