using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Left Attacks, Right Hurts
//Set: Left object, Right object
public class SpecialAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pokemon1;
    public GameObject pokemon2;
    public Animator animator1;
    public Animator animator2;
    public bool judge1;
    public bool leftHitRight;
    public bool dodge;
    public bool dead;
    public Vector3 p1;
    public Vector3 p2;
    void Start()
    {
        animator1 = pokemon1.GetComponent<Animator>();
        animator2 = pokemon2.GetComponent<Animator>();
        if (leftHitRight)
        {
            p1 = new Vector3(14, 0, 5);
            p2 = new Vector3(10, 0, 5);
        }
        else
        {
            p1 = new Vector3(-14, 0, 5);
            p2 = new Vector3(-10, 0, 5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (leftHitRight)
        {
            p1 = new Vector3(14, 0, 5);
            p2 = new Vector3(10, 0, 5);
        }
        else
        {
            p1 = new Vector3(-14, 0, 5);
            p2 = new Vector3(-10, 0, 5);
        }
        animator1 = pokemon1.GetComponent<Animator>();
        animator2 = pokemon2.GetComponent<Animator>();
        if (judge1)
        {
            animator1.SetTrigger("special");
            judge1 = false;
            Invoke("hurt",1f);
        }
        else
        {
            if (pokemon2.transform.position != p2)
            {
                Invoke("run",0f);
            }
            else
            {
                if (dead)
                {
                    Invoke("die",6f);
                }
                enabled = false;
            }
        }
    }
    
    
    public void hurt()
    {
        if (dodge)
        {
            pokemon2.transform.position = p1;
        }
        else if (dead)
        {
            animator2.SetTrigger("dead");
        }
        else
        {
            animator2.SetTrigger("hurt");
        }
    }

    public void run()
    {
        if (pokemon2.transform.position != p2)
        {
            animator2.SetBool("move",true);
            pokemon2.transform.position = Vector3.MoveTowards(pokemon2.transform.position, p2, Time.deltaTime * 10);
        }
        else
        {
            animator2.SetBool("move",false);
        }
    }

    public void die()
    {
        if (dead)
        {
            GameObject go = GameObject.Find("Window");
            if (leftHitRight)
            {
                go.GetComponent<DataBase>().Disappear2();
            }
            else
            {
                go.GetComponent<DataBase>().Disappear1();
            }
        }
    }

    public void Set(string name1, string name2,bool dir,bool miss,bool death)
    {
        pokemon1 = GameObject.Find(name1);
        pokemon2 = GameObject.Find(name2);
        judge1 = true;
        leftHitRight = dir;
        dodge = miss;
        dead = death;
    }
}
