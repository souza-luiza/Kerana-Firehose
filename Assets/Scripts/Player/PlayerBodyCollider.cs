using UnityEngine;

public class PlayerBodyCollider : MonoBehaviour
{
    private PlayerHealth playerHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth = GetComponentInParent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FogoDoMusgo fogo = collision.gameObject.GetComponent<FogoDoMusgo>();
        if (fogo)
        {
            playerHealth.ApplyDamage(1); //dano do fogo
        }
        else
        {
            Laser laser = collision.gameObject.GetComponent<Laser>();
            if (laser)
            {
                playerHealth.ApplyDamage(2); //laser dando 2 de dano
            }
        }
    }
}
