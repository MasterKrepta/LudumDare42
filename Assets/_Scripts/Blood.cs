using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour {

    [SerializeField] Sprite[] splatters;
    SpriteRenderer sr;
    // Use this for initialization
    void Start () {
        sr = GetComponent<SpriteRenderer>();
        int randSplat = Random.Range(0, splatters.Length);
        sr.sprite = splatters[randSplat];
        Destroy(this.gameObject, 30);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
