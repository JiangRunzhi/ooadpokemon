using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SignUp : MonoBehaviour
{
    public GameObject userInputText;
    public GameObject passwordInputText;
    public void n_writing()
    {
        bool flag = writing(userInputText.GetComponent<Text>().text, passwordInputText.GetComponent<Text>().text);
        if (flag)
        {
            Debug.Log("注册成功");
            SceneManager.LoadScene(13);
        }
        else
        {
            Debug.Log("注册失败");
        }
    }

    public bool writing(string username, string password)
    {
        if (judge(username))
        {
            using (StreamWriter sw1 = new StreamWriter(username+".txt"))
            {
                for (int i = 0; i < 3; i++)
                {
                    sw1.WriteLine(0);
                }
            }

            using (StreamWriter sw2=new StreamWriter("test.txt",true))
            {
                sw2.WriteLine(username);
                sw2.WriteLine(password);
            }

            return true;
        }

        return false;
    }

    public bool judge(string new_username)
    {
        using (StreamReader sr = new StreamReader("test.txt"))
        {
            string line;
            int count = 0;
            while ((line = sr.ReadLine()) != null)
            {
                if (count % 2 == 0 && line.Equals(new_username))
                {
                    return false;
                }
            }
        }

        return true;
    }

}
