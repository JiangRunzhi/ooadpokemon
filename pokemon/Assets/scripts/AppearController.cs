using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearController : MonoBehaviour
{
    public GameObject bird1;
    public GameObject turtle1;
    public GameObject seed1;
    public GameObject dragon1;
    public GameObject mouse1;
    public GameObject mud1;
    public GameObject bird2;
    public GameObject turtle2;
    public GameObject seed2;
    public GameObject dragon2;
    public GameObject mouse2;
    public GameObject mud2;
    
    

    public void Set(string objectName, bool status)
    {
        if (objectName.Equals("bird1"))
        {
            bird1.SetActive(status);
        }

        if (objectName.Equals("turtle1"))
        {
            turtle1.SetActive(status);
        }
        
        if (objectName.Equals("seed1"))
        {
            seed1.SetActive(status);
        }
        
        if (objectName.Equals("dragon1"))
        {
            dragon1.SetActive(status);
        }
        
        if (objectName.Equals("mouse1"))
        {
            mouse1.SetActive(status);
        }
        
        if (objectName.Equals("mud1"))
        {
            mud1.SetActive(status);
        }
        
        if (objectName.Equals("bird2"))
        {
            bird2.SetActive(status);
        }

        if (objectName.Equals("turtle2"))
        {
            turtle2.SetActive(status);
        }
        
        if (objectName.Equals("seed2"))
        {
            seed2.SetActive(status);
        }
        
        if (objectName.Equals("dragon2"))
        {
            dragon2.SetActive(status);
        }
        
        if (objectName.Equals("mouse2"))
        {
            mouse2.SetActive(status);
        }
        
        if (objectName.Equals("mud2"))
        {
            mud2.SetActive(status);
        }
    }


}