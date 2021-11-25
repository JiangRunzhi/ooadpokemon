using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SignIn : MonoBehaviour
{
    public GameObject userInputText;
    public GameObject passwordInputText;

    public void onSignInClick()
    {
        //胜场 胜率 金币
        int[] info = mid(userInputText.GetComponent<Text>().text, passwordInputText.GetComponent<Text>().text);
        if (info[0] != -1)
        {
            Debug.Log("登陆成功");
            using (StreamWriter sw = new StreamWriter("currentPlayer.txt"))
            {
                sw.WriteLine(userInputText.GetComponent<Text>().text);
                //sw.WriteLine();
            }
            SceneManager.LoadScene(14);
        }
        else
        {
            Debug.Log("登陆失败");
        }
    }

    static int[] mid(string username, string password)
    {
        if (log_in(username,password))
        {
            Debug.Log("true");
            return load_user(username);
        }
        else
        {
            Debug.Log("false");
            int[] a = {-1, -1,-1};
            return a;
        }
    }
    static int[] load_user(string username)
    {
        int[] r = new int[3];
        using (StreamReader sr = new StreamReader(username+".txt"))
        {
            string line;
            int count = 0;
            
            while ((line = sr.ReadLine()) != null)
            {
                r[count] = int.Parse(line);
                // Debug.log(r[count]);
                count++;
                if (count == 3)
                {
                    break;
                }
            }
        }

        return r;
    }
    static bool log_in(string username, string password)
    {
        int count = 0;
        try
        {
            using (StreamReader sr = new StreamReader("test.txt"))
            {
                string line;
                bool setting=false;
                while ((line = sr.ReadLine()) != null)
                {
                    if (count%2==0&&line.Equals(username))
                    {
                        setting = true;
                    }

                    if (setting&&count%2!=0&&line.Equals(password))
                    {
                        return true;
                    }
                    if (setting && count % 2 != 0 && !line.Equals(password))
                    {
                        return false;
                    }
                    count++;
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log("The file could not be read:");
            Debug.Log(e.Message);
            return false;
        }
        return false;
    }
}
