using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Lock : MonoBehaviour
{
    [SerializeField] private int[] currentCode;
    [SerializeField] private int[] unlockCode;

    // Start is called before the first frame update
    private void Start()
    {
        RotateLock.Rotated += CheckResults;
    }

    private void CheckResults(string wheelName, int number)
    {
        switch (wheelName)
        {
            case "Lock 1":
                currentCode[0] = number;
                break;
            
            case "Lock 2":
                currentCode[1] = number;
                break;
            
            case "Lock 3":
                currentCode[2] = number;
                break;
            
            case "Lock 4":
                currentCode[3] = number;
                break;
        }

        // foreach (var wheel in wheelName)
        // {
        //     currentCode[number] = number;
        // }

        if (currentCode[0] == unlockCode[0] && currentCode[1] == unlockCode[1] && currentCode[2] == unlockCode[2] && currentCode[3] == unlockCode[3])
            Debug.Log("Door is unlocked!");
    }

    private void OnDestroy()
    {
        RotateLock.Rotated -= CheckResults;
    }
}
