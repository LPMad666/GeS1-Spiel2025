using UnityEngine;

public class AutoDestroyBullet : MonoBehaviour
{

    public float lifetime = 3.0f; // Lebensdauer der Kugel in Sekunden

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //gameObject klein, da => verweist auf das GameObject, an dem dieses Skript angehängt ist
        Destroy(gameObject, lifetime); // Zerstört das GameObject nach der angegebenen Lebensdauer
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
