using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataBase : MonoBehaviour
{
    //妙 火 杰 比 皮 臭
    //0  1  2 3  4 5
    //草 火 水 飞 电 毒

    //克制prior 前克制后“前后”
    public static HashSet<String> prior = new HashSet<String>();
    public bool prior_flag = true;
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

    public String[] skillA = {"撞击(普)", "抓(普)", "撞击(普)", "泼沙(普)", "撞击(普)", "拍打(普)"};
    public String[] skillB = {"剑之舞(草)", "火焰放射(火)", "水炮(水)", "翅膀拍击(飞)","十万伏特(电)","淤泥攻击(毒)" };
    public String[] skillC = {"愤怒(属)", "愤怒(属)", "祈雨(属)", "起风(属)", "发电(属)", "变硬(属)"};
    public String[] skillD = {"威吓(属)", "叫声(属)", "叫声(属)", "吹飞(属)", "撒娇(属)", "束缚(属)"};
    
    public int number1 = 0;
    public int number2 = 0;
    public Pokemon pokemon1;
    public Pokemon pokemon2;
    public int currentPlayer = 1;
    
    public GameObject A_label;
    public GameObject B_label;
    public GameObject C_label;
    public GameObject D_label;
    public GameObject A1_label;
    public GameObject B1_label;
    public GameObject C1_label;
    public GameObject D1_label;

    public GameObject CombatInfoLable;

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
                CombatInfoLable.GetComponent<Text>().text = Translate2(pokemon1.type)+"使用了技能"+A_label.GetComponent<Text>().text+"，"+Translate2(pokemon2.type)+"成功躲避";
                //调用小兄弟，传入扣血值0
            }
            else
            {
                int hurt_num = pokemon1.attack - pokemon2.defense;
                pokemon2.hp = pokemon2.hp - hurt_num;
                Debug.Log("左边使用了技能1\n");
                CombatInfoLable.GetComponent<Text>().text = Translate2(pokemon1.type)+"使用了技能"+A_label.GetComponent<Text>().text+"，"+Translate2(pokemon2.type)+"受到伤害";
                isdie = pokemon2.hp <= 0 ? true : false;
                GameObject right = GameObject.Find("EnBlood(Clone)");
                right.GetComponent<EnBloodBar>().damage = hurt_num;
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
                CombatInfoLable.GetComponent<Text>().text = Translate2(pokemon2.type)+"使用了技能"+A1_label.GetComponent<Text>().text+"，"+Translate2(pokemon1.type)+"成功躲避";
                //调用小兄弟，传入扣血值0
            }
            else
            {
                int hurt_num = pokemon2.attack - pokemon1.defense;
                pokemon1.hp = pokemon1.hp - hurt_num;
                Debug.Log("右边使用了技能1\n");
                CombatInfoLable.GetComponent<Text>().text = Translate2(pokemon2.type)+"使用了技能"+A1_label.GetComponent<Text>().text+"，"+Translate2(pokemon1.type)+"受到伤害";
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
        if (prior_flag)
        {
            prior.Add("10"); //火草
            prior.Add("30"); //飞草
            prior.Add("43"); //电飞
            prior.Add("21"); //水火
            prior.Add("02"); //草水
            prior.Add("42"); //电水
            prior_flag = false;
        }


        System.Random rd1 = new System.Random();
        bool isdie = false;
        if (currentPlayer == 1)
        {
            int elude1 = rd1.Next(0, 10 - pokemon2.speed);
            bool ismiss = elude1 == 0 ? true : false;
            if (ismiss)
            {
                Debug.Log("左边使用了技能2，右边成功躲避\n");
                CombatInfoLable.GetComponent<Text>().text = Translate2(pokemon1.type)+"使用了技能"+B_label.GetComponent<Text>().text+"，"+Translate2(pokemon2.type)+"成功躲避";
            }
            else
            {
                int hurt_num = 0;
                hurt_num = pokemon1.attack - pokemon2.defense;
                String prior_term = pokemon1.type+ "" + pokemon2.type;
                if (prior.Contains(prior_term))
                {
                    hurt_num *= 2;
                    Debug.Log("左边使用了技能2,效果拔群！\n");
                    CombatInfoLable.GetComponent<Text>().text = Translate2(pokemon1.type)+"使用了技能"+B_label.GetComponent<Text>().text+"，效果拔群！！！";
                }
                else
                {
                    Debug.Log("左边使用了技能2\n");
                    CombatInfoLable.GetComponent<Text>().text = Translate2(pokemon1.type)+"使用了技能"+B_label.GetComponent<Text>().text+"，"+Translate2(pokemon2.type)+"受到伤害";
                }
                pokemon2.hp = pokemon2.hp - hurt_num;
                GameObject right = GameObject.Find("EnBlood(Clone)");
                right.GetComponent<EnBloodBar>().damage = hurt_num;
                isdie = pokemon2.hp <= 0 ? true : false;
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
                CombatInfoLable.GetComponent<Text>().text = Translate2(pokemon2.type)+"使用了技能"+B1_label.GetComponent<Text>().text+"，"+Translate2(pokemon1.type)+"成功躲避";
            }
            else
            {
                int hurt_num = 0;
                hurt_num = pokemon2.attack - pokemon1.defense;
                String prior_term = pokemon2.type+ "" + pokemon1.type;
                if (prior.Contains(prior_term))
                {
                    hurt_num *= 2;
                    Debug.Log("右边使用了技能2,效果拔群！\n");
                    CombatInfoLable.GetComponent<Text>().text = Translate2(pokemon2.type)+"使用了技能"+B1_label.GetComponent<Text>().text+"，效果拔群！！！";
                }
                else
                {
                    Debug.Log("右边使用了技能2\n");
                    CombatInfoLable.GetComponent<Text>().text = Translate2(pokemon2.type)+"使用了技能"+B1_label.GetComponent<Text>().text+"，"+Translate2(pokemon1.type)+"受到伤害";
                }
                pokemon1.hp = pokemon1.hp - hurt_num;
                GameObject left = GameObject.Find("MyBlood(Clone)");
                left.GetComponent<MyBloodBar>().damage = hurt_num;
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
            CombatInfoLable.GetComponent<Text>().text = Translate2(pokemon1.type)+"使用了技能"+C_label.GetComponent<Text>().text+"自身属性增强了！！！";
            pokemon1.attack+=2;
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
            CombatInfoLable.GetComponent<Text>().text = Translate2(pokemon2.type)+"使用了技能"+C1_label.GetComponent<Text>().text+"自身属性增强了！！！";
            pokemon2.attack+=2;
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
            CombatInfoLable.GetComponent<Text>().text = Translate2(pokemon1.type)+"使用了技能"+D_label.GetComponent<Text>().text+"，"+Translate2(pokemon2.type)+"属性被削弱！！！";
            if (pokemon2.attack > 1)
            {
                pokemon2.attack-=2;
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
            CombatInfoLable.GetComponent<Text>().text = Translate2(pokemon2.type)+"使用了技能"+D1_label.GetComponent<Text>().text+"，"+Translate2(pokemon1.type)+"属性被削弱！！！";
            if (pokemon1.attack > 1)
            {
                pokemon1.attack-=2;
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
        CombatInfoLable.GetComponent<Text>().text = "右边的队伍取得了胜利！";
        SceneManager.LoadScene(4);
    }
    public void win()
    {
        Debug.Log("左边赢了，游戏结束");
        CombatInfoLable.GetComponent<Text>().text = "左边的队伍取得了胜利！";
        SceneManager.LoadScene(3);
    }

    public void Set1()
    {
        pokemon1 = new Pokemon(player1List[number1], blood[player1List[number1]], attack[player1List[number1]],defense[player1List[number1]], speed[player1List[number1]]);
        CombatInfoLable.GetComponent<Text>().text = "去吧，" + Translate2(pokemon1.type) + "！！！";
        A_label.GetComponent<Text>().text = skillA[player1List[number1]];
        B_label.GetComponent<Text>().text = skillB[player1List[number1]];
        C_label.GetComponent<Text>().text = skillC[player1List[number1]];
        D_label.GetComponent<Text>().text = skillD[player1List[number1]];
    }
    
    public void Set2()
    {
        pokemon2 = new Pokemon(player2List[number2], blood[player2List[number2]], attack[player2List[number2]],defense[player2List[number2]], speed[player2List[number2]]);
        CombatInfoLable.GetComponent<Text>().text = "去吧，" + Translate2(pokemon2.type) + "！！！";
        A1_label.GetComponent<Text>().text = skillA[player2List[number2]];
        B1_label.GetComponent<Text>().text = skillB[player2List[number2]];
        C1_label.GetComponent<Text>().text = skillC[player2List[number2]];
        D1_label.GetComponent<Text>().text = skillD[player2List[number2]];
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
    
    public string Translate2(int input)
    {
        switch (input)
        {
            case 0:
                return "妙蛙种子";
            case 1:
                return "小火龙";
            case 2:
                return "杰尼龟";
            case 3:
                return "比比鸟";
            case 4:
                return "皮卡丘";
            case 5:
                return "臭臭泥";
            default:
                return "妙蛙种子";
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