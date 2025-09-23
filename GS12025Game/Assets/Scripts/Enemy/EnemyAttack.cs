using System.Collections;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
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
        // The check for gameObject.activeInHierarchy will be false after the enemy dies
        if (playerTarget != null && gameObject.activeInHierarchy)
        {
            EnemyTypeOneStats stats = GetComponent<EnemyTypeOneStats>();
            if (stats != null && stats.isDead) return;

            float distance = Vector3.Distance(transform.position, playerTarget.transform.position);

            if (distance <= attackRange && canAttack)
            {
                AttackPlayer();
            }
        }
    }

    void AttackPlayer()
    {
        if (!canAttack || playerTarget == null) return;  //Checken das der Enemy angreifen kann & er ein Target hat. 

        canAttack = false;

        //Player stats holen & Schaden machen
        PlayerStats player = playerTarget.GetComponent<PlayerStats>();
        if (player != null && !player.isDead)
        {
            player.TakeDamage(damage);
            StartCoroutine(AttackDelay());
        }

    }

    private IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(attackSpeed);
        canAttack = true;
    }

    private void OnDestroy()
    {
        StopAllCoroutines(); //Cooldown für next Attack etc. abbrechen
        canAttack = false; // Angriff sperren wenn tot
    }

    private void SetTarget(GameObject playerTarget)
    {
        this.playerTarget = playerTarget; //Gameobjekt übergabe als Player Target setzen. 
    }

}