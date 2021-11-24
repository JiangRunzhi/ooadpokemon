using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialA : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pokemon1;
    public GameObject pokemon2;
    public Animator animator1;
    public Animator animator2;
    public bool judge1;
    public bool judge2;
    public bool leftHitRight;
    public bool dodge;
    public bool dead;
    public Vector3 p1;
    public Vector3 p2;
    
    void Update()
    {
        if (judge1)
        {
            animator1.SetTrigger("special");
        }
    }

    public void Set(string name1, string name2,bool dir,bool miss,bool death)
    {
        pokemon1 = GameObject.Find(name1);
        pokemon2 = GameObject.Find(name2);
        animator1 = pokemon1.GetComponent<Animator>();
        animator2 = pokemon2.GetComponent<Animator>();
        judge1 = true;
        judge2 = true;
        leftHitRight = dir;
        dodge = miss;
        dead = death;
    }
}
