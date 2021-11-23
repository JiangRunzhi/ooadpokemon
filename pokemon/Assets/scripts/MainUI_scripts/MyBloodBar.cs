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
    private int hp;

    private void Start()
    {
        hp = hpHolder;
        bloodBar.value = hpHolder;
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
        if(hp<0) return;
        hp-=damage;
        bloodBar.value = (float)hp/hpHolder;//通过改变value的值（float类型）来改变血条长度。
        damage = 0;
        if(hp<=0)
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        //更新血量

        TakeDamge();

        curBlood = (float) hp / hpHolder;

        bloodBar.value = curBlood;
    }
}