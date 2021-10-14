using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Threading;
public class motion : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cube1;
    public GameObject cube2;
    void Start()
    {
        Debug.Log("hello unity");
    }

    // Update is called once per frame
    void Update()
    {
        
        // if (Input.GetKey(KeyCode.W))
        // {
        //     cube1.transform.Translate(new Vector3(0, 0, 1) * 50 * Time.deltaTime);
        // }
        // if (Input.GetKey(KeyCode.S))
        // {
        //     cube1.transform.Translate(new Vector3(0, 0, 1) * -50 * Time.deltaTime);
        // }
        // if (Input.GetKey(KeyCode.A))
        // {
        //     cube1.transform.Rotate(new Vector3(0, 1, 0) * -50 * Time.deltaTime);
        // }
        // if (Input.GetKey(KeyCode.D))
        // {
        //     cube1.transform.Rotate(new Vector3(0, 1, 0) * 50 * Time.deltaTime);
        // }
        // if (Input.GetKey(KeyCode.UpArrow))
        // {
        //     cube2.transform.Translate(new Vector3(0, 0, 1) * 50 * Time.deltaTime);
        // }
        // if (Input.GetKey(KeyCode.DownArrow))
        // {
        //     cube2.transform.Translate(new Vector3(0, 0, 1) * -50 * Time.deltaTime);
        // }
        // if (Input.GetKey(KeyCode.LeftArrow))
        // {
        //     cube2.transform.Rotate(new Vector3(0, 1, 0) * -50 * Time.deltaTime);
        // }
        // if (Input.GetKey(KeyCode.RightArrow))
        // {
        //     cube2.transform.Rotate(new Vector3(0, 1, 0) * 50 * Time.deltaTime);
        // }
        if (Input.GetKey(KeyCode.W))
        {
            cube1.transform.Translate(new Vector3(0, 0, 1) * 1);
            Thread.Sleep(500);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            cube1.transform.Translate(new Vector3(0, 0, 1) * -1 );
            Thread.Sleep(500);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            cube1.transform.Rotate(new Vector3(0, 1, 0) * -1 );
            Thread.Sleep(500);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            cube1.transform.Rotate(new Vector3(0, 1, 0) * 1);
            Thread.Sleep(500);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            cube2.transform.Translate(new Vector3(0, 0, 1) * 1 );
            Thread.Sleep(500);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            cube2.transform.Translate(new Vector3(0, 0, 1) * -1 );
            Thread.Sleep(500);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            cube2.transform.Rotate(new Vector3(0, 1, 0) * -1 );
            Thread.Sleep(500);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            cube2.transform.Rotate(new Vector3(0, 1, 0) * 1 );
            Thread.Sleep(500);
        }
    }
}
