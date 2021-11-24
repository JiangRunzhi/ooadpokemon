using System;
using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataBase : MonoBehaviour
{
    //妙 火 杰 比 皮 臭
    //0 1 2 3 4 5
    public GameObject go;
    public GameObject ac;
    public GameObject mc;
    public GameObject bp;
    public int[] blood = {15, 15, 15, 15, 15, 20};
    public int[] defense = {3, 3, 4, 3, 3, 3};
    public int[] attack = {6, 8, 6, 6, 8, 10};
    public int[] speed = {3, 4, 3, 4, 6, 3};
    public int[] player1List = {1,2,3};
    public int[] player2List = {0,1,4};
    public int number1 = 0;
    public int number2 = 0;
    public Pokemon pokemon1;
    public Pokemon pokemon2;
    public int currentPlayer = 1;

    public void Appear1()
    {
        Set1();
        ac.GetComponent<AppearController>().Set(Translate(player1List[number1], 1), true);
        ac.GetComponent<AppearAnimation>().Set(Translate(player1List[number1], 1));
        bp.GetComponent<BloodPrefab>().hpLeft = pokemon1.hp;
        bp.GetComponent<BloodPrefab>().newBloodRollLeft = true;
    }

    public void Appear2()
    {
        Set2();
        ac.GetComponent<AppearController>().Set(Translate(player2List[number2], 2), true);
        ac.GetComponent<AppearAnimation>().Set(Translate(player2List[number2], 2));
        bp.GetComponent<BloodPrefab>().hpRight = pokemon2.hp;
        bp.GetComponent<BloodPrefab>().newBloodRollRight = true;
    }

    public void Disappear1()
    {
        ac.GetComponent<AppearController>().Set(Translate(player1List[number1],1),false);
        number1 ++;
        Debug.Log(number1);
        if (number1 >= 3)
        {
            lose();
            enabled = false;
        }
        else
        {
            Appear1();
        }
    }

    public void Disappear2()
    {
        ac.GetComponent<AppearController>().Set(Translate(player2List[number2],2),false);
        number2 ++;
        Debug.Log(number2);
        if (number2 >= 3)
        {
            win();
            enabled = false;
        }
        else
        {
            Appear2();
        }
    }

    public void Hit()
    {
        System.Random rd1 = new System.Random();
        bool isdie = false;
        if (currentPlayer == 1)
        {
            int elude1 = rd1.Next(0, 10 - pokemon2.speed);
            bool ismiss = elude1 == 0 ? true : false;
            if (ismiss)
            {
                Debug.Log("左边使用了技能1，右边成功躲避\n");
                //调用小兄弟，传入扣血值0
            }
            else
            {
                pokemon2.hp = pokemon2.hp - pokemon1.attack + pokemon2.defense;
                Debug.Log("左边使用了技能1\n");
                isdie = pokemon2.hp <= 0 ? true : false;
                GameObject right = GameObject.Find("EnBlood(Clone)");
                right.GetComponent<EnBloodBar>().damage = (pokemon1.attack - pokemon2.defense);
                //调用小兄弟，传入扣血值(recordBattle.attackLeft - recordBattle.defenseRight)
            }
            ac.GetComponent<HitAnimation>().Set(Translate(pokemon1.type,1),Translate(pokemon2.type,2),true,ismiss,isdie);
            ac.GetComponent<HitAnimation>().enabled = true;
            currentPlayer = 2;
        }
        else
        {
            int elude1 = rd1.Next(0, 10 - pokemon1.speed);
            bool ismiss = elude1 == 0 ? true : false;
            if (ismiss)
            {
                Debug.Log("右边使用了技能1，左边成功躲避\n");
                //调用小兄弟，传入扣血值0
            }
            else
            {
                pokemon1.hp = pokemon1.hp - pokemon2.attack + pokemon1.defense;
                Debug.Log("右边使用了技能1\n");
                GameObject left = GameObject.Find("MyBlood(Clone)");
                left.GetComponent<MyBloodBar>().damage = (pokemon2.attack - pokemon1.defense);
                isdie = pokemon1.hp <= 0 ? true : false;
                //调用小兄弟，传入扣血值(recordBattle.attackLeft - recordBattle.defenseRight)
            }
            ac.GetComponent<HitAnimation>().Set(Translate(pokemon2.type,2),Translate(pokemon1.type,1),false,ismiss,isdie);
            ac.GetComponent<HitAnimation>().enabled = true;
            currentPlayer = 1;
        }
    }

    public void Special()
    {
        System.Random rd1 = new System.Random();
        bool isdie = false;
        if (currentPlayer == 1)
        {
            int elude1 = rd1.Next(0, 10 - pokemon2.speed);
            bool ismiss = elude1 == 0 ? true : false;
            if (ismiss)
            {
                Debug.Log("左边使用了技能2，右边成功躲避\n");
                //调用小兄弟，传入扣血值0
            }
            else
            {
                pokemon2.hp = pokemon2.hp - pokemon1.attack * 2 + pokemon2.defense;
                Debug.Log("左边使用了技能2\n");
                GameObject right = GameObject.Find("EnBlood(Clone)");
                right.GetComponent<EnBloodBar>().damage = (pokemon1.attack * 2 - pokemon2.defense);
                isdie = pokemon2.hp <= 0 ? true : false;
                //调用小兄弟，传入扣血值(recordBattle.attackLeft - recordBattle.defenseRight)
            }
            ac.GetComponent<SpecialAnimation>().Set(Translate(pokemon1.type,1),Translate(pokemon2.type,2),true,ismiss,isdie);
            ac.GetComponent<SpecialAnimation>().enabled = true;
            currentPlayer = 2;
        }
        else
        {
            int elude1 = rd1.Next(0, 10 - pokemon1.speed);
            bool ismiss = elude1 == 0 ? true : false;
            if (ismiss)
            {
                Debug.Log("右边使用了技能2，左边成功躲避\n");
                //调用小兄弟，传入扣血值0
            }
            else
            {
                pokemon1.hp = pokemon1.hp - pokemon2.attack * 2 + pokemon1.defense;
                Debug.Log("右边使用了技能2\n");
                GameObject left = GameObject.Find("MyBlood(Clone)");
                left.GetComponent<MyBloodBar>().damage = (pokemon2.attack * 2 - pokemon1.defense);
                isdie = pokemon1.hp <= 0 ? true : false;
                //调用小兄弟，传入扣血值(recordBattle.attackLeft - recordBattle.defenseRight)
            }
            ac.GetComponent<SpecialAnimation>().Set(Translate(pokemon2.type,2),Translate(pokemon1.type,1),false,ismiss,isdie);
            ac.GetComponent<SpecialAnimation>().enabled = true;
            currentPlayer = 1;
        }
    }

    public void Buff()
    {
        if (currentPlayer == 1)
        {
            pokemon1.attack++;
            pokemon1.defense++;
            if (pokemon1.speed < 9)
            {
                pokemon1.speed++;
            }

            ac.GetComponent<BuffAnimation>().Set(Translate(pokemon1.type,1));
            ac.GetComponent<BuffAnimation>().enabled = true;
            currentPlayer = 2;
        }
        else
        {
            pokemon2.attack++;
            pokemon2.defense++;
            if (pokemon2.speed < 9)
            {
                pokemon2.speed++;
            }
            ac.GetComponent<BuffAnimation>().Set(Translate(pokemon2.type,2));
            ac.GetComponent<BuffAnimation>().enabled = true;
            currentPlayer = 1;
        }
    }

    public void Debuff()
    {
        if (currentPlayer == 1)
        {
            if (pokemon2.attack > 1)
            {
                pokemon2.attack--;
            }

            if (pokemon2.defense > 0)
            {
                pokemon2.defense--;
            }

            if (pokemon2.speed > 1)
            {
                pokemon2.speed--;
            }

            ac.GetComponent<DebuffAnimation>().Set(Translate(pokemon1.type,1));
            ac.GetComponent<DebuffAnimation>().enabled = true;
            currentPlayer = 2;
        }
        else
        {
            if (pokemon1.attack > 1)
            {
                pokemon1.attack--;
            }

            if (pokemon1.defense > 0)
            {
                pokemon1.defense--;
            }

            if (pokemon1.speed > 1)
            {
                pokemon1.speed--;
            }

            ac.GetComponent<DebuffAnimation>().Set(Translate(pokemon2.type,2));
            ac.GetComponent<DebuffAnimation>().enabled = true;
            currentPlayer = 1;
        }
    }

    public void lose()
    {
        Debug.Log("右边赢了，游戏结束");
        SceneManager.LoadScene(4);
    }
    public void win()
    {
        Debug.Log("左边赢了，游戏结束");
        SceneManager.LoadScene(3);
    }

    public void Set1()
    {
        pokemon1 = new Pokemon(player1List[number1], blood[player1List[number1]], attack[player1List[number1]],defense[player1List[number1]], speed[player1List[number1]]);
    }
    
    public void Set2()
    {
        pokemon2 = new Pokemon(player2List[number2], blood[player2List[number2]], attack[player2List[number2]],defense[player2List[number2]], speed[player2List[number2]]);
    }

    public string Translate(int input, int number)
    {
        switch (input)
        {
            case 0:
                return "seed" + number;
            case 1:
                return "dragon" + number;
            case 2:
                return "turtle" + number;
            case 3:
                return "bird" + number;
            case 4:
                return "mouse" + number;
            case 5:
                return "mud" + number;
            default:
                return "seed" + number;
        }
    }

    public void Read()
    {
        int count = 0;
        string line = "";
        using (StreamReader sr = new StreamReader("names.txt"))
        {
            while ((line = sr.ReadLine()) != null)
            {
                if (count < 3)
                {
                    player1List[count] = int.Parse(line);
                    count++;
                }
                else
                {
                    player2List[count - 3] = int.Parse(line);
                    count++;
                }
            }
        }
    }
}