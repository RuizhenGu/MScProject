using Packages.Rider.Editor.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class LevelGen : MonoBehaviour
{

    //public GameObject floor3x3, floor5x5;

    public GameObject floor5x5;
    //public GameObject wallPoint31, wallPoint32, wallPoint33, wallPoint34, wallPoint35, wallPoint36, wallPoint37, wallPoint38, wallPoint39, wallPoint310, wallPoint311, wallPoint312, wallPoint313, wallPoint314, wallPoint315, wallPoint316,
    //    wallPoint51, wallPoint52, wallPoint53, wallPoint54, wallPoint55, wallPoint56, wallPoint57, wallPoint58, wallPoint59, wallPoint510, wallPoint511, wallPoint512, wallPoint513, wallPoint514, wallPoint515, wallPoint516, wallPoint517, wallPoint518, wallPoint519, wallPoint520, wallPoint521, wallPoint522, wallPoint523, wallPoint524;
    public GameObject wallPoint51, wallPoint52, wallPoint53, wallPoint54, wallPoint55, wallPoint56, wallPoint57, wallPoint58, wallPoint59, wallPoint510, wallPoint511, wallPoint512, wallPoint513, wallPoint514, wallPoint515, wallPoint516, wallPoint517, wallPoint518, wallPoint519, wallPoint520, wallPoint521, wallPoint522, wallPoint523, wallPoint524;
    //public int levelNum;
    public Transform startPoint;
    public GameObject wall;
    public LayerMask floorMask, wallMask;
    //public List<GameObject> floors;
    //public List<GameObject> wallPoints3 = new List<GameObject>();
    public List<GameObject> wallPoints5 = new List<GameObject>();
    //public List<List<GameObject>> levelList;
    //public GameObject startDoor, endDoor;
    public GameObject endDoor;
    public List<GameObject> startDoorPosition = new List<GameObject>();
    public List<GameObject> endDoorPosition = new List<GameObject>();


    private GameObject[] floors;



    // Start is called before the first frame update
    void Start()
    {

        floors = GameObject.FindGameObjectsWithTag("5X5");
        //Debug.Log(floors.Length);
        GenerateWalls();
        //Debug.Log(floors.Length);
        //Debug.Log(wallPoints5.Count);
        //AllLevelGen();
        //for (int i = 0; i < wallPoints5.Count; i++)
        //{
        //    Instantiate(wall, wallPoints5[i].transform.position, Quaternion.identity);
        //}


    }

    // Update is called once per frame
    void Update()
    {

    }



    //void AllLevelGen()
    //{
    //    AddWallPoints();
    //    List<List<GameObject>> levelList = new List<List<GameObject>>();
    //    for (int i = 0; i < levelNum; i++)
    //    {
    //        if ((i % 2) == 0)
    //        {
    //            startPoint.position = new Vector3(49.5f * (i + 1), 4.5f, 0);
    //        }
    //        if ((i % 2) == 1)
    //        {
    //            startPoint.position = new Vector3(49f * (i + 1) + 0.5f, 4.5f, 0);
    //        }
    //        SingleLevelGen(ref floors);
    //        levelList.Add(floors);
    //        startDoorPosition.Add(Instantiate(startDoor, levelList[i][0].transform.position, Quaternion.identity));
    //        endDoorPosition.Add(Instantiate(endDoor, levelList[i][floors.Count-1].transform.position, Quaternion.identity));
    //    }
    //}


    //void SingleLevelGen(ref List<GameObject> floors)
    //{
    //    int[] levelLen = { 5, 6, 7, 8, 9, 10 };
    //    System.Random rndLen = new System.Random((int)DateTime.Now.Ticks);
    //    int lenIndex = rndLen.Next(levelLen.Length);
    //    int floorNum = levelLen[lenIndex];
    //    //startPoint.position += new Vector3(50.0f, 0, 0);
    //    floors = new List<GameObject>();
    //    for (int i = 0; i < floorNum; i++)
    //    {
    //        GetSize(out int thisSize);
    //        switch (thisSize)
    //        {
    //            case 3: 
    //                floors.Add(Instantiate(floor3x3, startPoint.position, Quaternion.identity));
    //                Direction3(out int xOffset3, out int yOffset3);
    //                startPoint.position += new Vector3(xOffset3, yOffset3, 0);
    //                break;
    //            case 5:
    //                floors.Add(Instantiate(floor5x5, startPoint.position, Quaternion.identity));
    //                Direction5(out int xOffset5, out int yOffset5);
    //                startPoint.position += new Vector3(xOffset5, yOffset5, 0);
    //                break;
    //        }

    //    }
    //    GenerateWalls();
    //    //print(floors.Count);
        
    //}

    //void GetSize(out int thisSize)
    //{
    //    int[] size = { 3, 5 };
    //    System.Random rndSize = new System.Random((int)DateTime.Now.Ticks);
    //    int sizeIndex = rndSize.Next(size.Length);
    //    thisSize = size[sizeIndex];
    //    //print(thisSize);
    //}

    //void Direction3(out int xOffset3, out int yOffset3)
    //{
    //    int[] Xoffset = { -2, -1, 1, 2 };
    //    int[] Yoffset = { 1, 2 };
    //    System.Random rnd3x = new System.Random((int)DateTime.Now.Ticks);
    //    System.Random rnd3y = new System.Random();
    //    int xIndex = rnd3x.Next(Xoffset.Length);
    //    int yIndex = rnd3y.Next(Yoffset.Length);
    //    xOffset3 = Xoffset[xIndex];
    //    yOffset3 = Yoffset[yIndex];
    //}

    //void Direction5(out int xOffset5, out int yOffset5)
    //{
    //    int[] Xoffset = {-3, -2, -1, 1, 2, 3 };
    //    int[] Yoffset = { 1, 2, 3 };
    //    System.Random rnd5x = new System.Random();
    //    System.Random rnd5y = new System.Random((int)DateTime.Now.Ticks);
    //    int xIndex = rnd5x.Next(Xoffset.Length);
    //    int yIndex = rnd5y.Next(Yoffset.Length);
    //    xOffset5 = Xoffset[xIndex];
    //    yOffset5 = Yoffset[yIndex];
    //}

    void AddWallPoints()
    {
        //wallPoints3.Add(wallPoint31);
        //wallPoints3.Add(wallPoint32);
        //wallPoints3.Add(wallPoint33);
        //wallPoints3.Add(wallPoint34);
        //wallPoints3.Add(wallPoint35);
        //wallPoints3.Add(wallPoint36);
        //wallPoints3.Add(wallPoint37);
        //wallPoints3.Add(wallPoint38);
        //wallPoints3.Add(wallPoint39);
        //wallPoints3.Add(wallPoint310);
        //wallPoints3.Add(wallPoint311);
        //wallPoints3.Add(wallPoint312);
        //wallPoints3.Add(wallPoint313);
        //wallPoints3.Add(wallPoint314);
        //wallPoints3.Add(wallPoint315);
        //wallPoints3.Add(wallPoint316);

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
        AddWallPoints();
        foreach (var floor in floors)
        {
            //if (floor.CompareTag("3X3"))
            //{
            //    for (int i = 0; i < wallPoints3.Count; i++)
            //    {
            //        if (!Physics2D.OverlapCircle(wallPoints3[i].transform.position + floor.transform.position - new Vector3(0.5f, 0.5f), 0.2f, floorMask))
            //        {
            //            Instantiate(wall, wallPoints3[i].transform.position + floor.transform.position - new Vector3(0.5f,0.5f), Quaternion.identity);
            //        }
            //    }
            //}

            if (floor.CompareTag("5X5"))
            {
                for (int i = 0; i < wallPoints5.Count; i++)
                {
                    if (!Physics2D.OverlapCircle(wallPoints5[i].transform.position + floor.transform.position - new Vector3(2.5f, 2.5f), 0.2f, floorMask))
                    {
                        Instantiate(wall, wallPoints5[i].transform.position + floor.transform.position - new Vector3(2.5f, 2.5f), Quaternion.identity);
                    }
                }
            }
        }
    }
}
