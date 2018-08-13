using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHasHealth {

    [SerializeField]GameObject art, gun;
    [SerializeField] GrinderTimer grinderTimer;
    float currentHealth;
    [SerializeField] float maxHealth = 10;
    [SerializeField] float respawnTime = 3;
    

    

    public void Die() {
        grinderTimer.StopClock();
        art.SetActive(false);
        gun.SetActive(false);
        DisableScripts();
        StartCoroutine("ResetStage");
    }

    public void Knockback() {
        //TODO Knockback
    }

    public void TakeDamage(int dmg) {
        currentHealth -= dmg;
        Knockback();
        if (currentHealth == 0) {
            Die();
        }
        else if (currentHealth < 0) {
            return;
        }
    }

    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator ResetStage() {
        
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy e in enemies) {
            Destroy(e.gameObject);
        }
        yield return new WaitForSeconds(respawnTime);
        
        Respawn();
    }

    void Respawn() {
        EnableScripts();
        currentHealth = maxHealth;
        this.transform.position = Vector3.zero; // Starating Pos
        art.SetActive(true);
        gun.SetActive(true);
        grinderTimer.ResetClock();
    }

    void DisableScripts() {
        MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts) {
            if(script != this) {
                script.enabled = false;
            }
        }
    }

    void EnableScripts() {
        
        MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts) {
   
                script.enabled = true;
        }
    }
}
