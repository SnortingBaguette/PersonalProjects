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

    private IEnumerator HitCooldown()
    {

        yield return new WaitForSeconds(0.35f);
        isHit = false;

    }

    public void TakeDamage(float amountOfDamage)
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

    void Die()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        characterController.Move((player.transform.position - transform.position).normalized * speed * Time.deltaTime);
    }


}
