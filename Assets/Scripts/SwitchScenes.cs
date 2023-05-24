using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(sceneName: "GameOverScreen");
        else if (Input.GetKeyDown(KeyCode.P)) SceneManager.LoadScene(sceneName: "GameScene");
    }
}
