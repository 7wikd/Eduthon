using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    private void Start()
    {
        // Vector3 pos = inventory.slots[0].transform;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        // itemButton.transform = inventory.slots[0].transform;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            for(int i=0; i<inventory.slots.Length; i++)
            {
                if(inventory.isFull[i]==false) {
                    inventory.isFull[i] = true; 
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
