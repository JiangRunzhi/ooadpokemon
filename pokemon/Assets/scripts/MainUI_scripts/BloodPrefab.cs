using UnityEngine;

public class BloodPrefab : MonoBehaviour
{
    public GameObject myBloodPrefab;
    public GameObject enBloodPrefab;
    public bool newBloodRoll;

    void Start()
    {
        //newBloodRoll = false;
    }

    void Update()
    {
        if (newBloodRoll)
        {
            NewObject();
            newBloodRoll = false;
        }
    }

    void NewObject()
    {
        GameObject myBlood = Instantiate(myBloodPrefab);
        GameObject enBlood = Instantiate(enBloodPrefab);
        myBlood.transform.SetParent(transform, false);
        enBlood.transform.SetParent(transform, false);
    }
}