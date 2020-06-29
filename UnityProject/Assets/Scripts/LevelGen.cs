using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGen : MonoBehaviour
{

    public GameObject floor3x3, floor5x5;
    public GameObject wallPoint31, wallPoint32, wallPoint33, wallPoint34, wallPoint35, wallPoint36, wallPoint37, wallPoint38, wallPoint39, wallPoint310, wallPoint311, wallPoint312, wallPoint313, wallPoint314, wallPoint315, wallPoint316,
        wallPoint51, wallPoint52, wallPoint53, wallPoint54, wallPoint55, wallPoint56, wallPoint57, wallPoint58, wallPoint59, wallPoint510, wallPoint511, wallPoint512, wallPoint513, wallPoint514, wallPoint515, wallPoint516, wallPoint517, wallPoint518, wallPoint519, wallPoint520, wallPoint521, wallPoint522, wallPoint523, wallPoint524;
    public int levelNum;
    //public Color startColor, endColor;
    public Transform startPoint;
    public GameObject wall;
    public LayerMask floorMask;
    public List<GameObject> floors = new List<GameObject>();
    public List<GameObject> wallPoints3 = new List<GameObject>();
    public List<GameObject> wallPoints5 = new List<GameObject>();
    public List<List<GameObject>> levelList = new List<List<GameObject>>();


    // Start is called before the first frame update
    void Start()
    {
        AllLevelGen();
        for (int i = 0; i < wallPoints5.Count; i++)
        {
            Instantiate(wall, wallPoints5[i].transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void AllLevelGen()
    {
        AddWallPoints();
        for (int i = 0; i < levelNum; i++)
        {
            SingleLevelGen();
            levelList.Add(floors);
            print(levelList.Count);
            print(levelList[i].Count);
        }
    }

    void SingleLevelGen()
    {
        int[] levelLen = { 5, 6, 7, 8, 9, 10 };
        System.Random rndLen = new System.Random((int)DateTime.Now.Ticks);
        int lenIndex = rndLen.Next(levelLen.Length);
        int floorNum = levelLen[lenIndex];
        startPoint.position += new Vector3(60.0f, 0, 0);
        for (int i = 0; i < floorNum; i++)
        {
            GetSize(out int thisSize); 
            //print(thisSize);
            switch (thisSize)
            {
                case 3: 
                    floors.Add(Instantiate(floor3x3, startPoint.position, Quaternion.identity));
                    Direction3(out int xOffset3, out int yOffset3);
                    startPoint.position += new Vector3(xOffset3, yOffset3, 0);
                    break;
                case 5:
                    floors.Add(Instantiate(floor5x5, startPoint.position, Quaternion.identity));
                    Direction5(out int xOffset5, out int yOffset5);
                    startPoint.position += new Vector3(xOffset5, yOffset5, 0);
                    break;
            }

        }
        GenerateWalls();
        //print(floors.Count);
        
    }

    void GetSize(out int thisSize)
    {
        int[] size = { 3, 5 };
        System.Random rndSize = new System.Random((int)DateTime.Now.Ticks);
        int sizeIndex = rndSize.Next(size.Length);
        thisSize = size[sizeIndex];
        //print(thisSize);
    }

    void Direction3(out int xOffset3, out int yOffset3)
    {
        int[] offset = { -2, -1, 1, 2 };
        System.Random rnd3x = new System.Random((int)DateTime.Now.Ticks);
        System.Random rnd3y = new System.Random();
        int xIndex = rnd3x.Next(offset.Length);
        int yIndex = rnd3y.Next(offset.Length);
        xOffset3 = offset[xIndex];
        yOffset3 = offset[yIndex];
    }

    void Direction5(out int xOffset5, out int yOffset5)
    {
        int[] offset = {-3, -2, -1, 1, 2, 3 };
        System.Random rnd5x = new System.Random();
        System.Random rnd5y = new System.Random((int)DateTime.Now.Ticks);
        int xIndex = rnd5x.Next(offset.Length);
        int yIndex = rnd5y.Next(offset.Length);
        xOffset5 = offset[xIndex];
        yOffset5 = offset[yIndex];
    }

    void AddWallPoints()
    {
        wallPoints3.Add(wallPoint31);
        wallPoints3.Add(wallPoint32);
        wallPoints3.Add(wallPoint33);
        wallPoints3.Add(wallPoint34);
        wallPoints3.Add(wallPoint35);
        wallPoints3.Add(wallPoint36);
        wallPoints3.Add(wallPoint37);
        wallPoints3.Add(wallPoint38);
        wallPoints3.Add(wallPoint39);
        wallPoints3.Add(wallPoint310);
        wallPoints3.Add(wallPoint311);
        wallPoints3.Add(wallPoint312);
        wallPoints3.Add(wallPoint313);
        wallPoints3.Add(wallPoint314);
        wallPoints3.Add(wallPoint315);
        wallPoints3.Add(wallPoint316);

        wallPoints5.Add(wallPoint51);
        wallPoints5.Add(wallPoint52);
        wallPoints5.Add(wallPoint53);
        wallPoints5.Add(wallPoint54);
        wallPoints5.Add(wallPoint55);
        wallPoints5.Add(wallPoint56);
        wallPoints5.Add(wallPoint57);
        wallPoints5.Add(wallPoint58);
        wallPoints5.Add(wallPoint59);
        wallPoints5.Add(wallPoint510);
        wallPoints5.Add(wallPoint511);
        wallPoints5.Add(wallPoint512);
        wallPoints5.Add(wallPoint513);
        wallPoints5.Add(wallPoint514);
        wallPoints5.Add(wallPoint515);
        wallPoints5.Add(wallPoint516);
        wallPoints5.Add(wallPoint517);
        wallPoints5.Add(wallPoint518);
        wallPoints5.Add(wallPoint519);
        wallPoints5.Add(wallPoint520);
        wallPoints5.Add(wallPoint521);
        wallPoints5.Add(wallPoint522);
        wallPoints5.Add(wallPoint523);
        wallPoints5.Add(wallPoint524);
    }

    void GenerateWalls()
    {

        foreach (var floor in floors)
        {
            if (floor.CompareTag("3X3"))
            {
                for (int i = 0; i < wallPoints3.Count; i++)
                {
                    if (!Physics2D.OverlapCircle(wallPoints3[i].transform.position + floor.transform.position, 0.2f, floorMask))
                    {
                        Instantiate(wall, wallPoints3[i].transform.position + floor.transform.position, Quaternion.identity);
                    }
                }
            }

            if (floor.CompareTag("5X5"))
            {
                for (int i = 0; i < wallPoints5.Count; i++)
                {
                    if (!Physics2D.OverlapCircle(wallPoints5[i].transform.position + floor.transform.position, 0.2f, floorMask))
                    {
                        Instantiate(wall, wallPoints5[i].transform.position + floor.transform.position, Quaternion.identity);
                    }
                }
            }
        }
    }
}
