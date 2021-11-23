using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleMethods : MonoBehaviour
{
    public GameObject animatorController;
    public GameObject mainCamera;
    
    public void HitHurt()
    {
        animatorController.GetComponent<HitAnimation>().Set("seed1","turtle2",true,false,true);
        animatorController.GetComponent<HitAnimation>().enabled = true;
    }

    public void Appear()
    {
        animatorController.GetComponent<AppearController>().Set("bird1",true);
        mainCamera.GetComponent<CameraSwitch>().Set("bird1");
        mainCamera.GetComponent<CameraSwitch>().enabled = true;
        animatorController.GetComponent<AppearAnimation>().Set("bird1");
        animatorController.GetComponent<AppearAnimation>().enabled = true;
    }
    
    public void Disappear()
    {
        //animatorController.GetComponent<AppearController>().Set("bird1",false);
    }

    public void SpecialSkill()
    {
        animatorController.GetComponent<SpecialAnimation>().Set("seed1","seed2",true,false,false);
        animatorController.GetComponent<SpecialAnimation>().enabled = true;
    }

    public void ChangeCamera()
    {
    }
}