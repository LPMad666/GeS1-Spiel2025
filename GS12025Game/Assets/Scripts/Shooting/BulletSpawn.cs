using UnityEngine;

public class BulletSpawn : MonoBehaviour
{

    [SerializeField]
    private Vector3 direction = new Vector3(0, 0, 0);

    [SerializeField]
    private float speed = 0.1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = direction.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        BulletShoot();
    }

    private void BulletShoot() //Bewegung der Kugel in die Richtung
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void SetDirection(Vector3 dir) //Setzt die Richtung der Kugel
    {
        direction = dir.normalized;

        //kugel soll in die Richtung schauen
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }

}
