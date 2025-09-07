using UnityEngine;

public class EnemyTypeOneStats : MonoBehaviour
{

    [Header("Enemy Type One Stats")]
    public int maxhealth = 100;
    private int currentHealth;
    public int damage = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxhealth); //Stellt sicher, dass die HP nicht unter 0 f�llt
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Hier k�nnen Sie Effekte oder Animationen hinzuf�gen, bevor der Gegner zerst�rt wird
        Destroy(this.gameObject);
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

}
