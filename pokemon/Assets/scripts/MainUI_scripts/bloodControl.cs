using UnityEngine;

public class bloodControl
{
    private static GameObject canvas = GameObject.Find("Canvas");
    

    public static void damageLeft(int value)
    {
        canvas.GetComponent<BloodPrefab>().damageLeft(value);
    }

    public static void damageRight(int value)
    {
        canvas.GetComponent<BloodPrefab>().damageRight(value);
    }

    public static void newLeftBloodRoll(int hpTotal)
    {
        canvas.GetComponent<BloodPrefab>().newBloodRollLeft = true;
        canvas.GetComponent<BloodPrefab>().hpLeft = hpTotal;
    }

    public static void newRightBloodRoll(int hpTotal)
    {
        canvas.GetComponent<BloodPrefab>().newBloodRollRight = true;
        canvas.GetComponent<BloodPrefab>().hpRight = hpTotal;
    }
}