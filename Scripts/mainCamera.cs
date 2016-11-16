using UnityEngine;
using System.Collections;

public class mainCamera : MonoBehaviour {

    public float cameraDistOffset = 10;
    private Camera mCamera;
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        mCamera = GetComponent<Camera>();
        player = GameObject.Find("Heli");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerInfo = player.transform.transform.position;
        mCamera.transform.position = new Vector3(playerInfo.x, playerInfo.y, playerInfo.z - cameraDistOffset);
    }
}
