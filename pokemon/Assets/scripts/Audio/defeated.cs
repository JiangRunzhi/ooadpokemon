using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defeated : MonoBehaviour
{
    public void defeateds()
    {
        sound_manager.stop_music("sounds/battle");
        sound_manager.play_music("sounds/defeated");
    }
    
    public void stop()
    {
        sound_manager.stop_music("sounds/defeated");
    }
}