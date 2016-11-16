using UnityEngine;
using System.Collections;

public class Ebullet : MonoBehaviour
{

	
		public int damage = 1;
		public bool isEnemyShot = true;
	
		void Start ()
		{
				Destroy (gameObject, 3); 
		}
	
		void OnTriggerEnter2D (Collider2D otherCollider)
		{
				if (otherCollider.gameObject.name == "Heli") {
						Destroy (gameObject);
		
				}


				
		}
	

}
