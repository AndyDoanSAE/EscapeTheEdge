using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RotateLock : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };

    private bool coroutineAllowed;
    
    private int numberShown;
    
    // Start is called before the first frame update
    private void Start()
    {
        coroutineAllowed = true;
        numberShown = 5;
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        if (coroutineAllowed)
            StartCoroutine("RotateWheel");
    }

    private IEnumerator RotateWheel()
    {
        coroutineAllowed = false;

        for (int i = 0; i < 11; i++)
        {
            transform.Rotate(0f, 0f, -3f);
            yield return new WaitForSeconds(0.01f);
        }
        
        coroutineAllowed = true;
        
        numberShown++;
        
        if (numberShown > 9)
            numberShown = 0;

        Rotated(name, numberShown);
    }
}
