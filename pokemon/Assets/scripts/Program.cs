using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Program : MonoBehaviour
{
    // public int[] a = GameObject.Find("Content").SendMessage("getSelectedPokemons");
    //
    public static int[] a = ChoosePokemon.selectedPokemons;
    //private static GameObject ac;
    public static void dataControl(int[] a)
    {
        
        elfChoose(a);//在最开始输入使用的精灵
        recordBattle.nowLeft = recordBattle.elf[0];//初始化左边出战的第一个精灵
        recordBattle.nowRight = recordBattle.elf[3];//初始化右边出战的第一个精灵
        Debug.Log(Translate(recordBattle.elf[0],1));
        //
        // ac.GetComponent<AppearController>().Set("bird1",true);
        // ac.GetComponent<AppearAnimation>().Set("bird1");
        // ac.GetComponent<AppearAnimation>().enabled = true;
        // ac.GetComponent<AppearController>().Set(Translate(recordBattle.elf[3],2),true);
        // ac.GetComponent<AppearAnimation>().Set(Translate(recordBattle.elf[3],2));
        // ac.GetComponent<AppearAnimation>().enabled = true;
        iniPropertyLeft();
        iniPropertyRight();
        engine();
    }

    public static void testappear()
    {
        //GameObject.Find("AnimatorController").SendMessage("Set","bird1");
        GameObject go = GameObject.Find("AnimatorController");
        go.GetComponent<AppearController>().Set("bird1",true);
    }

    public static void iniPropertyLeft()
    {
        recordBattle.attackLeft = recordProperty.attack[recordBattle.nowLeft];
        recordBattle.bloodLeft = recordProperty.blood[recordBattle.nowLeft];
        recordBattle.defenseLeft = recordProperty.defense[recordBattle.nowLeft];
        recordBattle.speedLeft = recordProperty.speed[recordBattle.nowLeft];
    }
    
    public static void iniPropertyRight()
    {
        recordBattle.attackRight = recordProperty.attack[recordBattle.nowRight];
        recordBattle.bloodRight = recordProperty.blood[recordBattle.nowRight];
        recordBattle.defenseRight = recordProperty.defense[recordBattle.nowRight];
        recordBattle.speedRight = recordProperty.speed[recordBattle.nowRight];
    }
    public static void elfChoose(int[] choice)//这个是放入精灵的方法，choice的size是6，前三个是左边的精灵，后三个是右边的精灵，按照顺序塞入
                                                //0 妙蛙种子 1 小火龙  2杰尼龟  3 比比鸟  4 皮卡丘  5 臭臭泥
    {
        for (int i = 0; i < choice.Length; i++)
        {
            recordBattle.elf[i] = choice[i];
        }
    }

    public static void button0()
    {
        
        System.Random rd1 = new System.Random();
        int elude1 = rd1.Next(0, 10 - recordBattle.speedRight);
        if (elude1 == 0)
        {
            Debug.Log("左边使用了技能1，右边成功躲避\n");
            //调用小兄弟，传入扣血值0
            //调用刘仝技能0传入精灵参数，调用刘仝闪避传入精灵参数
        }
        else
        {
            recordBattle.bloodRight =
                recordBattle.bloodRight - recordBattle.attackLeft + recordBattle.defenseRight;
            Debug.Log("左边使用了技能1\n");
            //调用小兄弟，传入扣血值(recordBattle.attackLeft - recordBattle.defenseRight)
            //调用刘仝技能0传入精灵参数，调用刘仝闪避传入精灵参数
        }
    }

    public static void button1()
    {
        System.Random rd2 = new System.Random();
        int elude2 = rd2.Next(0, 10 - recordBattle.speedRight);
        if (elude2 == 0)
        {
            Debug.Log("左边使用了技能2，右边成功躲避\n");
            //调用小兄弟，传入扣血值0
            //调用刘仝技能1传入精灵参数，调用刘仝闪避传入精灵参数
        }
        else
        {
            recordBattle.bloodRight = recordBattle.bloodRight - recordBattle.attackLeft * 2 + recordBattle.defenseRight;
            Debug.Log("左边使用了技能2\n");
            //调用小兄弟，传入扣血值(recordBattle.attackLeft * 2 - recordBattle.defenseRight)
            //调用刘仝技能1传入精灵参数
        }
    }

    public static void button2()
    {
        recordBattle.attackLeft++;
        recordBattle.defenseLeft++;
        if (recordBattle.speedLeft < 9)
        {
            recordBattle.speedLeft++;
        }

        Debug.Log("左边使用了技能3\n");
        //调用小兄弟吗在这里？
        //调用刘仝技能2
    }

    public static void button3()
    {
        if (recordBattle.attackRight > 1)
        {
            recordBattle.attackRight--;
        }

        if (recordBattle.speedRight > 0)
        {
            recordBattle.speedRight--;
        }

        if (recordBattle.defenseRight > 0)
        {
            recordBattle.defenseRight--;
        }
        //调用小兄弟吗在这里？
        //调用刘仝技能3
        Debug.Log("左边使用了技能4\n");
    }
    public static void button4()
    {
        System.Random rd1 = new System.Random();
        int elude1 = rd1.Next(0, 10 - recordBattle.speedLeft);
        if (elude1 == 0)
        {
            Debug.Log("右边使用了技能1，左边成功躲避\n");
            //调用小兄弟，传入扣血值0
            //调用刘仝技能4传入精灵参数，调用刘仝闪避传入精灵参数
        }
        else
        {
            recordBattle.bloodLeft =
                recordBattle.bloodLeft - recordBattle.attackRight + recordBattle.defenseLeft;
            Debug.Log("右边使用了技能1\n");
            //调用小兄弟，传入扣血值(recordBattle.attackRight - recordBattle.defenseLeft)
            //调用刘仝技能4传入精灵参数
        }
    }

    public static void button5()
    {
        System.Random rd2 = new System.Random();
        int elude2 = rd2.Next(0, 10 - recordBattle.speedLeft);
        if (elude2 == 0)
        {
            Debug.Log("右边使用了技能2，左边成功躲避\n");
            //调用小兄弟，传入扣血值0
            //调用刘仝技能5传入精灵参数，调用刘仝闪避传入精灵参数
        }
        else
        {
            recordBattle.bloodLeft =
                recordBattle.bloodLeft - recordBattle.attackRight * 2 + recordBattle.defenseLeft;
            Debug.Log("右边使用了技能2\n");
            //调用小兄弟，传入扣血值(recordBattle.attackRight * 2 - recordBattle.defenseLeft)
            //调用刘仝技能5传入精灵参数
        }
    }

    public static void button6()
    {
        recordBattle.attackRight++;
        recordBattle.defenseRight++;
        if (recordBattle.speedRight<9)
        {
            recordBattle.speedRight++;
        }
        
        Debug.Log("右边使用了技能3\n");
        //调用小兄弟吗在这里？
        //调用刘仝技能6
    }

    public static void button7()
    {
        if (recordBattle.attackLeft > 1)
        {
            recordBattle.attackLeft--;
        }

        if (recordBattle.speedLeft > 0)
        {
            recordBattle.speedLeft--;
        }

        if (recordBattle.defenseLeft > 0)
        {
            recordBattle.defenseLeft--;
        }
        //调用小兄弟吗在这里？
        //调用刘仝技能7
        Debug.Log("右边使用了技能4\n");
    }
    public static void engine()
    {
        Debug.Log("左边在场精灵："+recordBattle.nowLeft);
        Debug.Log("右边在场精灵："+recordBattle.nowRight+"\n");
        Debug.Log("左边精灵血量"+recordBattle.bloodLeft);
        Debug.Log("右边精灵血量"+recordBattle.bloodRight+"\n");
        Debug.Log("左边精灵速度"+recordBattle.speedLeft);
        Debug.Log("右边精灵速度"+recordBattle.speedRight+"\n");
        Debug.Log("左边精灵防御"+recordBattle.defenseLeft);
        Debug.Log("右边精灵防御"+recordBattle.defenseRight+"\n");
        Debug.Log("左边精灵攻击力"+recordBattle.attackLeft);
        Debug.Log("右边精灵攻击力"+recordBattle.attackRight+"\n");

        if (recordBattle.bloodLeft <= 0)
        {
            for (int i = 0; i < 3; i++)
            {
                if (recordBattle.elfLive[i])
                {
                    recordBattle.elfLive[i] = false;

                    if (i != 2)
                    {
                        Debug.Log("左边精灵死了，换精灵\n");
                        recordBattle.nowLeft = recordBattle.elf[i + 1];
                        iniPropertyLeft();
                        break;
                    }
                    else
                    {
                        Debug.Log("右边赢了，游戏结束");
                        SceneManager.LoadScene(4);
                        //System.Environment.Exit(0);
                    }
                }
            }
        }
        if (recordBattle.bloodRight <= 0)
        {
            for (int i = 3; i < 6; i++)
            {
                if (recordBattle.elfLive[i])
                {
                    recordBattle.elfLive[i] = false;

                    if (i != 5)
                    {   
                        Debug.Log("右边精灵死了，换精灵\n");
                        recordBattle.nowRight = recordBattle.elf[i + 1];
                        iniPropertyRight();
                        break;
                    }
                    else
                    {
                        Debug.Log("左边赢了，游戏结束");
                        SceneManager.LoadScene(3);
                        //System.Environment.Exit(0);
                    }
                }
            }
        }
        // break;
    }

    public static string Translate(int input, int number)
    {
        switch (input)
        {
            case 0:
                return "seed" + number;
                break;
            case 1:
                return "dragon" + number;
                break;
            case 2:
                return "turtle" + number;
                break;
            case 3:
                return "bird" + number;
                break;
            case 4:
                return "mouse" + number;
                break;
            case 5:
                return "mud" + number;
                break;
            default:
                return "seed" + number;
                break;
        }
    }
}
