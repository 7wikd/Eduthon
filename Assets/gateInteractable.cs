using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateInteractable : MonoBehaviour
{
    private bool t1;
    private bool t2;
    private bool t3;
    private bool t4;
    private bool playerInRange;
    public Sprite doorOpen;
    public Sprite doorClose;

    // Update is called once per frame
    void Update()
    {
        t1 = GameObject.Find("tile1").GetComponent<interactableObject>().state;
        t2 = GameObject.Find("tile2").GetComponent<interactableObject>().state;
        t3 = GameObject.Find("tile3").GetComponent<interactableObject>().state;
        t4 = GameObject.Find("tile4").GetComponent<interactableObject>().state;



        if(t1==false && t2==false && t3==false && t4==true){
        	this.GetComponent<SpriteRenderer>().sprite = doorOpen;
        	if(Input.GetKeyDown(KeyCode.Space) && playerInRange){
 		GameObject.Find("Player").transform.position = GameObject.Find("teleport").transform.position;
 		GameObject.Find("teleport").GetComponent<SpriteRenderer>().sprite = doorOpen;
 		this.GetComponent<SpriteRenderer>().sprite = doorClose;
 		}
 	}
 	else{
 		this.GetComponent<SpriteRenderer>().sprite = doorClose;
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
