using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHasHealth {

    Color hitColor = Color.red;
    Color originalColor;
    [SerializeField]GameObject art, gun;
    [SerializeField] GrinderTimer grinderTimer;
    [SerializeField]float currentHealth;
    int lives = 3;
    [SerializeField] float maxHealth = 10;
    [SerializeField] float respawnTime = 3;
    [SerializeField] Transform healthMask, lifeMask;
    public bool Invincible = false;
    [SerializeField] float cooldownTime = 3;
    Vector3 lifeMaskOrigin, healthMaskOrigin;

    public void Die() {
        lives--;
        lifeMask.position -= new Vector3(1,0,0);
        if(lives <= 0) {
            GameOver();
        }
        grinderTimer.StopClock();
        art.SetActive(false);
        gun.SetActive(false);
        DisableScripts();
        StartCoroutine("ResetStage");
    }

    private void GameOver() {
        lifeMask.position = Vector3.zero;
        ScoreManager.UpdateFinalScore();
        SceneChanger.ChangeLevel(2);
    }

    public void Knockback() {
        //TODO Knockback
    }

    public void TakeDamage(int dmg) {
        if (!Invincible) {
            AudioSource grunt = GetComponent<AudioSource>();
            grunt.Play();
            Invincible = true;
            StartCoroutine(FlashColor());
            
            currentHealth -= dmg;
            healthMask.position -= new Vector3(1, 0, 0);
            Knockback();
            if (currentHealth == 0) {
                Die();
            }
            else if (currentHealth < 0) {
                return;
            }
        }
 
    }

    IEnumerator FlashColor() {
        Renderer[] sprites = GetComponentsInChildren<SpriteRenderer>();

        foreach (Renderer r in sprites) {
            originalColor = r.material.color;
            r.material.color = hitColor;
        }
        yield return new WaitForSeconds(cooldownTime);
        foreach (Renderer r in sprites) {
            r.material.color = originalColor;
        }
        Invincible = false;
    }

    IEnumerator CoolDown() {
        yield return new WaitForSeconds(cooldownTime);
        
    }
    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
        healthMaskOrigin = healthMask.position;
        lifeMaskOrigin = lifeMask.position;
        
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
        healthMask.position = healthMaskOrigin;
        EnableScripts();
        currentHealth = maxHealth;
        this.transform.position = Vector3.zero; // Starating Pos
        art.SetActive(true);
        gun.SetActive(true);
        grinderTimer.ResetClock();
        Spawner.canSpawn = true;
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
