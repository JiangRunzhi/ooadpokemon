using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffAnimation : MonoBehaviour
{
    public GameObject pokemon;
    public Animator animator;
    void Update()
    {
        animator = pokemon.GetComponent<Animator>();
        animator.SetTrigger("debuff");
        sound_manager.play_effect("sounds/down");
        enabled = false;
    }

    public void Set(string objectName)
    {
        pokemon = GameObject.Find(objectName);
    }
}