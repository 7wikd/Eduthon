using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class last_zone_transition : MonoBehaviour
{
    public Vector2 cameraChange;
    public Animator transition;
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
        ti21 = GameObject.Find("tile21").GetComponent<interactableObject>().state;
        ti22 = GameObject.Find("tile22").GetComponent<interactableObject>().state;
        ti23 = GameObject.Find("tile23").GetComponent<interactableObject>().state;
        ti24 = GameObject.Find("tile24").GetComponent<interactableObject>().state;
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

		LoadNextLevel();

            	if(needText){
                StartCoroutine(placeNameCo());
            	}
            	}
            
        }
        
        public void LoadNextLevel() {
        	StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        
        }
        
        IEnumerator LoadLevel(int levelIndex)
        {
        	transition.SetTrigger("Start");
        	Debug.Log(levelIndex);
        	yield return new WaitForSeconds(1f);
        	SceneManager.LoadScene(levelIndex);
        
        
        }
        
    private IEnumerator placeNameCo(){
        text.SetActive(true);
        placeText.text = placeName;

        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }
}
