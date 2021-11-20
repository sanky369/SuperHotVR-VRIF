using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletMovement : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    private ScreenFader screenFader;
    public TextMeshProUGUI lifeScore;
    private Question question;
    private PlayerHealth health;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        screenFader = FindObjectOfType<ScreenFader>();
        //question = FindObjectOfType<Question>();
        health = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            BodyPartScript bp = collision.gameObject.GetComponent<BodyPartScript>();

            //if (!bp.enemy.dead)
                Instantiate(SuperHotScript.instance.hitParticlePrefab, transform.position, transform.rotation);

            //question.receivedAnswers.Add(bp.enemy.enemyValue);

            bp.HidePartAndReplace();
            bp.enemy.Ragdoll();
        }
        

        if (collision.gameObject.CompareTag("PlayerHit"))
        {
            Debug.Log("player hit");
            if (health.stopCheckingHealth == false)
            {
                health.TakeDamage();
            }   
        }

        Destroy(gameObject);
    }

}
