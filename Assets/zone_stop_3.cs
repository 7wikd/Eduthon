using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zone_stop_3 : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;
    public bool needText;
    public string placeName;
    public GameObject text;
    private bool ti21;
    private bool ti22;
    private bool ti23;
    private bool ti24;
    private bool change;
    public Text placeText;

    void Start(){
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update(){
        ti21 = GameObject.Find("til21").GetComponent<interactableObject>().state;
        ti22 = GameObject.Find("til22").GetComponent<interactableObject>().state;
        ti23 = GameObject.Find("til23").GetComponent<interactableObject>().state;
        ti24 = GameObject.Find("til24").GetComponent<interactableObject>().state;
           if(ti21==false && ti22==true && ti23==true && ti24==false){

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
