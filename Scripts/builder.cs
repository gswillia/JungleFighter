using System;
using System.Collections.Generic;
using UnityEngine;

public class builder : MonoBehaviour {
    bool concreteP=false;
    public float Xpos;
    public float Ypos;
    public GameObject concrete;
    public GameObject concreteTemp;
    public bool exists= false;
    List<float> listX = new List<float>();
    List<float> listY = new List<float>();

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	public void Update () {
        concreteP = flloors.conP;


        if (concreteP)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (PlayerScript.cash > 9)
                {
                    Xpos = Input.mousePosition.x;
                    Ypos = Input.mousePosition.y;
                    Vector3 a = Camera.main.ScreenToWorldPoint(new Vector3(Xpos, Ypos,10));
                    a.x = roundFive(a.x);
                    a.y = roundFive(a.y);
                    a.z = 6;

                    for (int i = 0; i < listX.Count; i++)
                    {
                        
                        if (listX[i]==a.x)
                        {
                            if (listY[i]==a.y)
                            {
                                exists = true;
                            }
                        }
                    }
                    if (exists==false)
                    {
                        PlayerScript.cash = PlayerScript.cash - 10;
                        Instantiate(concrete, a, Quaternion.identity);
                        listX.Add(a.x);
                        listY.Add(a.y);
                    }
                    exists = false;
                }
            }
            else if (Input.GetMouseButtonDown(1))
            {
                concreteP = false;
                flloors.conP = concreteP;
            }
        }
    }
    float roundFive(float D)
    {
        D = D/ 5;
        D = Mathf.FloorToInt(D);
        D = D * 5;
        return D;
    }
}
