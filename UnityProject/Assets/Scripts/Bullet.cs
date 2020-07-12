using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 5f;
    public Rigidbody2D bulletRB;
    // Start is called before the first frame update
    void Start()
    {
        bulletRB.velocity = transform.right * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.name);
        if (collision.name == "wall(Clone)")
        {
            Destroy(gameObject);
        }

        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.DealDamage(20);
            Destroy(gameObject);
        }
    }
}
