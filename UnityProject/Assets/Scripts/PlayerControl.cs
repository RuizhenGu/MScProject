using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rigid;
    Vector2 move;
    public float velocity;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        if (move.x != 0)
        {
            transform.localScale = new Vector3(move.x, 1, 1);
        }
    }

    private void FixedUpdate()
    {
        rigid.MovePosition(rigid.position + move * velocity * Time.fixedDeltaTime);
    }
}
