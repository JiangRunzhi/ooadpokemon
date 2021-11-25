using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victory : MonoBehaviour
{
    public void victorys()
    {
        sound_manager.stop_music("sounds/battle");
        sound_manager.play_music("sounds/victory");
    }

    public void stop()
    {
        sound_manager.stop_music("sounds/victory");
    }
}