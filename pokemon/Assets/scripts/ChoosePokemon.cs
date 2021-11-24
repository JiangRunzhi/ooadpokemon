using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ChoosePokemon : MonoBehaviour
{
    //六种宝可梦按钮
    private Button pikachuBtn, charmanderBtn, squirtleBtn, bulbasaurBtn, pidgeottoBtn, mukBtn;//,confirmBtn;
    Transform root;
    private int cnt = 0;
    public static int[] selectedPokemons = new int[6];
    public HashSet<int> sel = new HashSet<int>();
    
    void Start () {
        for (int i = 0; i < 6; i++)
        {
            selectedPokemons[i] = -1;
        }

        cnt = 0;

        //获得脚本挂的Transform
        root = this.transform;
        //获取场景中按钮的引用
        pikachuBtn = root.Find("Pikachu").GetComponent<Button>();
        charmanderBtn = root.Find("Charmander").GetComponent<Button>();
        squirtleBtn = root.Find("Squirtle").GetComponent<Button>();
        bulbasaurBtn = root.Find("Bulbasaur").GetComponent<Button>();
        pidgeottoBtn = root.Find("Pidgeotto").GetComponent<Button>();
        mukBtn = root.Find("Muk").GetComponent<Button>();
        //confirmBtn = root.Find("Confirm").GetComponent<Button>();
        //注册点击事件
        pikachuBtn.onClick.AddListener(OnPikachuClick);
        charmanderBtn.onClick.AddListener(OnCharmanderClick);
        squirtleBtn.onClick.AddListener(OnSquirtleClick);
        bulbasaurBtn.onClick.AddListener(OnBulbasaurClick);
        pidgeottoBtn.onClick.AddListener(OnPidgeottoClick);
        mukBtn.onClick.AddListener(OnMukClick);
        //confirmBtn.onClick.AddListener(OnConfirmClick);
    }

    int[] getSelectedPokemons()
    {
        return selectedPokemons;
    }

    void OnConfirmClick()
    {
        //设置好传出的数组
        for (int i = 0; i < 6; i++)
        {
            if (selectedPokemons[i] == -1)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (!sel.Contains(j))
                    {
                        selectedPokemons[i] = j;
                        sel.Add(j);
                        break;
                    }
                }
            }
        }
        using (StreamWriter sw = new StreamWriter("names.txt"))
        {
            foreach (int s in selectedPokemons)
            {
                sw.WriteLine(s);
            }
        }
        SceneManager.LoadScene(1);
    }

    void OnPikachuClick() // 4.皮卡丘
     {
         //pikachuBtn.image.sprite = Sprite.Create(die_pokemon2,(1,1),(0,0));
         if (pikachuBtn.image.color != Color.grey && cnt < 3)
         {
             pikachuBtn.image.color = Color.grey;
             selectedPokemons[cnt] = 4;
             sel.Add(4);
             cnt++;
         }
     }

     void OnCharmanderClick() // 1.小火龙
     {
         if (charmanderBtn.image.color != Color.grey && cnt < 3)
         {
             charmanderBtn.image.color = Color.grey;
             selectedPokemons[cnt] = 1;
             sel.Add(1);
             cnt++;
         }
     }
     
     void OnSquirtleClick() // 2.杰尼龟
     {
         if (squirtleBtn.image.color != Color.grey && cnt < 3)
         {
             squirtleBtn.image.color = Color.grey;
             selectedPokemons[cnt] = 2;
             sel.Add(2);
             cnt++;
         }
     }
     
     void OnBulbasaurClick() // 0.妙蛙种子
     {
         if (bulbasaurBtn.image.color != Color.grey && cnt < 3)
         {
             bulbasaurBtn.image.color = Color.grey;
             selectedPokemons[cnt] = 0;
             sel.Add(0);
             cnt++;
         }
     }
     
     void OnMukClick() // 5.臭臭泥
     {
         if (mukBtn.image.color != Color.grey && cnt < 3)
         {
             mukBtn.image.color = Color.grey;
             selectedPokemons[cnt] = 5;
             sel.Add(5);
             cnt++;
         }
     }
     
     void OnPidgeottoClick() // 3.比比鸟
     {
         if (pidgeottoBtn.image.color != Color.grey && cnt < 3)
         {
             pidgeottoBtn.image.color = Color.grey;
             selectedPokemons[cnt] = 3;
             sel.Add(3);
             cnt++;
         }
     }

}
