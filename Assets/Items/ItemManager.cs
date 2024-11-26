using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FishNet.Demo.AdditiveScenes;

public class ItemManager : MonoBehaviour
{
    public float baseAcceleration = 10f;
    public float baseWalkSpeed = 5f;
    public float baseSprintSpeed = 7f;
    public float baseJump = 5f;

    public Dictionary<string, int> items;
    private FirstPersonController playerStats;

    void Start()
    {
        //TODO: find a way to set FirstPersonController stats to base stats automatically
        items = new Dictionary<string, int>();
        playerStats = gameObject.GetComponent<FirstPersonController>();
    }

    void OnTriggerEnter (Collider other)
    {   
        // pick up item and add to dictionary
        string itemName = other.gameObject.GetComponent<Item>().itemName;
        Debug.Log ("Item picked up");
        if (items.ContainsKey(itemName)) {
            items[itemName] += 1;
        } else {
            items[itemName] = 1;
        }

        // define item mechanics here, use dictionary to determine stack size
        switch (itemName) {
            case "soda":
                playerStats.sprintSpeed = baseSprintSpeed + 2*items[itemName];
                break;
            default:
                Debug.Log("picking up an item that does not have an assigned type (or its a typo)");
                break;
        }

        // delete the item in world
        Destroy(other.gameObject);
    }
}
