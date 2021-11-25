using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class battle : MonoBehaviour
{
    public void changeScene()
    {
        sound_manager.stop_music("sounds/Login");
        sound_manager.play_music("sounds/battle");
    }
    
}