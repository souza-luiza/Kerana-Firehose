using UnityEngine;

public class Weapon : MonoBehaviour
{
    //public float damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Inimigo enemy = collision.GetComponent<Inimigo>();
        if (enemy != null)
        {
            enemy.ReceberDano();
        }
    }
}
