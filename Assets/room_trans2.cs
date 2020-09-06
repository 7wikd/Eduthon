using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class room_trans2 : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;
    public bool needText;
    public string placeName;
    public GameObject text;
    private bool t11;
    private bool t12;
    private bool t13;
    private bool t14;
    private bool change;
    public Text placeText;

    void Start(){
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update(){
        t11 = GameObject.Find("tile11").GetComponent<interactableObject>().state;
        t12 = GameObject.Find("tile12").GetComponent<interactableObject>().state;
        t13 = GameObject.Find("tile13").GetComponent<interactableObject>().state;
        t14 = GameObject.Find("tile14").GetComponent<interactableObject>().state;
           if(t11==false && t12==true && t13==true && t14==true){

           	this.GetComponent<Collider2D>().isTrigger = true;
           	Debug.Log("pass");
           	}
           else {
           	this.GetComponent<Collider2D>().isTrigger = false;
           }

    }

    private void OnTriggerEnter2D(Collider2D other){


        if(other.CompareTag("Player")){
 		
            	cam.minPosition -= cameraChange;
            	cam.maxPosition -= cameraChange;
            	other.transform.position -= playerChange;
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
