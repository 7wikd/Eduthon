using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zone_stop2 : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;
    public bool needText;
    public string placeName;
    public GameObject text;
    private bool ti11;
    private bool ti12;
    private bool ti13;
    private bool ti14;
    private bool change;
    public Text placeText;

    void Start(){
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update(){
        ti11 = GameObject.Find("til11").GetComponent<interactableObject>().state;
        ti12 = GameObject.Find("til12").GetComponent<interactableObject>().state;
        ti13 = GameObject.Find("til13").GetComponent<interactableObject>().state;
        ti14 = GameObject.Find("til14").GetComponent<interactableObject>().state;
           if(ti11==false && ti12==true && ti13==true && ti14==true){

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
