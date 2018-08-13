using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    AudioSource audioSource;
    [SerializeField] GameObject effectManager;
    [SerializeField] float playTime = 4;
    [SerializeField] AudioClip[] chickenClips;
    [SerializeField] AudioClip[] pigClips;
    [SerializeField] AudioClip[] cowClips;
    
    bool cowsAlive = false;
    bool chickensAlive = false;
    bool pigsAlive = false;

    private static SoundManager instance = null;
    public static SoundManager Instance {
        get { return instance; }
    }

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        }
        else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

    }

    private void Start() {
        audioSource = effectManager.GetComponent<AudioSource>();
        InvokeRepeating("PlaySounds", 4, playTime);
    }


    void PlaySounds() {
        SetBools();
        GetNewClip();
    }
    

    void SetBools() {
        Enemy[] enemies =  GameObject.FindObjectsOfType<Enemy>();
        List<Enemy> enemiesAlive = new List<Enemy>();
        if (enemies != null) {
            foreach (Enemy e in enemies) {
                if(e.type != Enemy.Animal.DEAD) {
                    enemiesAlive.Add(e);
                }
            }

            foreach (Enemy e in enemiesAlive) {
                if (e.type == Enemy.Animal.CHICKEN) {
                    chickensAlive = true;
                }
                else {
                    chickensAlive = false;
                }
                
                if (e.type == Enemy.Animal.PIG) {
                    pigsAlive = true;
                }
                else {
                    pigsAlive = false;
                }
                
                if (e.type == Enemy.Animal.COW) {
                    cowsAlive = true;
                }
                else {
                    cowsAlive = false;
                }
            }
        }
    }

    void GetNewClip() {
        audioSource.clip = null;
        
        if (chickensAlive) {
        
            int index = Random.Range(0, chickenClips.Length);
            audioSource.clip = chickenClips[index];
            audioSource.Play();
        }
        if (pigsAlive) {
        
            int index = Random.Range(0, pigClips.Length);
            audioSource.clip = pigClips[index];
            audioSource.Play();
        }
        if (cowsAlive) {
        
            int index = Random.Range(0, cowClips.Length);
            audioSource.clip = cowClips[index];
            audioSource.Play();
        }
    }
}