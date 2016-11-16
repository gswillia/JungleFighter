using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
 * This Script Manages Main Menu
 * 
 */
public class Menu : MonoBehaviour
{



	
		void Start ()
		{
				if (AudioListener.volume != .75f) {
						AudioListener.volume = Options.volC;
				}
		}
	
		void Update ()
		{
	
		}
	
		public void OnClickPlay ()
		{
				Application.LoadLevel ("Main");


		}

		public void OnClickOptions ()
		{
				Application.LoadLevel ("Options1");
		}

		public void OnClickQuit ()
		{
				Application.Quit ();
		}

}
