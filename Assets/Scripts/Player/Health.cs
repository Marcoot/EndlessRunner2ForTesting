using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int currentHealth = 3;
    private int maxHealth = 3;
    PlayerMovement playerMovement;
    SwitchScenes switchScenes;

    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            HitObstacle();
            Debug.Log(currentHealth);
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            currentHealth -= 1;
            Debug.Log(currentHealth);
        }

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(sceneName: "GameOverScreen");
            currentHealth = maxHealth;
        }
    }

    private void HitObstacle()
    {
        //currentHealth = currentHealth -= 1;
        playerMovement.speed = playerMovement.speed - 1.0f;
    }
}
