using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class combatControl_B : MonoBehaviour
{
    private Animator _animator;
    public static bool action3 = false;
    public static bool action4 = false;
    public static int assist1 = 0;

    public static int frame_counter3 = 0;
    public static int frame_counter4 = 0;
    public static bool hurt = false;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        //go forward
        if (action3)
        {
            frame_counter3++;
        }

        if (action4)
        {
            frame_counter4++;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            action3 = true;
            action4 = true;
            frame_counter3 = 0;
            frame_counter4 = 0;
            _animator.SetBool("walk", true);
            _animator.SetFloat("runSpeed", -5.0f);
        }

        if (frame_counter3==60)
        {
            _animator.SetBool("walk", false);
            _animator.SetFloat("runSpeed", 0f);
            _animator.SetBool("hit", true);
            action3 = false;
        }
        if (frame_counter4==100)
        {
            _animator.SetBool("hit",false);
            action4 = false;
            action3 = true;
        }

        if (frame_counter3>110&&frame_counter3<130)//这个地方其实就是在840ms时执行的动作，但由于这个动作的启动时间超过了一帧，所以设定在接下来20帧都执行这个动作来确保小火龙开始walk
        {
            _animator.SetBool("walk", true);
            _animator.SetFloat("runSpeed", 5.0f);
        }

        if (frame_counter3==172)
        {
            _animator.SetBool("walk", false);
            _animator.SetFloat("runSpeed", 0f);
            action3 = false;
        }
        

        // if (Input.GetKeyUp(KeyCode.UpArrow))
        // {
        //     _animator.SetBool("walk", false);
        //     _animator.SetFloat("runSpeed", 0f);
        //     _animator.SetBool("hit", true);
        //     action3 = false;
        // }
        //
        // //go back
        // if (Input.GetKeyDown(KeyCode.DownArrow))
        // {
        //     _animator.SetBool("walk", true);
        //     _animator.SetFloat("runSpeed", 5.0f);
        // }
        //
        // if (Input.GetKeyUp(KeyCode.DownArrow))
        // {
        //     _animator.SetBool("walk", false);
        //     _animator.SetFloat("runSpeed", 0f);
        // }
        //
        // //hit
        // if (Input.GetKeyDown(KeyCode.N))
        // {
        //     _animator.SetBool("hit", true);
        // }
        //
        // if (Input.GetKeyUp(KeyCode.N))
        // {
        //     _animator.SetBool("hit", false);
        // }

        //hurt
        if (Input.GetKeyDown(KeyCode.J))
        {
            _animator.SetBool("hurt", true);
        }

        if (Input.GetKeyUp(KeyCode.J))
        {
            _animator.SetBool("hurt", false);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            hurt = true;
            assist1 = 0;
        }

        if (hurt)
        {
            assist1++;
        }

        if (assist1>60&&assist1<100)
        {
            _animator.SetBool("hurt",true);
        }

        if (assist1==120)
        {
            _animator.SetBool("hurt",false);
            hurt = false;
        }
    }
}