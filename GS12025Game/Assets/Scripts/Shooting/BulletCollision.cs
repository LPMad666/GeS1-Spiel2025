using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public int damage = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        //Prüfen, ob das getroffene GameObjekt ein Enemy ist? 
        EnemyTypeOneStats enemy = other.GetComponent<EnemyTypeOneStats>(); 
        if (enemy != null)
        {
            enemy.TakeDamage(damage);

            Destroy(gameObject); //Kugel verschwinden lassen
        }
        
    }
}
