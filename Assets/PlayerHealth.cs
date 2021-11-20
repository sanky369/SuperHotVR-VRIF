using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{

    public int playerLife = 5;
    public TextMeshProUGUI playerLifeText;
    public bool isDead = false;

    public bool stopCheckingHealth = false;

    private void FixedUpdate()
    {
        playerLifeText.text = playerLife.ToString();
    }

    private void Update()
    {
        if(playerLife <= 0)
        {
            isDead = true;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    public void TakeDamage()
    {
        playerLife--;
    }

    public void ResetHealth()
    {
        playerLife = 5;
    }
}
