using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zone_stop_1 : MonoBehaviour
{
    // public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;
    public bool needText;
    public string placeName;
    public GameObject text;
    private bool ti01;
    private bool ti02;
    private bool ti03;
    private bool ti04;
    private bool change;
    public Text placeText;

    void Start(){
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update(){
        ti01 = GameObject.Find("til01").GetComponent<interactableObject>().state;
        ti02 = GameObject.Find("til02").GetComponent<interactableObject>().state;
        ti03 = GameObject.Find("til03").GetComponent<interactableObject>().state;
        ti04 = GameObject.Find("til04").GetComponent<interactableObject>().state;
           if(ti01==false && ti02==false && ti03==false && ti04==true){

           	this.GetComponent<Collider2D>().isTrigger = true;
           	Debug.Log("pass");
           	}
           else {
           	this.GetComponent<Collider2D>().isTrigger = false;
           }

    }

    private void OnTriggerEnter2D(Collider2D other){


        if(other.CompareTag("Player")){
 		
            	// cam.minPosition += cameraChange;
            	// cam.maxPosition += cameraChange;
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
