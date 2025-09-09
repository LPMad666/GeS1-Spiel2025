using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public int damage = 3;
    public float attackSpeed = 2.0f; //Zeit zwischen Angriffen
    public float attackRange = 3.0f; // Wie nah muss der Player am Gegner sein, bis angegriffen wird

    public GameObject playerTarget;

    private bool canAttack = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTarget != null) {

            float distance = Vector3.Distance(transform.position, playerTarget.transform.position);

            if (distance <= attackRange && canAttack)
            {
                AttackPlayer();
            }
        }
    }

    void AttackPlayer()
    {
        if (canAttack && playerTarget != null)
        {
            // Player Stats holen und Schaden machen
            PlayerStats player = playerTarget.GetComponent<PlayerStats>();
            if (player != null)
            {
                    player.TakeDamage(damage);
            }

            if(player.isDead == true)
            {
                canAttack = false;
                Application.Quit();
            }
            else { 
                //Attack sperren für Cooldown
                canAttack = false;
                StartCoroutine(AttackDelay());
            }
        }
    }

    private IEnumerator AttackDelay()  
    {
        yield return new WaitForSeconds(attackSpeed);
        canAttack = true;
    }
}
