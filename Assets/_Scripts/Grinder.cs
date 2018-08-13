using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grinder : MonoBehaviour {

    Animator anim;
    [SerializeField]GameObject grate;
    private void Start() {
        anim = Camera.main.GetComponent<Animator>();
    }
    public void ActivateGrinder() {
        grate.SetActive(false);
        anim.SetTrigger("Grinder");
        //TODO Play Animation
         Collider2D[] colliders = GetAllObjectsInGrinder();
        if(colliders != null) {
            foreach (Collider2D col in colliders) {
                //Debug.Log(col.name);
                if(col.tag == "Enemy") {
                    float pointValue = col.GetComponent<Enemy>().pointValue;
                    ScoreManager.AddPoints(pointValue);
                }
                col.GetComponent<IHasHealth>().Die();
            }
        }
        StartCoroutine("ResetGrate");
    }

    private Collider2D[] GetAllObjectsInGrinder() {
        Collider2D[] temp = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 360);
        return temp;
    }
    IEnumerator ResetGrate() {
        yield return new WaitForSeconds(1);
        grate.SetActive(true);
    }
}
