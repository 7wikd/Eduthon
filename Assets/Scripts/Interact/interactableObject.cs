using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableObject : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite unsetSprite;
    public Sprite setSprite;
    private bool playerInRange;
    public bool state=false;
    void Update()
    {
	if (Input.GetKeyDown(KeyCode.Space)&& playerInRange){
 		state = !state;
        }
        
        if(state == true){
        	this.GetComponent<SpriteRenderer>().sprite = setSprite;
        	}
        else if(state == false){
        	this.GetComponent<SpriteRenderer>().sprite = unsetSprite;
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
