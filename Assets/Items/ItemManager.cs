using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FishNet.Demo.AdditiveScenes;

public class ItemManager : MonoBehaviour
{
    public PlayerBaseStats bs;
    public Dictionary<string, int> items;
    private FirstPersonController playerStats;

    void Start()
    {
        //TODO: find a way to set FirstPersonController stats to base stats automatically
        items = new Dictionary<string, int>();
        playerStats = gameObject.GetComponent<FirstPersonController>();

        playerStats.walkSpeed = bs.walkSpeed;
        playerStats.sprintSpeed = bs.sprintSpeed;
        playerStats.jumpPower = bs.jumpPower;
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
                playerStats.sprintSpeed = bs.sprintSpeed + 2*items[itemName];
                break;
            default:
                Debug.Log("picking up an item that does not have an assigned type (or its a typo)");
                break;
        }

        // delete the item in world
        Destroy(other.gameObject);
    }
}
