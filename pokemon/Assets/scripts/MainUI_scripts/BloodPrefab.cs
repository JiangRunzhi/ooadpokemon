using UnityEngine;

public class BloodPrefab : MonoBehaviour
{
    public GameObject myBloodPrefab;
    public GameObject enBloodPrefab;
    public bool newBloodRollLeft;
    public int hpLeft;
    public bool newBloodRollRight;
    public int hpRight;

    private GameObject myBlood;
    private GameObject enBlood;
    void Start()
    {
        //newBloodRoll = false;
    }

    void Update()
    {
        if (newBloodRollLeft)
        {
            NewObjectLeft();
            newBloodRollLeft = false;
        }

        if (newBloodRollRight)
        {
            NewObjectRight();
            newBloodRollRight = false;
        }
    }

    void NewObjectLeft()
    {
        myBlood = Instantiate(myBloodPrefab);
        myBlood.GetComponent<MyBloodBar>().hpHolder = hpLeft;
        myBlood.transform.SetParent(transform, false);
    }

    void NewObjectRight()
    {
        enBlood = Instantiate(enBloodPrefab);
        enBlood.GetComponent<EnBloodBar>().hpHolder = hpRight;
        enBlood.transform.SetParent(transform, false);
    }

    public void damageLeft(int value)
    {
        myBlood.GetComponent<MyBloodBar>().damage = value;
    }

    public void damageRight(int value)
    {
        enBlood.GetComponent<EnBloodBar>().damage = value;
    }
}