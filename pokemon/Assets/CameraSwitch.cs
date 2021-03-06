using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject pokemon;
    public int frame;
    
    void Update()
    {
        if (Time.frameCount - frame < 250)
        {
            transform.RotateAround(pokemon.transform.position, Vector3.up, 60 * Time.deltaTime);
            transform.LookAt(pokemon.transform.position);
        }
        else
        {
            transform.position = new Vector3(0, 4, -10);
            transform.localEulerAngles = Vector3.forward;
            enabled = false;
        }
    }

    public void Set(String pokemonName)
    {
        pokemon = GameObject.Find(pokemonName);
        transform.position = new Vector3(0, 8, 5);
        transform.LookAt(pokemon.transform.position);
        frame = Time.frameCount;
    }
}
