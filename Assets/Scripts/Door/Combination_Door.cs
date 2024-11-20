using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combination_Door : Doors
{
    [SerializeField] private List<Lock> locksRequired = new List<Lock>();
    [SerializeField] private int unlockedLocks;
    
    public override void Activation()
    {
        if (locksRequired.Count <= 0)
            return;
        
        foreach (Lock comboLock in locksRequired)
        {
            comboLock.GetComponent<Lock>();

            if (comboLock.isUnlocked)
                unlockedLocks++;
        }
        
        if (unlockedLocks < locksRequired.Count)
        {
            unlockedLocks = 0;
            Debug.Log("Door is locked");
        }
        else
        {
            unlockedLocks = locksRequired.Count;
            Debug.Log("Door is opened!");
            Destroy(gameObject);
        }
    }
}
