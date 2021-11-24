using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearAnimation : MonoBehaviour
{
    public GameObject pokemon;
    public Animator animator;

    public void Set(string objectName)
    {
        pokemon = GameObject.Find(objectName);
        animator = pokemon.GetComponent<Animator>();
        animator.SetTrigger("appear");
    }
}
