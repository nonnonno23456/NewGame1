using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string SceneName;  //불러올씬
    public void Load() {
        SceneManager.LoadScene(SceneName);
        GameManager.isPaused = false;
    }
}