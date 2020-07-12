using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    private enum State { Romaing, Chasing, Attacking};

    private Vector3 originPosition;
    //public int width = 20;
    //public int height = 10;
    //public Vector3 offset = Vector3.zero;
    public float speed = 0.8f;
    GameObject player;
    //private Vector3 roamingPos;
    private Vector3 roamingPosition;
    private State state;
    public GameObject enemyBullet;
    public Transform enemyFirePoint;
    public Transform enemyAimPosition;
    private float AttackCD = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        originPosition = transform.position;

        state = State.Romaing;
        roamingPosition = Roaming();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        //float roamSpeed = 0.01f;
        //Debug.Log(state);
        switch (state)
        {
            case State.Romaing:
                List<SearchNode> roamingPath = Pathfinding.Instance.FindPath(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y), Mathf.FloorToInt(roamingPosition.x), Mathf.FloorToInt(roamingPosition.y));
                float distanceBetween = 2f;

                for (int i = 0; i < roamingPath.Count - 1; i++)
                {
                    Debug.DrawLine(new Vector3(roamingPath[i].x, roamingPath[i].y) + Vector3.one / 2, new Vector3(roamingPath[i + 1].x, roamingPath[i + 1].y) + Vector3.one / 2, Color.green, 50f);
                }

                for (int i = 0; i < roamingPath.Count; i++)
                {
                    float step = speed * Time.deltaTime;
                    if (transform.position != new Vector3(roamingPath[i].x, roamingPath[i].y) && roamingPath.Count > 1)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(roamingPath[i].x + 0.5f, roamingPath[i].y + 0.5f), step);

                    }
                }
                if (Vector3.Distance(transform.position, roamingPosition) < distanceBetween)
                {
                    roamingPosition = Roaming();
                }
                ChasePlayer();
                break;
            case State.Chasing:
                List<SearchNode> chasingPath = Pathfinding.Instance.FindPath(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y), Mathf.FloorToInt(playerPosition.x), Mathf.FloorToInt(playerPosition.y));
                for (int i = 0; i < chasingPath.Count - 1; i++)
                {
                    Debug.DrawLine(new Vector3(chasingPath[i].x, chasingPath[i].y) + Vector3.one / 2, new Vector3(chasingPath[i + 1].x, chasingPath[i + 1].y) + Vector3.one / 2, Color.green, 50f);
                }
                for (int i = 0; i < chasingPath.Count; i++)
                {
                    float step = speed * Time.deltaTime;
                    if (transform.position != new Vector3(chasingPath[i].x, chasingPath[i].y) && chasingPath.Count > 1)
                    {
                        transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(chasingPath[i].x + 0.5f, chasingPath[i].y + 0.5f), step);
                    }
                }
                AttackPlayer();
                break;
            case State.Attacking:

                AttackPlayer();

                break;
            default:
                break;
        }
    }

    private Vector3 Roaming()
    {
        Vector3 position_0 = new Vector3(originPosition.x, originPosition.y);
        Vector3 position_1 = new Vector3(originPosition.x - 2f, originPosition.y + 2f);
        Vector3 position_2 = new Vector3(originPosition.x, originPosition.y + 2f);
        Vector3 position_3 = new Vector3(originPosition.x + 2f, originPosition.y + 2f);
        Vector3 position_4 = new Vector3(originPosition.x - 2f, originPosition.y);
        Vector3 position_5 = new Vector3(originPosition.x + 2f, originPosition.y);
        Vector3 position_6 = new Vector3(originPosition.x - 2f, originPosition.y - 2f);
        Vector3 position_7 = new Vector3(originPosition.x, originPosition.y - 2f);
        Vector3 position_8 = new Vector3(originPosition.x + 2f, originPosition.y + 2f);
        int getPosition = Random.Range(0, 10);
        //Debug.Log(getPosition);
        if (getPosition == 0)
        {
            roamingPosition = position_0;
        }
        if (getPosition == 1)
        {
            roamingPosition = position_1;
        }
        if (getPosition == 2)
        {
            roamingPosition = position_2;
        }
        if (getPosition == 3)
        {
            roamingPosition = position_3;
        }
        if (getPosition == 4)
        {
            roamingPosition = position_4;
        }
        if (getPosition == 5)
        {
            roamingPosition = position_5;
        }
        if (getPosition == 6)
        {
            roamingPosition = position_6;
        }
        if (getPosition == 7)
        {
            roamingPosition = position_7;
        }
        if (getPosition == 8)
        {
            roamingPosition = position_8;
        }
        return roamingPosition;
    }

    private void ChasePlayer()
    {
        float chaseRange = 5f;
        if (Vector3.Distance(transform.position, player.transform.position) < chaseRange)
        {
            state = State.Chasing;
        }
    }

    private void AttackPlayer()
    {

        float attackRange = 3f;
        Vector3 targetPosition = player.transform.position;
        Vector3 targetDirection = (targetPosition - transform.position).normalized;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        enemyAimPosition.eulerAngles = new Vector3(0, 0, angle);
        if (Vector3.Distance(transform.position, player.transform.position) < attackRange)
        {
            state = State.Attacking;
            transform.position = Vector3.MoveTowards(transform.position, transform.position, 0f);
            if (Time.time > AttackCD)
            {
                float CD = 1.5f;
                EnemyFire();
                AttackCD = Time.time + CD;
            }
        }
        else
        {
            ChasePlayer();
        }
    }

    private void EnemyFire()
    {
        Instantiate(enemyBullet, enemyFirePoint.position, enemyFirePoint.rotation);
    }
}
