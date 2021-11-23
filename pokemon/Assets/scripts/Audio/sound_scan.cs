using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_scan : MonoBehaviour {

    // Use this for initialization
    void Start () {
        //固定一个节奏去扫描，每隔0.5s扫描一次
        this.InvokeRepeating("scan",0, 0.5f);
    }
    
    // Update is called once per frame
    void Update () {
        
    }

    //定时器函数
    void scan()
    {
        sound_manager.disable_over_audio();//调用隐藏AudioSource组件接口
    }
}