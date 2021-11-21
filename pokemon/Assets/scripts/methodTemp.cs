using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Random;
using Random = System.Random;

public class methodTemp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void updateLeft(int choice)
    {
        //0 妙蛙种子 1 小火龙  2杰尼龟  3 比比鸟  4 皮卡丘  5 臭臭泥
        switch (choice)
        {
            case 0:
                recordBattle.attackLeft = recordProperty.attackBulbasaur;
                recordBattle.defenseLeft = recordProperty.defenseBulbasaur;
                recordBattle.speedLeft = recordProperty.speedBulbasaur;
                recordBattle.bloodLeft = recordProperty.bloodBulbasaur;
                break;
            case 1:
                recordBattle.attackLeft = recordProperty.attackCharmander;
                recordBattle.defenseLeft = recordProperty.defenseCharmander;
                recordBattle.speedLeft = recordProperty.speedCharmander;
                recordBattle.bloodLeft = recordProperty.bloodCharmander;
                break;
            case 2:
                recordBattle.attackLeft = recordProperty.attackSquirtle;
                recordBattle.defenseLeft = recordProperty.defenseSquirtle;
                recordBattle.speedLeft = recordProperty.speedSquirtle;
                recordBattle.bloodLeft = recordProperty.bloodSquirtle;
                break;

            case 3:
                recordBattle.attackLeft = recordProperty.attackPidgeotto;
                recordBattle.defenseLeft = recordProperty.defensePidgeotto;
                recordBattle.speedLeft = recordProperty.speedPidgeotto;
                recordBattle.bloodLeft = recordProperty.bloodPidgeotto;
                break;

            case 4:
                recordBattle.attackLeft = recordProperty.attackPikachu;
                recordBattle.defenseLeft = recordProperty.defensePikachu;
                recordBattle.speedLeft = recordProperty.speedPikachu;
                recordBattle.bloodLeft = recordProperty.bloodPikachu;
                break;


            case 5:
                recordBattle.attackLeft = recordProperty.attackMuk;
                recordBattle.defenseLeft = recordProperty.defenseMuk;
                recordBattle.speedLeft = recordProperty.speedMuk;
                recordBattle.bloodLeft = recordProperty.bloodMuk;
                break;
        }
    }

    public static void updateRight(int choice)
    {
        //0 妙蛙种子 1 小火龙  2杰尼龟  3 比比鸟  4 皮卡丘  5 臭臭泥
        switch (choice)
        {
            case 0:
                recordBattle.attackRight = recordProperty.attackBulbasaur;
                recordBattle.defenseRight = recordProperty.defenseBulbasaur;
                recordBattle.speedRight = recordProperty.speedBulbasaur;
                recordBattle.bloodRight = recordProperty.bloodBulbasaur;
                break;
            case 1:
                recordBattle.attackRight = recordProperty.attackCharmander;
                recordBattle.defenseRight = recordProperty.defenseCharmander;
                recordBattle.speedRight = recordProperty.speedCharmander;
                recordBattle.bloodRight = recordProperty.bloodCharmander;
                break;
            case 2:
                recordBattle.attackRight = recordProperty.attackSquirtle;
                recordBattle.defenseRight = recordProperty.defenseSquirtle;
                recordBattle.speedRight = recordProperty.speedSquirtle;
                recordBattle.bloodRight = recordProperty.bloodSquirtle;
                break;

            case 3:
                recordBattle.attackRight = recordProperty.attackPidgeotto;
                recordBattle.defenseRight = recordProperty.defensePidgeotto;
                recordBattle.speedRight = recordProperty.speedPidgeotto;
                recordBattle.bloodRight = recordProperty.bloodPidgeotto;
                break;

            case 4:
                recordBattle.attackRight = recordProperty.attackPikachu;
                recordBattle.defenseRight = recordProperty.defensePikachu;
                recordBattle.speedRight = recordProperty.speedPikachu;
                recordBattle.bloodRight = recordProperty.bloodPikachu;
                break;


            case 5:
                recordBattle.attackRight = recordProperty.attackMuk;
                recordBattle.defenseRight = recordProperty.defenseMuk;
                recordBattle.speedRight = recordProperty.speedMuk;
                recordBattle.bloodRight = recordProperty.bloodMuk;
                break;
        }
    }

    public static int[] realTimeLeft(int choice) //这个代表右边精灵攻击
    {
        int[] return_arr = new int[2];
        //0,1,2,3分别代表从左到右四个技能
        switch (choice)
        {
            case 0:
                Random rd1 = new Random();
                int elude1 = rd1.Next(0, 10 - recordBattle.speedLeft);
                if (elude1 == 0)
                {
                    return_arr[0] = recordBattle.bloodLeft;
                    return_arr[1] = 1;
                    return return_arr;
                }
                else
                {
                    recordBattle.bloodLeft =
                        recordBattle.bloodLeft - recordBattle.attackRight + recordBattle.defenseLeft;
                    return_arr[0] = recordBattle.bloodLeft;
                    return_arr[1] = 0;
                    return return_arr;
                }

                break;
            case 1:
                Random rd2 = new Random();
                int elude2 = rd2.Next(0, 10 - recordBattle.speedLeft);
                if (elude2 == 0)
                {
                    return_arr[0] = recordBattle.bloodLeft;
                    return_arr[1] = 1;
                    return return_arr;
                }
                else
                {
                    recordBattle.bloodLeft =
                        recordBattle.bloodLeft - recordBattle.attackRight * 2 + recordBattle.defenseLeft;
                    return_arr[0] = recordBattle.bloodLeft;
                    return_arr[1] = 0;
                    return return_arr;
                }

                break;
            case 2:
                recordBattle.attackRight++;
                recordBattle.defenseRight++;
                recordBattle.speedRight++;
                return_arr[0] = recordBattle.bloodLeft;
                return_arr[1] = 0;
                break;
            case 3:
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

                return_arr[0] = recordBattle.bloodLeft;
                return_arr[1] = 0;
                break;
        }

        return return_arr;
    }

    public static int[] realTimeRight(int choice) //这个代表左边精灵攻击
    {
        int[] return_arr = new int[2];
        //0,1,2,3分别代表从左到右四个技能
        switch (choice)
        {
            case 0:
                Random rd1 = new Random();
                int elude1 = rd1.Next(0, 10 - recordBattle.speedRight);
                if (elude1 == 0)
                {
                    return_arr[0] = recordBattle.bloodRight;
                    return_arr[1] = 1;
                    return return_arr;
                }
                else
                {
                    recordBattle.bloodRight =
                        recordBattle.bloodRight - recordBattle.attackLeft + recordBattle.defenseRight;
                    return_arr[0] = recordBattle.bloodRight;
                    return_arr[1] = 0;
                    return return_arr;
                }

                break;
            case 1:
                Random rd2 = new Random();
                int elude2 = rd2.Next(0, 10 - recordBattle.speedRight);
                if (elude2 == 0)
                {
                    return_arr[0] = recordBattle.bloodRight;
                    return_arr[1] = 1;
                    return return_arr;
                }
                else
                {
                    recordBattle.bloodRight = recordBattle.bloodRight - recordBattle.attackLeft * 2 +
                                              recordBattle.defenseRight;
                    return_arr[0] = recordBattle.bloodRight;
                    return_arr[1] = 0;
                    return return_arr;
                }

                break;
            case 2:
                recordBattle.attackLeft++;
                recordBattle.defenseLeft++;
                recordBattle.speedLeft++;
                return_arr[0] = recordBattle.bloodRight;
                return_arr[1] = 0;
                break;
            case 3:
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

                return_arr[0] = recordBattle.bloodRight;
                return_arr[1] = 0;
                break;
        }

        return return_arr;
    }
}