using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour {
    [SerializeField] Texture2D cursor;
    [SerializeField] Transform gun;
    [SerializeField] Transform barrel;
    [SerializeField] Transform bullet;
    [SerializeField] float fireRate;
    float cooldown;
    bool canFire = true;
    public float visualOffset;
    Animator anim;

	// Use this for initialization
	void Start () {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
        anim = Camera.main.GetComponent<Animator>();
        cooldown = fireRate;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dif = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotation = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0, 0, rotation + visualOffset);

        if (Input.GetMouseButton(0) && canFire) {
            canFire = false;
            anim.SetTrigger("Fired");
            //Instantiate(bullet, bullet.position, gun.rotation);
            Instantiate(bullet, barrel.position, barrel.rotation);
        }

        if (!canFire && cooldown > 0) {
            cooldown -= Time.deltaTime;
        }
        else {
            canFire = true;
            cooldown = fireRate;
        }
	}
}
