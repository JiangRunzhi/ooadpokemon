using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class combatControl_A : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("walk", false);
        _animator.SetBool("hit", false);
        _animator.SetBool("hurt", false);
    }

    // Update is called once per frame
    void Update()
    {
        //go forward
        if (Input.GetKeyDown(KeyCode.W))
        {
            _animator.SetBool("walk", true);
            _animator.SetFloat("runSpeed", 5.0f);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            _animator.SetBool("walk", false);
            _animator.SetFloat("runSpeed", 0f);
        }
        
        //go back
        if (Input.GetKeyDown(KeyCode.S))
        {
            _animator.SetBool("walk", true);
            _animator.SetFloat("runSpeed", -5.0f);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            _animator.SetBool("walk", false);
            _animator.SetFloat("runSpeed", 0f);
        }
        
        //hit
        if (Input.GetKeyDown(KeyCode.J))
        {
            _animator.SetBool("hit", true);
        }
        
        if (Input.GetKeyUp(KeyCode.J))
        {
            _animator.SetBool("hit", false);
        }
        
        //hurt
        if (Input.GetKeyDown(KeyCode.N))
        {
            _animator.SetBool("hurt", true);
        }
        
        if (Input.GetKeyUp(KeyCode.N))
        {
            _animator.SetBool("hurt", false);
        }
    }
}