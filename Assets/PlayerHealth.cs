using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 4;
    private int currentHealth;

    public HealthUI healthUI;

    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthUI.SetMaxHearts(maxHealth);

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Inimigo enemy = collision.gameObject.GetComponent<Inimigo>();
        if (enemy)
        {
            TakeDamage(1); //ou mudar para enemy.damage
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthUI.UpdateHearts(currentHealth);

        StartCoroutine(FlashRed());
    
        if (currentHealth <= 0)
        {
            //player dead -- call game over, animation, etc
        }
    }

    private IEnumerator FlashRed()
    {
        spriteRenderer.color = new Color(0.9333333f, 0.3294118f, 0.3294118f, 1f); //cor para dano
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }
}
