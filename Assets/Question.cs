using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;

public class Question: MonoBehaviour
{
    //public static Question instance;

    public List<string> receivedAnswers;

    public List<string> correctAnswers;

    public TextMeshProUGUI showAnswer;

    public string sceneName;

    private PlayerHealth health;

    private void Awake()
    {
        //instance = this;
        health = FindObjectOfType<PlayerHealth>();

    }



    public void ValidateAnswer()
    {
        health.stopCheckingHealth = true;

        //if (receivedAnswers.Count != correctAnswers.Count)
        //{
        //    showAnswer.text = "INCORRECT";
        //    Invoke("ShowSameQuestion", 3f);
        //    return;
        //}

        //foreach (string s in receivedAnswers)
        //{
        //    if (correctAnswers.Contains(s))
        //    {
        //        showAnswer.text = "CORRECT";
        //    }
        //    else
        //    {
        //        showAnswer.text = "INCORRECT";
        //        Invoke("ShowSameQuestion", 3f);
        //    }
        //}

        if (Enumerable.SequenceEqual(receivedAnswers.OrderBy(e => e), correctAnswers.OrderBy(e => e)))
        {
            showAnswer.text = "CORRECT";
            Invoke("ShowNextQuestion", 3f);
        }
        else
        {
            showAnswer.text = "INCORRECT";
            //receivedAnswers.Clear();
            Invoke("ShowSameQuestion", 3f);
        }

        //receivedAnswers.Clear();
        //Invoke("ShowNextQuestion", 3f);

    }

    void ShowNextQuestion()
    {
        if(sceneName == "NA")
        {
            Application.Quit();
        }

        SceneManager.LoadScene(sceneName);
    }

    void ShowSameQuestion()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }


}
