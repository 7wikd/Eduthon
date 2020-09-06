using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class room_trans1 : MonoBehaviour{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;
    public bool needText;
    public string placeName;
    public GameObject text;
    private bool t01;
    private bool t02;
    private bool t03;
    private bool t04;
    private bool change;
    public Text placeText;

    void Start(){
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update(){
        t01 = GameObject.Find("tile01").GetComponent<interactableObject>().state;
        t02 = GameObject.Find("tile02").GetComponent<interactableObject>().state;
        t03 = GameObject.Find("tile03").GetComponent<interactableObject>().state;
        t04 = GameObject.Find("tile04").GetComponent<interactableObject>().state;
           if(t01==false && t02==false && t03==false && t04==true){

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
