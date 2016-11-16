using UnityEngine;
using System.Collections;

public class logo : MonoBehaviour
{
		float load;
		bool check;
		// Use this for initialization
		void Start ()
		{
				load = Time.time + 2f;
				check = true;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Time.time >= load) {
						if (check == true) {
								Application.LoadLevel ("mainmenu");
								check = false;
						}
				}
		}
}
