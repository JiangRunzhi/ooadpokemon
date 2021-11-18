using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dragon;
    public GameObject mouse;
    public Animator animator1;
    public Animator animator2;
    private bool judge1;
    private bool judge2;
    private float sum;
    void Start()
    {
        animator1 = dragon.GetComponent<Animator>();
        animator2 = mouse.GetComponent<Animator>();
        animator1.SetBool("move", false);
        animator1.SetBool("hit", false);
        animator2.SetBool("hurt", false);
        judge1 = true;
        judge2 = true;
        sum = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        animator2.SetBool("hurt", false);
        
        if (dragon.transform.position.x < 5 & judge1)
        {
            animator1.SetBool("move", true);
            dragon.transform.Translate(0,0,-Time.deltaTime * 5);
        }
        else if (judge1)
        { 
            animator1.SetBool("move", false);
            animator1.SetBool("hit", true);
            Invoke("hurt",0.2f);
            judge1 = false;
        }
        else
        {
            animator1.SetBool("hit", false);
            animator1.SetBool("move", true);
            if (sum <= 180 && judge2)
            {
                dragon.transform.Rotate(0,-Time.deltaTime * 100,0);
                sum += Time.deltaTime * 100;
            }
            else if (dragon.transform.position.x > -10 && judge2)
            {
                dragon.transform.Translate(0,0, -Time.deltaTime * 5);
            }
            else if (judge2)
            {
                judge2 = false;
            }
            else
            {
                if (sum <= 360)
                {
                    dragon.transform.Rotate(0,-Time.deltaTime * 100,0);
                    sum += Time.deltaTime * 100;
                }
                else
                {
                    animator1.SetBool("move", false);
                }
            }
        }
    }
    
    
    public void hurt()
    {
        animator2.SetBool("hurt", true);
    }
}
