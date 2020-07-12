using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    //List<GameObject> startDoorPosition = new List<GameObject>();
    //List<GameObject> endDoorPosition = new List<GameObject>();
    //public GameObject enemyMain;
    //public GameObject door;
    //public Vector3 nextDoor;
    //int width;
    //int height;
    //private GameObject[] enemyCount;
    //public GameObject enemy;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //start = 0;
        //startDoorPosition = GameObject.Find("LevelGen").GetComponent<LevelGen>().startDoorPosition;
        //endDoorPosition = GameObject.Find("LevelGen").GetComponent<LevelGen>().endDoorPosition;
        //player = GameObject.Find("Player");
        //width = GameObject.Find("LevenGen").GetComponent<EnemyMain>().width;
        //height = GameObject.Find("LevenGen").GetComponent<EnemyMain>().height;

        //enemyCount = GameObject.FindGameObjectsWithTag("Enemy");

        //print(endDoorPosition.Count);
    }

    // Update is called once per frame
    void Update()
    {
        //print(player.transform.position);
        //Debug.Log(enemyCount.Length);
        //if (enemyCount.Length == 0)
        //{
        //    Debug.Log("door0");
        //    GeneateDoor();
        //}
    }

    //void Teleport()
    //{
    //    print(player.transform.position);
    //    foreach (var end in endDoorPosition)
    //    {
    //        if (transform.position == end.transform.position)
    //        {
    //            int index = endDoorPosition.IndexOf(end);
    //            if (index == endDoorPosition.Count - 1)
    //            {
    //                player.transform.position = new Vector3(0, 0, 0);
    //            } 
    //            nextDoor = new Vector3(startDoorPosition[index + 1].transform.position.x, startDoorPosition[index + 1].transform.position.y, startDoorPosition[index + 1].transform.position.z);
    //            player.transform.position = nextDoor;
    //            //print(nextDoor);
    //            //print(player.transform.position);
    //            //print(index);      


    //        }
            
    //    }

    //    if (transform.position == new Vector3(0.5f, 2f, 0))
    //    {
    //        nextDoor = new Vector3(startDoorPosition[0].transform.position.x, startDoorPosition[0].transform.position.y, startDoorPosition[0].transform.position.z);
    //        player.transform.position = new Vector3(startDoorPosition[0].transform.position.x, startDoorPosition[0].transform.position.y, startDoorPosition[0].transform.position.z);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D triggerName)
    {
        if (triggerName.name == "Player")
        {
            //EnemyMain enemy = GetComponent<EnemyMain>();
            //Debug.Log("test");
            //Teleport();
            //enemyMain.GetComponent<EnemyMain>().GenerateEnemy();
            //Debug.Log("GenEnemy");
            //enemy.GenerateEnemy();
            player.GetComponent<EnemyMain>().GenerateEnemy();
            Destroy(gameObject);
        }
    }

    //void GeneateDoor()
    //{
    //    int posX = Random.Range(2, width - 2);
    //    int posY = Random.Range(2, height - 2);
    //    Instantiate(door, new Vector3(posX, posY), Quaternion.identity);
    //}

}
