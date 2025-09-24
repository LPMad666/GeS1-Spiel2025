using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Shooting Settings")]
    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;
    public float reloadtime = 2.0f;
    public float fireRate = 0.2f; // Zeit in Sekunden zwischen den Schüssen

    private float nextFireTime = 0f; // Zeit, zu der der Spieler das nächste Mal schießen kann
    private bool hasAmmo;
    private bool isReloading = false;

    [Header("Audio Settings")]
    public AudioClip shootSound; // mp3 Datei für Schussgeräusch
    public AudioSource shootingAudioSource; //AudioSource Komponente zum Abspielen des Schussgeräuschs

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Holt die AudioSource Komponente vom GameObject, an dem dieses Skript angehängt ist
        shootingAudioSource = GetComponent<AudioSource>();
        if (shootingAudioSource == null)
        {
            shootingAudioSource = gameObject.AddComponent<AudioSource>();
        }
        hasAmmo = true;
    }

    // Update is called once per frame
    void Update()
    {
        this.MouseEvents();
        this.CanShoot();
    }

    private void SpawnBullet()
    {
        if(hasAmmo == false || isReloading)
        {
            Debug.Log("Kein Magazin mehr! Nachladen!");
            return;
        }
        else 
        { 
            // bulletPrefab ist das Eingabefeld im Inspector, dem wir die Kugel zuweisen
            // Instantiate erstellt eine Kopie des Prefabs an der Position und Rotation des zweiten und dritten Parameters
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, Quaternion.identity);
            Vector3 playerForwardVector = transform.forward; //Richtung des Spielers
            bullet.GetComponent<BulletSpawn>().SetDirection(playerForwardVector); //Setzt die Richtung der Kugel auf die Blickrichtung des Spielers

            // Abspielen des Schussgeräuschs
            if (shootSound != null && shootingAudioSource != null)
            {
                SoundManager.Instance.PlaySound2D(shootSound);
            }
            // Munition um 1 reduzieren
            GetComponent<PlayerStats>().ReduceAmmo(1);
        }
    }

    private void MouseEvents()
    {
        if (Input.GetMouseButtonDown(0)) //Linke Maustaste
        {
            this.SpawnBullet();
        }

        if (Input.GetMouseButton(0) && Time.time > nextFireTime)
        {
            SpawnBullet();
            nextFireTime = Time.time + fireRate; // Setze die Zeit für den nächsten Schuss
        }

        if (Input.GetMouseButtonDown(1)) //Rechte Maustaste
        {
            Debug.Log("Rechte Maustaste gedrückt - Zielen");
            // Hier Code zum Zielen hinzufügen
        }

    }

    private bool CanShoot()
    {
        int ammunition = GetComponent<PlayerStats>().GetCurrentAmmo();
        if(ammunition > 0 && isReloading == false)
        {
            hasAmmo = true;
        }
        else
        {
            hasAmmo = false;
        }

        return hasAmmo;
    }

    public void Reload(int ammo)
    {
        StartCoroutine(ReloadDelay(ammo));
    }

    private IEnumerator ReloadDelay(int ammo)
    {
        if (isReloading) yield break; //if already reloading, break
        isReloading = true;
        
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadtime);

        if (GetComponent<PlayerStats>().ReloadAmmo(ammo))
        {
            hasAmmo = true;
            Debug.Log("Reload finished");
        }

        isReloading = false;
    }

}
