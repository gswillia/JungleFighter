using UnityEngine;
using System.Collections;

public class boomScript : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{

				Destroy (gameObject, 1);
		GetComponent<AudioSource> ().Play ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
