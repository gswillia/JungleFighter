using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Options : MonoBehaviour
{

		public Slider volume;
		public static  float volC;

		void Start ()
		{
				
				volC = volume.value;
				
		
		}

		void Update ()
		{
				volC = volume.value;
				volC = volC / 100;
				AudioListener.volume = volC;
		}

		public void OnClickPlay ()
		{
				Application.LoadLevel ("mainmenu");
		}



}
