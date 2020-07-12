using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletSpeed = 2f;
    public Rigidbody2D bulletRB;
    public int enemyDamage = 10;
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
        if (collision.name == "wall(Clone)")
        {
            Destroy(gameObject);
        }
        PlayerMain player = collision.GetComponent<PlayerMain>();
        if (player != null)
        {
            player.GetHit(enemyDamage);
            Destroy(gameObject);
        }
    }
}
