using UnityEngine;

public class EnemyTypeOneStats : MonoBehaviour
{

    [Header("Enemy Type One Stats")]
    public int maxhealth = 100;
    private int currentHealth;
    public int damage = 10;

    [Header("Audio Settings")]
    public AudioClip dyingSound; // mp3 Datei f�r Schussger�usch
    public AudioSource dyingAudioSource; //AudioSource Komponente zum Abspielen des Schussger�uschs

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxhealth;

        // Holt die AudioSource Komponente vom GameObject, an dem dieses Skript angeh�ngt ist
        dyingAudioSource = GetComponent<AudioSource>();
        if (dyingAudioSource == null)
        {
            dyingAudioSource = gameObject.AddComponent<AudioSource>();
        }
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
        // Abspielen des Schussger�uschs
        if (dyingSound != null)
        {
            AudioSource.PlayClipAtPoint(dyingSound, transform.position);
        }

        Destroy(this.gameObject);
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

}
