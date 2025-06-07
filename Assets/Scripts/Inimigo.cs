using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField]
    private int vidas;

    [SerializeField]
    private Animator animator;

    private System.Action onDeathCallback;

    public void ReceberDano()
    {
        vidas--;
        Debug.Log(name + " recebeu dano. Vida: " + this.vidas);
        if(vidas<=0)
        {
            //Derrotado
            animator.SetBool("Morte", true);
            Destroy(gameObject, 0.6f);
            onDeathCallback?.Invoke();
        }
        else if(gameObject.tag=="Mosquinha")
        {
            //Recebeu dano
            animator.SetTrigger("Dano");
        }
    }

    public void SetOnDeathCallback(System.Action callback)
    {
        onDeathCallback = callback;
    }
}
