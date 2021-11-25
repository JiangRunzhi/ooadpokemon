using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffAnimation : MonoBehaviour
{
    public GameObject pokemon;
    public Animator animator;
    void Update()
    {
        animator = pokemon.GetComponent<Animator>();
        animator.SetTrigger("buff");
        sound_manager.play_effect("sounds/up");
        enabled = false;
    }

    public void Set(string objectName)
    {
        pokemon = GameObject.Find(objectName);
    }
}