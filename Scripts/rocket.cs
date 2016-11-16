using UnityEngine;
using System.Collections;

public class rocket : MonoBehaviour {
	public Rigidbody2D smokePrefab;
	// Use this for initialization
	void Start () {
		Destroy (gameObject,5); 
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 shootDirection;
		shootDirection = Input.mousePosition;
		shootDirection.z = 0.0f;
		shootDirection = Camera.main.ScreenToWorldPoint (shootDirection);
		shootDirection = shootDirection - transform.position;
	


	//	Vector3 dir = Input.mousePosition - transform.position;
	
		float angle = Mathf.Atan2 (shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);


		Vector2 smoke = new Vector2 (transform.position.x, transform.position.y);
		Rigidbody2D bPrefab = Instantiate (smokePrefab, smoke, Quaternion.identity) as Rigidbody2D;
	}
}
