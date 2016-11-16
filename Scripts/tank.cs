using UnityEngine;
using System.Collections;

/*
 * This Script Manages Enemy Auto Turret
 * 
 */
public class tank : MonoBehaviour
{
	public bool isEnemy = true;
	public Transform Player;
	public Transform turret;
	public Rigidbody2D boomPrefab;
	public Rigidbody2D bulletPrefab;

	public float distance;
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
		if (distance <= 200) {
						fire ();
				}
	}
	
	public void Damage (int damageCount)
	{
		
		hp -= damageCount;
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
	
	
