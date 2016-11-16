using UnityEngine;
using System.Collections;

public class Mig : MonoBehaviour {
	public bool isEnemy = true;
	public static Transform Player;
	public Transform turret;
	public Rigidbody2D boomPrefab;
	public Rigidbody2D migPrefab;
	public Rigidbody2D bulletPrefab;
	public Rigidbody2D smokePrefab;
	public float distance;
	public float speed= 1f;
	float attackSpeed = .4f;
	float coolDown;
	int cash;
	//int speed= 2;
	public int hp = 3;
	//float damp = 1f;
	
	void Start ()
	{
		
	}
	
	void Update ()
	{
		
		Vector3 dir = Player.position - transform.position;
		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		distance = (Player.position - turret.position).magnitude;
		Vector3 delta = Player.transform.position - transform.position;
		delta.Normalize();
		float moveSpeed = speed * Time.deltaTime;
		transform.position = transform.position + (delta * moveSpeed);
		//Debug.Log (distance);
		Vector2 smoke = new Vector2 (turret.position.x, turret.position.y);
		Rigidbody2D bPrefab = Instantiate (smokePrefab, smoke, Quaternion.identity) as Rigidbody2D;
		if (distance <= 300) {

			fire ();
		}
		
		
	}
	
	public void Damage (int damageCount)
	{
		
		hp -= damageCount;
		
		
		
		
	}
	
	void OnTriggerEnter2D (Collider2D otherCollider)
	{
		if (otherCollider.gameObject.name == "rocket(Clone)") {
			Vector2 bull = new Vector2 (turret.position.x, turret.position.y);
			cash = PlayerScript.cash;
			cash = cash + 50; 
			PlayerScript.cash = cash;
			Destroy (gameObject);
			Rigidbody2D bPrefab = Instantiate (boomPrefab, bull, Quaternion.identity) as Rigidbody2D;
			bPrefab.GetComponent<Rigidbody2D> ();

				}
		
		
		
		if (otherCollider.gameObject.name == "bullet(Clone)") {
			
			hp = hp - 1;
			
			if (hp <= 0) {
				Vector2 bull = new Vector2 (turret.position.x, turret.position.y);
				cash = PlayerScript.cash;
				cash = cash + 50; 
				PlayerScript.cash = cash;
				Destroy (gameObject);
				Rigidbody2D bPrefab = Instantiate (boomPrefab, bull, Quaternion.identity) as Rigidbody2D;
				bPrefab.GetComponent<Rigidbody2D> ();
			}
		}
	}
	
	void fire(){
		if (Time.time >= coolDown) {
			Vector2 bull = new Vector2 (turret.position.x, turret.position.y);
			Rigidbody2D bPrefab = Instantiate (bulletPrefab, bull, Quaternion.identity) as Rigidbody2D;
			bPrefab.GetComponent<Rigidbody2D> ().AddForce (transform.right * 3500);
			coolDown = Time.time + attackSpeed;
		}
		
		
	}
}
