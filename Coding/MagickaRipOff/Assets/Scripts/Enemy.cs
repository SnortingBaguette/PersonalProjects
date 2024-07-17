using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public bool isHit = false;
    public ParticleSystem hitParticles;
    private CharacterController characterController;
    public GameObject player;
    private float speed = 2;

    private enum State
    {
        Walking,
        Stunned
    }
    private State currentState;

    private IEnumerator HitCooldown()
    {

        yield return new WaitForSeconds(0.2f);
        currentState = State.Walking;
        yield return new WaitForSeconds(0.3f);
        isHit = false;
        

    }

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        switch (currentState)
        {
            case State.Walking:
                WalkTowardsPlayer();
                break;
            case State.Stunned:
                break;
        }
    }

    public void TakeDamageArcane(float amountOfDamage)
    {

        if (!isHit) 
        {   
            isHit = true;
            health -= amountOfDamage;
            
            if (health <= 0)
            {
                Die();
                return;
            }
            hitParticles.Play();
            StartCoroutine(HitCooldown());
        }
        
        Debug.Log(health);
    }

    public void TakeDamageElectricity(float amountOfDamage)
    {

        if (!isHit)
        {
            isHit = true;
            currentState = State.Stunned;
            health -= amountOfDamage;

            if (health <= 0)
            {
                Die();
                return;
            }
            hitParticles.Play();
            StartCoroutine(HitCooldown());
        }

        Debug.Log(health);
    }

    void Die()
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }

    private void WalkTowardsPlayer()
    {
        characterController.Move((player.transform.position - transform.position).normalized * speed * Time.deltaTime);
    }


}
