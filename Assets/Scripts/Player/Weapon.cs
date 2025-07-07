using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage = 1;
    public enum WeaponType { Melee, Bullet }
    public WeaponType weaponType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Inimigo enemy = collision.GetComponent<Inimigo>();
        if (enemy != null)
        {
            enemy.ReceberDano(damage);
            if (weaponType == WeaponType.Bullet)
            {
                Destroy(gameObject);
            }
        }
    }
}
