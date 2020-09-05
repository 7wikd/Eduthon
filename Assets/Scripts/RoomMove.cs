﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;
    public bool needText;
    public string placeName;
    public GameObject text;
    private bool t5;
    private bool t6;
    private bool t7;
    private bool t8;
    private bool change;
    public Text placeText;

    void Start(){
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update(){
        t5 = GameObject.Find("tile5").GetComponent<interactableObject>().state;
        t6 = GameObject.Find("tile6").GetComponent<interactableObject>().state;
        t7 = GameObject.Find("tile7").GetComponent<interactableObject>().state;
        t8 = GameObject.Find("tile8").GetComponent<interactableObject>().state;
           if(t5==false && t6==true && t7==true && t8==true){

           	this.GetComponent<Collider2D>().isTrigger = true;
           	Debug.Log("pass");
           	}
           else {
           	this.GetComponent<Collider2D>().isTrigger = false;
           }

    }

    private void OnTriggerEnter2D(Collider2D other){


        if(other.CompareTag("Player")){
 		
            	cam.minPosition += cameraChange;
            	cam.maxPosition += cameraChange;
            	other.transform.position += playerChange;
            	if(needText){
                StartCoroutine(placeNameCo());
            	}
            	}
            
        }
    private IEnumerator placeNameCo(){
        text.SetActive(true);
        placeText.text = placeName;

        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }
}
