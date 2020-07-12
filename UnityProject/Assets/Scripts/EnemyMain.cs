using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMain : MonoBehaviour
{
    public int width = 20;
    public int height = 15;
    public Vector3 offset = Vector3.zero;
    public GameObject enemy;
    public GameObject door;
    private GameObject[] enemyCount;
    private GameObject[] doorCount;
    private bool needDoor;

    // Start is called before the first frame update
    void Start()
    {
        Pathfinding.Instance.InitGrid(width, height);
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Debug.DrawLine(new Vector3(x, y) + offset, new Vector3(x, y + 1) + offset, Color.red, 10f);
                Debug.DrawLine(new Vector3(x, y) + offset, new Vector3(x + 1, y) + offset, Color.red, 10f);
            }
        }
        Debug.DrawLine(new Vector3(0, height) + offset, new Vector3(width, height) + offset, Color.red, 50f);
        Debug.DrawLine(new Vector3(width, 0) + offset, new Vector3(width, height) + offset, Color.red, 50f);

        
        //doorCount = GameObject.FindGameObjectsWithTag("Door");
    }

    // Update is called once per frame
    void Update()
    {
        doorCount = GameObject.FindGameObjectsWithTag("Door");
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy");
        //Debug.Log(doorCount);

        if (enemyCount.Length == 0)
        {
            needDoor = true;
        }
        if (doorCount.Length >= 1 || enemyCount.Length >= 1)
        {
            needDoor = false;
        }
        if (needDoor == true)
        {
            GeneateDoor();
        }
    }

    public void GenerateEnemy()
    {
        int posX = Random.Range(2, width - 2);
        int posY = Random.Range(2, height - 2);
        Instantiate(enemy, new Vector3(posX, posY), Quaternion.identity);
    }

    public void GeneateDoor()
    {
        int posX = Random.Range(2, width - 2);
        int posY = Random.Range(2, height - 2);
        Instantiate(door, new Vector3(posX, posY), Quaternion.identity);
    }
}
