using UnityEngine;
using System.Collections;

/*
 * This Script Manages Migs on the ground.
 * 
 */
public class MigOff : MonoBehaviour
{


		public Transform migOff;
		int cash;
		public int hp = 10;
		public Rigidbody2D boomPrefab;

		void Start ()
		{
		
		}
	
		void Update ()
		{

		
		}
	
		void OnTriggerEnter2D (Collider2D otherCollider)
		{
				if (hp >= 1) {
						hp = hp - 1;
			
			
				} else {
						Vector2 bull = new Vector2 (migOff.position.x, migOff.position.y);
						cash = PlayerScript.cash;
						cash = cash + 75; 
						PlayerScript.cash = cash;
						Destroy (gameObject);
						Rigidbody2D bPrefab = Instantiate (boomPrefab, bull, Quaternion.identity) as Rigidbody2D;
						bPrefab.GetComponent<Rigidbody2D> ();
				}
		}
}
