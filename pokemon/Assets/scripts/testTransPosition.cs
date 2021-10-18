using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testTransPosition : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_animator)
        {
            Vector3 newPosition = transform.position;
            newPosition.x += _animator.GetFloat("runSpeed") * Time.deltaTime; 
            transform.position = newPosition;
        }
    }
}
