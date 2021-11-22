using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleMethods : MonoBehaviour
{
    public GameObject animatorController;
    
    public void HitHurt()
    {
        animatorController.GetComponent<HitAnimation>().Set("dragon2","dragon1",false,false,true);
        animatorController.GetComponent<HitAnimation>().enabled = true;
    }

    public void Appear()
    {
        //animatorController.GetComponent<AppearController>().Set("bird1",true);
        animatorController.GetComponent<AppearAnimation>().Set("bird1");
        animatorController.GetComponent<AppearAnimation>().enabled = true;
    }
    
    public void Disappear()
    {
        //animatorController.GetComponent<AppearController>().Set("bird1",false);
    }
}