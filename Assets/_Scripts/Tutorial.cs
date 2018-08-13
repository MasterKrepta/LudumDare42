using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Tutorial : MonoBehaviour {

    [SerializeField]TMP_Text getReady;
    [SerializeField] TMP_Text finalScore;


    private void Start() {
        getReady.gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Prop")){
            StartCoroutine("CountDownToStart");
            
		}
	}

    IEnumerator CountDownToStart() {
        if(finalScore != null) {
            finalScore.gameObject.SetActive(false);
        }
        getReady.gameObject.SetActive(true);
        getReady.GetComponent<Animator>().SetBool("GetReady", true);
        yield return new WaitForSeconds(3);
        getReady.GetComponent<Animator>().SetBool("GetReady", false);
        SceneChanger.ChangeLevel(1);
    }
}
