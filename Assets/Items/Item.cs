using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item : MonoBehaviour
{
    // itemName will be used for the itemmanager, case sensitive
    public string itemName;
    //[Range (0,3)] public int rarity;

    void Start() 
    {
        // ensures the item is a trigger
        GetComponent<Collider>().isTrigger = true;
    }
}
