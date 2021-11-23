using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_scene : MonoBehaviour {

// Use this for initialization
    void Start () {
        sound_manager.init();//初始化音乐音效管理

        sound_manager.play_music("sounds/Login");
        
        Debug.Log("main_scene!");
        //this.InvokeRepeating("test_music_mute", 1, 3);


        //sound_manager.play_effect("sounds/Close");//播放音效
        // if (sound_manager.effect_is_off())//如果当前是静音，就切换成有声音的状态
        // {
        //     sound_manager.switch_effect();
        // }
        // this.InvokeRepeating("again", 3, 3);//每隔3秒调用一次


        //this.InvokeRepeating("test_effect_mute", 1, 3);
    }

    //背景音乐静音切换测试函数
    void test_music_mute()
    {
        Debug.Log("test_music_mute");
        sound_manager.switch_music();
    }

    //音效静音切换测试函数
    void test_effect_mute()
    {
        Debug.Log("test_effect_mute");
        sound_manager.switch_effect();
    }

    //隐藏AudioSource组件优化测试函数
    void again()
    {
        sound_manager.play_effect("sounds/Close");
    }

    // Update is called once per frame
    void Update () {
        
    }
}