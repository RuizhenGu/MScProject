using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMain : MonoBehaviour
{
    public float HP = 100;
    public float HPFull = 100;
    public float currentEXP = 0;
    public float EXPFull = 50;
    public Image HPimg;
    public Image EXPimg;
    public Text HPText;
    public Text EXPText;
    public Text LVText;
    public int LV = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HPText.text = HP.ToString() + "/" + HPFull.ToString();
        HPimg.fillAmount = (HP / HPFull);
        EXPText.text = currentEXP.ToString() + "/" + EXPFull.ToString();
        EXPimg.fillAmount = (currentEXP / EXPFull);
        LVText.text = "Lv " + LV;
    }

    public void GetHit(int damage)
    {
        HP -= damage;
        
        if (HP <= 0)
        {
            Debug.Log("dead");
        }
    }

    public void GainEXP()
    {
        //Debug.Log("test");
        currentEXP += 10;
        
        if (currentEXP >= EXPFull)
        {
            LV += 1;

            currentEXP = 0f;
            EXPFull += 10;

            HP += 10;
            HPFull += 10;
        }
    }
}
