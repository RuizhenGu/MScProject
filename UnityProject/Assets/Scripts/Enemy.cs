using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public float HP = 100;
    public GameObject deathEffect;
    public Image HPimg;
    private GameObject player;

    //public bool dead;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage(int damage)
    {
        HP -= damage;
        HPimg.fillAmount = (HP / 100f);
        //PlayerMain player = GetComponent<PlayerMain>();
        if (HP <= 0)
        {

            Instantiate(deathEffect, transform.position, Quaternion.identity);
            //player.GetComponent<PlayerMain>().GainEXP();
            PlayerMain playerMain = player.GetComponent<PlayerMain>();
            playerMain.GainEXP();
            Destroy(gameObject);
            
            //Debug.Log("test");
        }
    }
}
