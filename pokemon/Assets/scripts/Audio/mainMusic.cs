using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainMusic : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        if (sound_manager.main_volume != 1f)
        {
            slider.value = sound_manager.main_volume;
        }
    }

    private void Update()
    {
        sound_manager.set_main_volumn(slider.value);
    }
}