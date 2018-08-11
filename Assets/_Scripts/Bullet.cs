using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField] float speed;
    float lifetime = 1.5f;
	
	// Update is called once per frame
	void Update () {
        
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        Destroy(gameObject, lifetime);
    }

   
}
