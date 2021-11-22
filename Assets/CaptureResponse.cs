using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureResponse : MonoBehaviour
{
    private Question question;
    private string response;
    private void Awake()
    {
        question = FindObjectOfType<Question>();
        response = gameObject.GetComponent<EnemyScript>().enemyValue;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            question.receivedAnswers.Add(response);
        }
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
