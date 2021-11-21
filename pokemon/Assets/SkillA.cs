using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillA : MonoBehaviour
{
    public GameObject gameObject;
    public void skill()
    {
        gameObject.GetComponent<LARH>().set("dragon","mouse",true);
        gameObject.GetComponent<LARH>().enabled = true;
    }
}
