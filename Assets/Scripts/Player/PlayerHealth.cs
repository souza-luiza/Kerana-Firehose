using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 4;
    private int currentHealth;

    public HealthUI healthUI;

    private bool canTakeDamage = true;
    public static event Action OnPlayerDied;

    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetHealth();

        spriteRenderer = GetComponent<SpriteRenderer>();
        GameController.OnReset += ResetHealth;
    }

    public void SetCurrentHealth(int newHealth)
    {
        currentHealth = newHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Inimigo enemy = collision.gameObject.GetComponent<Inimigo>();
        if (enemy)
        {
            TakeDamage(enemy.damage);
        }
    }

    public void ApplyDamage(int amount)
    {
        TakeDamage(amount);
    }

    void ResetHealth()
    {
        currentHealth = maxHealth;
        healthUI.SetMaxHearts(maxHealth);
    }

    private void TakeDamage(int damage)
    {
        if (!canTakeDamage) return;

        currentHealth -= damage;
        healthUI.UpdateHearts(currentHealth);

        StartCoroutine(FlashRed());

        if (currentHealth <= 0)
        {
            //player dead -- call game over, animation, etc
            OnPlayerDied.Invoke();
        }
        StartCoroutine(DamageCooldown());
    }

    private IEnumerator DamageCooldown() //evita danos sequenciais
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(1f);
        canTakeDamage = true;
    }

    private IEnumerator FlashRed()
    {
        spriteRenderer.color = new Color(0.9333333f, 0.3294118f, 0.3294118f, 1f); //cor para dano
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }
}
