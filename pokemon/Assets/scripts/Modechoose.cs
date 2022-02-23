using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Modechoose : MonoBehaviour
{

    public void onPPClick()
    {
        using (StreamWriter sw = new StreamWriter("currentPlayer.txt", true)) 
        {
            sw.WriteLine(0);
        }
        SceneManager.LoadScene(2);
    }
    
    public void onPCClick()
    {
        using (StreamWriter sw = new StreamWriter("currentPlayer.txt", true)) 
        {
            sw.WriteLine(1);
        }
        SceneManager.LoadScene(2);
    }
    
}
