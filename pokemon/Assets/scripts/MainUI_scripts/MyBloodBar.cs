using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyBloodBar : MonoBehaviour
{
    private float curBlood = 0f;
    private float targetBlood = 1.0f;
    public Slider bloodBar;

    public int damage;
    public int hpHolder;
    private float hp;
    private int cnt;
    private int cntt;

    private void Start()
    {
        hp = hpHolder;
        bloodBar.value = hpHolder;
        cnt = 0;
        cntt = 0;
        //初始化
        //绑定按钮点击事件
        //buttonAdd->addBlood
        //buttonDes->desBlood
    }

    public void addBlood()
    {
        //加血
    }

    public void desBlood()
    {
        //减血 
    }
    
    void TakeDamge()//当受到伤害
    {
        if (damage == 0)
        {
            return;
        }

        if (cntt <= 50)
        {
            if (hp <= 0)
            {
                damage = 0;
                Destroy(this.gameObject);
            }
            
            hp -= (float)damage / 5000;
            bloodBar.value = hp / hpHolder;
            cntt++;
            return;
        }
        
        if (cnt <= 99)
        {
            if (hp <= 0)
            {
                damage = 0;
                Destroy(this.gameObject);
            }
            
            hp -= (float)damage / 100;
            bloodBar.value = hp / hpHolder;
            cnt++;
        }
        else
        {
            damage = 0;
            cnt = 0;
            cntt = 0;
        }
    }

    void Update()
    {
        //更新血量

        TakeDamge();
    }
}