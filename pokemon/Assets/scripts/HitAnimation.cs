using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

//Left Attacks, Right Hurts
//Set: Left object, Right object
public class HitAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pokemon1;
    public GameObject pokemon2;
    public Animator animator1;
    public Animator animator2;
    public bool leftHitRight;
    public bool dodge;
    public bool dead;
    public bool judge1;
    public Vector3 p1;
    public Vector3 p2;

    void Start()
    {

        animator1 = pokemon1.GetComponent<Animator>();
        animator2 = pokemon2.GetComponent<Animator>();
        animator1.SetBool("move", false);
        judge1 = true;
        if (leftHitRight)
        {
            p1 = new Vector3(4, 0, 5);
            p2 = new Vector3(-10, 0, 5);
        }
        else
        {
            p1 = new Vector3(-4, 0, 5);
            p2 = new Vector3(10, 0, 5);
        }

    }

    // Update is called once per frame
    void Update()
    {
        animator1 = pokemon1.GetComponent<Animator>();
        animator2 = pokemon2.GetComponent<Animator>();
        
        if (leftHitRight)
        {
            p1 = new Vector3(4, 0, 5);
            p2 = new Vector3(-10, 0, 5);
        }
        else
        {
            p1 = new Vector3(-4, 0, 5);
            p2 = new Vector3(10, 0, 5);
        }
        if (judge1 && pokemon1.transform.position != p1)
        {
            animator1.SetBool("move",true);
            animator1.SetFloat("speed",2f);

            pokemon1.transform.position = Vector3.MoveTowards(pokemon1.transform.position, p1, Time.deltaTime * 20);
            
        }
        else if (judge1)
        {
            animator1.SetTrigger("hit");
            Invoke("hurt",0.3f);
            judge1 = false;
        }
        else if (pokemon1.transform.position != p2)
        {
            Invoke("run",1.0f);
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
    
    
    public void hurt()
    {
        if (dodge)
        {
            if (leftHitRight)
            {
                pokemon2.transform.position = new Vector3(14, 0, 5);
            }
            else
            {
                pokemon2.transform.position = new Vector3(-14, 0, 5);
            }
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
        animator1.SetBool("move", true);
        animator1.SetFloat("speed",1f);
        if (pokemon1.transform.position != p2)
        {
            pokemon1.transform.position = Vector3.MoveTowards(pokemon1.transform.position, p2, Time.deltaTime * 10);
            if (leftHitRight && pokemon2.transform.position != new Vector3(10,0,5))
            {
                animator2.SetBool("move",true);
                pokemon2.transform.position = Vector3.MoveTowards(pokemon2.transform.position, new Vector3(10, 0, 5),Time.deltaTime * 10);
            }
            else if (!leftHitRight && pokemon2.transform.position != new Vector3(-10,0,5))
            {
                animator2.SetBool("move",true);
                pokemon2.transform.position = Vector3.MoveTowards(pokemon2.transform.position, new Vector3(-10, 0, 5),Time.deltaTime * 10);
            }
            else
            {
                animator2.SetBool("move",false);
            }
        }
        else
        {
            animator1.SetBool("move", false);
        }
    }
    
    public void die()
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
        enabled = false;
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
