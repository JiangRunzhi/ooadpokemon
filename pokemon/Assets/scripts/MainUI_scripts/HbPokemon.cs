using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HbPokemon : MonoBehaviour
{
    //六种宝可梦按钮
    Button pikachuBtn, charmanderBtn, squirtleBtn, bulbasaurBtn, pidgeottoBtn, mukBtn;
    Transform root;
    
    void Start () {
        //获得脚本挂的Transform
        root = this.transform;
        //获取场景中按钮的引用
        pikachuBtn = root.Find("Pikachu").GetComponent<Button>();
        charmanderBtn = root.Find("Charmander").GetComponent<Button>();
        squirtleBtn = root.Find("Squirtle").GetComponent<Button>();
        bulbasaurBtn = root.Find("Bulbasaur").GetComponent<Button>();
        pidgeottoBtn = root.Find("Pidgeotto").GetComponent<Button>();
        mukBtn = root.Find("Muk").GetComponent<Button>();
        //注册点击事件
        pikachuBtn.onClick.AddListener(OnPikachuClick);
        charmanderBtn.onClick.AddListener(OnCharmanderClick);
        squirtleBtn.onClick.AddListener(OnSquirtleClick);
        bulbasaurBtn.onClick.AddListener(OnBulbasaurClick);
        pidgeottoBtn.onClick.AddListener(OnPidgeottoClick);
        mukBtn.onClick.AddListener(OnMukClick);
    }
    void OnPikachuClick()
    {
        //pikachuBtn.image.sprite = Sprite.Create(die_pokemon2,(1,1),(0,0));
        SceneManager.LoadScene(6);
    }

    void OnCharmanderClick()
    {
        SceneManager.LoadScene(7);
    }
     
    void OnSquirtleClick()
    {
        SceneManager.LoadScene(8);
    }
     
    void OnBulbasaurClick()
    {
        SceneManager.LoadScene(9);
    }
     
    void OnMukClick()
    {
        SceneManager.LoadScene(11);
    }
     
    void OnPidgeottoClick()
    {
        SceneManager.LoadScene(10);
    }

}