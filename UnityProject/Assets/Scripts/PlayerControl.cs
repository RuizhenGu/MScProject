using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rigid;
    Vector2 move;
    public float velocity;
    //Vector3 nextDoor;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        //nextDoor = GameObject.Find("endDoor").GetComponent<DoorTrigger>().nextDoor;
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate()
    {
        rigid.MovePosition(rigid.position + move * velocity * Time.fixedDeltaTime);
        //if (move.x != 0)
        //{
        //    transform.Rotate(0f, 180f, 0f);
        //}
    }
}
