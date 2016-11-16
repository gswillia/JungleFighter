using UnityEngine;
using System.Collections;

public class tankMove : MonoBehaviour {
	public int hp = 5;
	int cash;
	public Transform tBase;
	public Rigidbody2D boomPrefab;
	public  int tankX=296;
	public  int tankY=250;
	public  int tankXF=296;
	public  int tankYF=225;
	public float speed = 1.0f;
	public float speedJ;
	Vector3 pos1;
	Vector3 pos2;

	// Use this for initialization
	void Start () {
		
		pos1 = new Vector3(tankX,tankY,-7);
		pos2 = new Vector3(tankXF,tankYF,0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
	
	}

	void OnTriggerEnter2D (Collider2D otherCollider)
	{
		
		
		
		
		if (otherCollider.gameObject.name == "bullet(Clone)") {
			
			hp = hp - 1;
			
			if (hp <= 0) {
				Vector2 bull = new Vector2 (tBase.position.x, tBase.position.y);
				cash = PlayerScript.cash;
				cash = cash + 50; 
				PlayerScript.cash = cash;
				Destroy (gameObject);
				Rigidbody2D bPrefab = Instantiate (boomPrefab, bull, Quaternion.identity) as Rigidbody2D;
				bPrefab.GetComponent<Rigidbody2D> ();
			}
			
		}
}
}
