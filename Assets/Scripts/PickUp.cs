using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    private SpriteRenderer renderer;
    private Sprite sprite;
    Image im;

    private void Start()
    {
        // Vector3 pos = inventory.slots[0].transform;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        im = itemButton.GetComponent<Image>(); 
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            for(int i=0; i<inventory.slots.Length; i++)
            {
                if(inventory.isFull[i]==false) {
                    inventory.isFull[i] = true; 
                    SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>(); 
                    im.sprite = sr.sprite;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}