using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float movespeed = 5;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("moveParameter",false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("moveParameter",true);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("moveParameter",false);
        }
        float Hor = Input.GetAxis("Horizontal");
        float Ver = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Ver * Time.deltaTime * 3 * -1);
        transform.Rotate(Vector3.up * Hor * 90 * Time.deltaTime);
    }
}