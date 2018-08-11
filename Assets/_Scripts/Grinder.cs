using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grinder : MonoBehaviour {


    Animator anim;

    private void Start() {
        anim = Camera.main.GetComponent<Animator>();
    }
    public void ActivateGrinder() {
        anim.SetTrigger("Grinder");
        //TODO Play Animation - and start a short delay
        Collider2D[] colliders = GetAllObjectsInGrinder();
        if(colliders != null) {

            foreach (Collider2D col in colliders) {
                //TODO Add points for corpse
                //Call Add Points
                ScoreManager.AddPoints(1);
                if (col.CompareTag("Player")) {
                    //TODO damage player
                    Debug.Log("Player would have died here");
                    return;
                }
                Destroy(col.gameObject);
            }
        }
        else {
            Debug.Log("No one to destoy");
        }
        

    }

    private Collider2D[] GetAllObjectsInGrinder() {
        Collider2D[] temp = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 360);
        return temp;

    }

    //void OnDrawGizmos() {
    //    Gizmos.color = Color.red;
    //    //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode

    //    //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
    //    Gizmos.DrawWireCube(transform.position, transform.localScale);
    //}

}
