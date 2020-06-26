using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGen : MonoBehaviour
{

    public GameObject floor3x3, floor5x5;
    public int floorNum;
    public Color startColor, endColor;
    public Transform startPoint;



    // Start is called before the first frame update
    void Start()
    {
        SingleLevelGen();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void SingleLevelGen()
    {
        for (int i = 0; i < floorNum; i++)
        {
            GetSize(out int thisSize);
            //print(thisSize);
            switch (thisSize)
            {
                case 3: 
                    Instantiate(floor3x3, startPoint.position, Quaternion.identity);
                    Direction3(out int xOffset3, out int yOffset3);
                    startPoint.position += new Vector3(xOffset3, yOffset3, 0);
                    break;
                case 5:
                    Instantiate(floor5x5, startPoint.position, Quaternion.identity);
                    Direction5(out int xOffset5, out int yOffset5);
                    startPoint.position += new Vector3(xOffset5, yOffset5, 0);
                    break;
            }
        }
    }

    void GetSize(out int thisSize)
    {
        int[] size = { 3, 5 };
        System.Random rndSize = new System.Random((int)DateTime.Now.Ticks);
        int sizeIndex = rndSize.Next(size.Length);
        thisSize = size[sizeIndex];
        print(thisSize);
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
        System.Random rnd5x = new System.Random((int)DateTime.Now.Ticks);
        System.Random rnd5y = new System.Random();
        int xIndex = rnd5x.Next(offset.Length);
        int yIndex = rnd5y.Next(offset.Length);
        xOffset5 = offset[xIndex];
        yOffset5 = offset[yIndex];
    }


}
