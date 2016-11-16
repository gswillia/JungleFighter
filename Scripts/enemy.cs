using UnityEngine;
using System;
using System.Collections;
/*
 * This Script example of enemy
 * 
 */
public class enemy : MonoBehaviour {

	public Transform Player;
	int cash;
	
	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		cash = PlayerScript.cash;
		cash = cash + 50; 
		PlayerScript.cash= cash;
		Destroy (gameObject);
		
	}
	
	void FixedUpdate()
	{
	
	}
}
