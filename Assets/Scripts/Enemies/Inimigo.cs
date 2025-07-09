using System;
using System.Collections;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField]
    private int vidas;

    [SerializeField]
    private Animator animator;

    private Action onDeathCallback;

    public string ID;
    public int damage = 1;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ReceberDano(int dano)
    {
        vidas -= dano;
        Debug.Log(name + " recebeu dano. Vida: " + vidas);

        if (vidas <= 0)
        {
            //Derrotado
            animator.SetBool("Morte", true);
            Destroy(gameObject, 0.6f);
            onDeathCallback?.Invoke();

            //Adicionar uma morte
            QuestController.Instance.EnemyKilled(ID);
        }
        else if (gameObject.CompareTag("Mosquinha"))
        {
            //Recebeu dano
            animator.SetTrigger("Dano");
        }
        else
        {
            StartCoroutine(FlashRed());
        }
    }

    public void SetOnDeathCallback(Action callback)
    {
        onDeathCallback = callback;
    }
    
    private IEnumerator FlashRed()
    {
        spriteRenderer.color = new Color(0.9333333f, 0.3294118f, 0.3294118f, 1f); //cor para dano
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }
}
