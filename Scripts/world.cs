using UnityEngine;
using System.Collections;
using System;

public class world : MonoBehaviour {

    public GameObject grassTile1;
    public GameObject grassTile2;
    public GameObject tree;
    public GameObject pTree;
    public GameObject dirtTile;
    public GameObject fieldTile;
    public GameObject rockTile;
    public Rigidbody2D bushTile;

    public int x = -1250;
    public int y = 1240;
    public int z;
    public int c = 0;
    public int rando;
    public int count = 0;
    public int grass1;
    public int grass2;

    

    void Start () {
        System.Random random = new System.Random();

        /////////////////////////////////////////////////////////////////world creation////////////////////////////////////////////////////////



        while (c < 30000)//bush
        {
            x = random.Next(-1250, 1250);
            y = random.Next(-1250, 1250);
            if (y > -100 && y < 100) //blocks placement at spawn
            {
                while (x > -100 && x < 100)
                {
                    x = random.Next(-1250, 1250);
                }
            }

            z = random.Next(0,361);
            Instantiate(bushTile, new Vector3(x, y, 6), Quaternion.Euler(0, 0, z));
          //  Instantiate(bushTile, new Vector3(x+3, y+3, 6), Quaternion.Euler(0, 0, z));
           // Instantiate(bushTile, new Vector3(x-3, y+3, 6), Quaternion.Euler(0, 0, z));
            c++;
        }





        c = 0;
        while (c < 25000) //tree
        {
            x = random.Next(-1250, 1250);
            y = random.Next(-1250, 1250);
            if (y > -100 && y < 100) //blocks placement at spawn
            {
                while (x > -100 && x < 100)
                {
                    x = random.Next(-1250, 1250);
                }
            }
            z = random.Next(0, 361);
            Instantiate(tree, new Vector3(x, y, 6), Quaternion.Euler(0, 0, z));
            c++;
        }
        c = 0;
        //
        while (c < 6000) //pTree
        {
            x = random.Next(-1250, 1250);
            y = random.Next(-1250, 1250);
            if (y > -100 && y < 100) //blocks placement at spawn
            {
                while (x > -100 && x < 100)
                {
                    x = random.Next(-1250, 1250);
                }
            }
            z = random.Next(0, 361);
            Instantiate(pTree, new Vector3(x, y, 6), Quaternion.Euler(0, 0, z));
            c++;
        }
        c = 0;
        //

        //intiate grid//
        x = -1250;
        y = 1240;
        c = 0;


        while (count < 250)
        {
            x = -1250;
            while (c < 250)
            {
                rando = random.Next(0, 198);
                if (rando < 101)
                {
                    Instantiate(grassTile1, new Vector3(x, y, 6), Quaternion.identity);
                    x = x + 10;
                    c++;
                }
                else if (rando > 100 && rando < 197)
                {
                    Instantiate(grassTile2, new Vector3(x, y, 6), Quaternion.identity);
                    x = x + 10;
                    c++;
                }
                else if (rando == 197)
                {
                    Instantiate(rockTile, new Vector3(x, y, 6), Quaternion.identity);
                    x = x + 10;
                    c++;
                }
                else if (rando == 198)
                {
                    Instantiate(fieldTile, new Vector3(x, y, 6), Quaternion.identity);
                    x = x + 10;
                    c++;
                }
                else if (rando == 199)
                {
                    Instantiate(dirtTile, new Vector3(x, y, 6), Quaternion.identity);
                    x = x + 10;
                    c++;
                }
            }
            y = y - 10;
            c = 0;
            count++;
        }
    }
	
	// Update is called once per frame
	void Update () {
	








	}
}
