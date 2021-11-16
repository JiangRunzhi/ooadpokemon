using UnityEngine;

public class combatControl_A : MonoBehaviour
{
    private Animator _animator;

    public static int frame_counter1 = 1;
    public static int frame_counter2 = 1;
    public static int assist2 = 0;
    public static bool hurt2 = false;
    public static bool action1 = false;
    public static bool action2 = false;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("walk", false);
        _animator.SetBool("hit", false);
        _animator.SetBool("hurt", false);
        Application.targetFrameRate = 90;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("当前帧率：" + 1/(float)Time.deltaTime);
        print(frame_counter1);
        if (action1)
        {
            frame_counter1++;
        }

        if (action2)
        {
            frame_counter2++;
        }

        print(assist2);
        //go forward
        if (Input.GetKeyDown(KeyCode.W))
        {
            action1 = true;
            action2 = true;
            frame_counter1 = 0;
            frame_counter2 = 0;
            _animator.SetBool("walk", true);
            _animator.SetFloat("runSpeed", 5.0f);
        }

        if (frame_counter1==640)
        {
            _animator.SetBool("walk", false);
            _animator.SetFloat("runSpeed", 0f);
            _animator.SetBool("hit", true);
            action1 = false;
        }

        if (frame_counter2==1220)
        {
            _animator.SetBool("hit",false);
            action2 = false;
            action1 = true;
        }

        if (frame_counter1>840&&frame_counter1<860)//这个地方其实就是在840ms时执行的动作，但由于这个动作的启动时间超过了一帧，所以设定在接下来20帧都执行这个动作来确保小火龙开始walk
        {
            _animator.SetBool("walk", true);
            _animator.SetFloat("runSpeed", -5.0f);
        }

        if (frame_counter1==1480)
        {
            _animator.SetBool("walk", false);
            _animator.SetFloat("runSpeed", 0f);
            action1 = false;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            hurt2 = true;
            assist2 = 0;
        }

        if (hurt2)
        {
            assist2++;
        }

        if (assist2>590&&assist2<670)
        {
            _animator.SetBool("hurt",true);
        }

        if (assist2==1150)
        {
            _animator.SetBool("hurt",false);
            hurt2 = false;
        }
    }

    

}