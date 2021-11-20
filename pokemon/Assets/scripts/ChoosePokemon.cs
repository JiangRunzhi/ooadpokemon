using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePokemon : MonoBehaviour
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
         pikachuBtn.image.color = Color.grey;
     }

     void OnCharmanderClick()
     {
         charmanderBtn.image.color = Color.grey;
     }
     
     void OnSquirtleClick()
     {
         squirtleBtn.image.color = Color.grey;
     }
     
     void OnBulbasaurClick()
     {
         bulbasaurBtn.image.color = Color.grey;
     }
     
     void OnMukClick()
     {
         mukBtn.image.color = Color.grey;
     }
     
     void OnPidgeottoClick()
     {
         pidgeottoBtn.image.color = Color.grey;
     }

}
