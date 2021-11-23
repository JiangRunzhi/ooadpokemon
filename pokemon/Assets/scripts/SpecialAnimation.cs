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
    public bool leftHitRight;
    public bool dodge;
    public bool dead;
    public Vector3 p1;
    public Vector3 p2;
    void Start()
    {
        animator1 = pokemon1.GetComponent<Animator>();
        animator2 = pokemon2.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator1.SetTrigger("special");
        Invoke("hurt",1f);
        enabled = false;
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

    public void Set(string name1, string name2,bool dir,bool miss,bool death)
    {
        pokemon1 = GameObject.Find(name1);
        pokemon2 = GameObject.Find(name2);
        leftHitRight = dir;
        dodge = miss;
        dead = death;
    }
}
