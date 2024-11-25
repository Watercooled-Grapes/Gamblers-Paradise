using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
    public List<Item> items;

    void Start()
    {
        items = new List<Item>();
    }

    void Update()
    {

    }

    // “other” refers to the collider on the GameObject inside this trigger
    void OnTriggerEnter (Collider other)
    {   
        Debug.Log ("Item picked up");
        items.Add(other.gameObject.GetComponent<Item>());
        Destroy(other.gameObject.GetComponent<MeshRenderer>());
        Destroy(other);
        gameObject.GetComponent<FirstPersonController>().sprintSpeed += 1f;
    }
}
