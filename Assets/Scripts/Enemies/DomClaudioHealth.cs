using System;
using System.Collections;
using UnityEngine;

public class DomClaudioHealth : MonoBehaviour
{
    public int maxHealth = 20;
    private int currentHealth;

    private SpriteRenderer spriteRenderer;
    public static event Action OnClaudioDied;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Weapon fogo = collision.gameObject.GetComponent<Weapon>();
        if (fogo && fogo.weaponType == Weapon.WeaponType.Bullet)
        {
            TakeDamage(1); //talvez mudar para dano do fogo
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;

        StartCoroutine(FlashRed());

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            OnClaudioDied.Invoke(); //call win image
        }
    }
    
    private IEnumerator FlashRed()
    {
        spriteRenderer.color = new Color(0.9333333f, 0.3294118f, 0.3294118f, 1f); //cor para dano
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }
}
