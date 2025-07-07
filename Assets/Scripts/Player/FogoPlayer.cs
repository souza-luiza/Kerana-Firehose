using UnityEngine;

public class FogoPlayer : MonoBehaviour
{
    //ranged
    public Transform Aim;
    public GameObject bullet;
    public float fireForce = 10f;
    float shootCooldown = 0.25f;
    float shootTimer = 0.5f;

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;
        if (Input.GetMouseButtonDown(1))
        {
            OnShoot();
        }
    }

    void OnShoot()
    {
        if (shootTimer > shootCooldown)
        {
            shootTimer = 0;
            GameObject intBullet = Instantiate(bullet, Aim.position, Aim.rotation);
            intBullet.GetComponent<Rigidbody2D>().AddForce(-Aim.up * fireForce, ForceMode2D.Impulse);
            Destroy(intBullet, 1f);
        }
    }
}
