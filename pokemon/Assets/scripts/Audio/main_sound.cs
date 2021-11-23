using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_sound : MonoBehaviour {

// Use this for initialization
    void Start () {
        sound_manager.init();//初始化音乐音效管理

        //sound_manager.play_music("Assets/sounds/Login.mp3");//播放背景音乐

        //this.InvokeRepeating("test_music_mute", 1, 3);


        //sound_manager.play_effect("sounds/Close");//播放音效
        // if (sound_manager.effect_is_off())//如果当前是静音，就切换成有声音的状态
        // {
        //     sound_manager.switch_effect();
        // }
        // this.InvokeRepeating("again", 3, 3);//每隔3秒调用一次


        //this.InvokeRepeating("test_effect_mute", 1, 3);
    }
    
}