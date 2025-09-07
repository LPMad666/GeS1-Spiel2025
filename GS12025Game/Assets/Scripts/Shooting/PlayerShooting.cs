using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.MouseEvents();
    }

    private void SpawnBullet()
    {
        // bulletPrefab ist das Eingabefeld im Inspector, dem wir die Kugel zuweisen
        // Instantiate erstellt eine Kopie des Prefabs an der Position und Rotation des zweiten und dritten Parameters
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, Quaternion.identity);
        Vector3 playerForwardVector = transform.forward; //Richtung des Spielers
        bullet.GetComponent<BulletSpawn>().SetDirection(playerForwardVector); //Setzt die Richtung der Kugel auf die Blickrichtung des Spielers
    }

    private void MouseEvents()
    {
        if (Input.GetMouseButtonDown(0)) //Linke Maustaste
        {
            this.SpawnBullet();
        }
    }

}
