using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffAnimation : MonoBehaviour
{
    public GameObject pokemon;
    public Animator animator;
    void Start()
    {
        animator = pokemon.GetComponent<Animator>();
        animator.SetTrigger("debuff");
        enabled = false;
    }

    public void Set(string objectName)
    {
        pokemon = GameObject.Find(objectName);
    }
}