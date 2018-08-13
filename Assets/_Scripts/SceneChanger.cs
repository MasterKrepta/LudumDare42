using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    public List<string> levels;
    
  

    public static void ChangeLevel(int levelID) {
        SceneManager.LoadScene(levelID);
    }
    


}
