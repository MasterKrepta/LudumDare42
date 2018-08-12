using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    [SerializeField]Animator art;
    [SerializeField] float moveSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetInput();
	}

    private void GetInput() {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        if(h == 0 && v == 0) {
            art.SetBool("Moving", false);
        }
        else {
            art.SetBool("Moving", true);
        }
        Vector3 movement = new Vector3(h, v, 0);
        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}

