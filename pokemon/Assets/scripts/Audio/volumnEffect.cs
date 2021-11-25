using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumnEffect : MonoBehaviour
{
    public Slider slider;

    
    private void Start()
    {
        if (sound_manager.effect_volume != 1f)
        {
            slider.value = sound_manager.effect_volume;
        }
    }
    private void Update()
    {
        sound_manager.set_effect_volume(slider.value);
    }
}