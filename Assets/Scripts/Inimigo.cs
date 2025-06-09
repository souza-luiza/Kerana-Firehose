using System;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField]
    private int vidas;

    [SerializeField]
    private Animator animator;

    private Action onDeathCallback;

    public string ID;

    public void ReceberDano()
    {
        vidas--;
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
    }

    public void SetOnDeathCallback(Action callback)
    {
        onDeathCallback = callback;
    }
}
