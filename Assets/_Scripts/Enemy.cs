using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHasHealth {

    SpriteRenderer sr;
    Transform art;

    public enum Animal {CHICKEN, PIG, COW, DEAD};
    public Animal type;

    [SerializeField] GameObject bloodEffect;
    [SerializeField] float maxHealth = 2;
    [SerializeField]float currentHealth;
    public  float pointValue = 1;

    [SerializeField] float moveSpeed = 1;
    Transform target;
    // Use this for initialization
    void Start () {
        target = FindObjectOfType<PlayerMove>().transform;
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
        art = transform.GetChild(0);
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector2.Distance(transform.position, target.position) > 1) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            Vector3 dir = target.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }



    public void TakeDamage(int dmg) {
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        currentHealth -= dmg;
        Knockback();
        if(currentHealth == 0) {
            type = Animal.DEAD;
            Spawner.UpdateKills();
            //Instantiate Death paraticles
            //Change to corpse Graphic and disable all other scripts
            DisableScripts();
            art.gameObject.SetActive(false);
            sr.enabled = true;
            
        } else if(currentHealth < 0) {
            return;
        }
    }

    public void Die() {
        Destroy(this.gameObject);
    }

    void DisableScripts() {
        MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts) {
            script.enabled = false;
        }
        CircleCollider2D attack = GetComponent<CircleCollider2D>();
        attack.enabled = false;
    }

    public void Knockback() {
        //TODO Knockback
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<IHasHealth>().TakeDamage(1);
        }
    }
}
