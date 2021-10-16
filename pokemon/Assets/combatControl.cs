using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatControl : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("walk", false);
        _animator.SetBool("hit", false);
        _animator.SetBool("Bstun", false);
    }

    // Update is called once per frame
    void Update()
    {

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
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            _animator.SetBool("hit", true);
            _animator.SetBool("Bstun", true);
        }
        
        if (Input.GetKeyUp(KeyCode.S))
        {
            _animator.SetBool("hit", false);
        }
    }
}