using UnityEngine;
using System.Collections;

public class grassTile : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.name == "GRASSTILE")
        {
            Destroy(gameObject);

        }



    }
}
