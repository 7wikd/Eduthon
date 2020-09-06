using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour{
    public float speed;
    //public GameObject stack;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public GameObject reference;
    // public VectorValue startingPosition;
    
    // Start is called before the first frame update
    void Start(){
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        /*try{
            reference = GameObject.FindWithTag("Reference");
        }
        catch(SystemException e){
            Debug.Log(e);
        }*/
        // transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void Update(){
        change = Vector3.zero;
        change.x = SimpleInput.GetAxis("Horizontal");
        change.y = SimpleInput.GetAxis("Vertical");
        UpdateAnimationAndMove();

        //Debug.Log(change);
    }
    
    void UpdateAnimationAndMove(){
        if (change != Vector3.zero){
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving",true);
        }
        else{
            animator.SetBool("moving",false);
        }
    }

    void MoveCharacter(){
        myRigidbody.MovePosition(transform.position + change*speed*Time.deltaTime);
    }
}
