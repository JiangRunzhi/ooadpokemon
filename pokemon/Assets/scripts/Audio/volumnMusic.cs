using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumnMusic : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        if (sound_manager.music_volume != 1f)
        {
            slider.value = sound_manager.music_volume;
        }
    }
    private void Update()
    {
        sound_manager.set_music_volumn(slider.value);
    }
}