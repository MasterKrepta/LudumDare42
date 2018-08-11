using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHasHealth {

    [SerializeField] float maxHealth = 2;
    [SerializeField]float currentHealth;


    [SerializeField] float moveSpeed = 1;
    Transform target;
    // Use this for initialization
    void Start () {
        target = FindObjectOfType<PlayerMove>().transform;
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector2.Distance(transform.position, target.position) > 1) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }



    public void TakeDamage(int dmg) {
        currentHealth -= dmg;
        Knockback();
        if(currentHealth == 0) {
            Die();
        } else if(currentHealth < 0) {
            return;
        }
    }

    public void Die() {
        Spawner.UpdateKills();
        //Instantiate Death paraticles
        //Change to corpse Graphic and disable all other scripts
        DisableScripts();
    }

    void DisableScripts() {
        MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts) {
            script.enabled = false;
        }
    }

    public void Knockback() {
        //TODO Knockback
    }
}
