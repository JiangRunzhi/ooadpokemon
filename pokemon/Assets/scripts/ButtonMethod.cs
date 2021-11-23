using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMethod : MonoBehaviour
{
    public GameObject go;

    public void InitialAppear()
    {
        go.GetComponent<DataBase>().Appear(1,0);
        Invoke("SecondAppear",10f);
    }

    public void SecondAppear()
    {
        go.GetComponent<DataBase>().Appear(2,0);
    }

    public void Hit()
    {
        go.GetComponent<DataBase>().Hit();
    }

    public void Special()
    {
        go.GetComponent<DataBase>().Special();
    }

    public void Buff()
    {
        go.GetComponent<DataBase>().Buff();
    }
    
    public void Debuff()
    {
        go.GetComponent<DataBase>().Debuff();
    }
}