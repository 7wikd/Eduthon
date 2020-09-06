using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateGate : MonoBehaviour
{
    private bool playerInRange;
    public Sprite doorOpen;
    public Sprite doorClose;
    private bool t1;
    private bool t2;

    // Update is called once per frame
    void Update()
    {
    		t1 = GameObject.Find("tile1").GetComponent<interactableObject>().state;
                t2 = GameObject.Find("tile2").GetComponent<interactableObject>().state;
        	if(t1==true && t2==false && playerInRange){
 			GameObject.Find("TrapDoor1").GetComponent<SpriteRenderer>().sprite = doorOpen;
 			GameObject.Find("TrapDoor2").GetComponent<SpriteRenderer>().sprite = doorOpen;
 		}
 	
    }
    
    private void OnTriggerEnter2D(Collider2D box){
        if(box.CompareTag("Player")){

            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D box){
        if(box.CompareTag("Player")){

            playerInRange = false;
        }
    }
}
