using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
 * This Script Manages Money for the GUI panel.
 * modifies PlayerScript.cash
 * 
 */
public class moneyScript : MonoBehaviour
{
		int Cash;
		Text text;
	
		// Use this for initialization
		void Start ()
		{
				text = GetComponent<Text> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				Cash = PlayerScript.cash;
				text.text = "" + Cash;
		}
}
