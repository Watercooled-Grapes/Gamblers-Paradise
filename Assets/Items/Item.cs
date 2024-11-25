using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item : MonoBehaviour
{
    public string itemName;
    [Range (0,3)] public int rarity;

    void Start() 
    {
        var collider = GetComponent<Collider>();
        collider.isTrigger = true;
    }
}
