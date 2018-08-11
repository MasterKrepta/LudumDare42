using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour {

    [SerializeField] Transform gun;
    [SerializeField] Transform bullet;
    public float visualOffset;
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = Camera.main.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dif = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotation = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0, 0, rotation + visualOffset);

        if (Input.GetMouseButton(0)) {
            anim.SetTrigger("Fired");
            Instantiate(bullet, gun.position, gun.rotation);
        }
	}
}
