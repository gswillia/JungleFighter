using UnityEngine;
using System.Collections;

/*
 * This Script Manages heli MG fire
 * 
 * 
 */
public class fbullet : MonoBehaviour
{


		public int damage = 1;
		public bool isEnemyShot = false;
	
		void Start ()
		{
				Destroy (gameObject, 2); // 20sec
		}

		void OnTriggerEnter2D (Collider2D otherCollider)
		{
				if (otherCollider.gameObject.name != "Heli") {
						Destroy (gameObject);
			
				}
				
		}



}
