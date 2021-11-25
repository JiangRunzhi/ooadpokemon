using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMethod : MonoBehaviour
{
    public GameObject go;
    public GameObject A;
    public GameObject B;
    public GameObject C;
    public GameObject D;
    public GameObject A1;
    public GameObject B1;
    public GameObject C1;
    public GameObject D1;
    public GameObject game_start;
    public GameObject CombatInfo;
    public GameObject CombatInfoLable;
    private int cnt = 1;
    
    //妙 火 杰 比 皮 臭
    //0  1  2 3  4 5
    //草 火 水 飞 电 毒
    
    

    public void disableBtns()
    {
        A.SetActive(false);
        B.SetActive(false);
        C.SetActive(false);
        D.SetActive(false);
    }
    public void enableBtns()
    {
        
        A.SetActive(true);
        B.SetActive(true);
        C.SetActive(true);
        D.SetActive(true);
    }
    
    public void disableBtns1()
    {
        A1.SetActive(false);
        B1.SetActive(false);
        C1.SetActive(false);
        D1.SetActive(false);
    }
    public void enableBtns1()
    {
        A1.SetActive(true);
        B1.SetActive(true);
        C1.SetActive(true);
        D1.SetActive(true);
    }
    
    public void InitialAppear()
    {
        go.GetComponent<DataBase>().Read();
        game_start.SetActive(false);
        CombatInfoLable.GetComponent<Text>().text = "战斗就要开始了！！！";
        CombatInfo.SetActive(true);
        
        enableBtns();
        go.GetComponent<DataBase>().Appear1();
        go.GetComponent<DataBase>().number1 = 0;
        go.GetComponent<DataBase>().number2 = 0;
        Invoke("SecondAppear",6f);
    }

    public void SecondAppear()
    {
        go.GetComponent<DataBase>().Appear2();
    }

    public void Hit()
    {
        if (cnt % 2 == 1)
        {
            disableBtns();
            enableBtns1();
        }
        else
        {
            disableBtns1();
            enableBtns();
        }

        cnt++;
        go.GetComponent<DataBase>().Hit();
    }

    public void Special()
    {
        if (cnt % 2 == 1)
        {
            disableBtns();
            enableBtns1();
        }
        else
        {
            disableBtns1();
            enableBtns();
        }

        cnt++;
        go.GetComponent<DataBase>().Special();
    }

    public void Buff()
    {
        if (cnt % 2 == 1)
        {
            disableBtns();
            enableBtns1();
        }
        else
        {
            disableBtns1();
            enableBtns();
        }

        cnt++;
        go.GetComponent<DataBase>().Buff();
    }
    
    public void Debuff()
    {
        if (cnt % 2 == 1)
        {
            disableBtns();
            enableBtns1();
        }
        else
        {
            disableBtns1();
            enableBtns();
        }

        cnt++;
        go.GetComponent<DataBase>().Debuff();
    }
}