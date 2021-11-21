using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Left Attacks, Right Hurts
//Set: Left object, Right object
public class LARH : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject object1;
    public GameObject object2;
    public Animator animator1;
    public Animator animator2;
    private bool which;
    private bool judge1;
    private Vector3 p1;
    private Vector3 p2;
    void Start()
    {
        animator1 = object1.GetComponent<Animator>();
        animator2 = object2.GetComponent<Animator>();
        animator1.SetBool("move", false);
        animator1.SetBool("hit", false);
        judge1 = true;
        if (which)
        {
            p1 = new Vector3(3, 0, 5);
            p2 = new Vector3(-10, 0, 5);
        }
        else
        {
            p1 = new Vector3(-3, 0, 5);
            p2 = new Vector3(10, 0, 5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (judge1 && object1.transform.position != p1)
        {
            animator1.SetBool("move",true);
            animator1.SetFloat("speed",2f);
            object1.transform.position = Vector3.MoveTowards(object1.transform.position, p1, Time.deltaTime * 20);
        }
        else if (judge1)
        {
            animator1.SetTrigger("hit");
            Invoke("hurt",0.4f);
            judge1 = false;
        }
        else
        {
            Invoke("run",1.0f);
        }
    }
    
    
    public void hurt()
    {
        animator2.SetTrigger("hurt");
    }

    public void run()
    {
        animator1.SetBool("move", true);
        animator1.SetFloat("speed",1f);
        if (object1.transform.position != p2)
        {
            object1.transform.position = Vector3.MoveTowards(object1.transform.position, p2, Time.deltaTime * 10);
        }
        else
        {
            judge1 = true;
            animator1.SetBool("move", false);
            enabled = false;
        }
    }

    public void set(string name1, string name2,bool w)
    {
        object1 = GameObject.Find(name1);
        object2 = GameObject.Find(name2);
        which = w;
    }
}
