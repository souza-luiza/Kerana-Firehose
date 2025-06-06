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
        this.vidas--;
        Debug.Log(this.name + " recebeu dano. Vida: " + this.vidas);
        if(this.vidas==0)
        {
            //Derrotado
            this.animator.SetBool("Morte", true);
            Destroy(gameObject, 0.6f);
            onDeathCallback?.Invoke();
        }
        else if(this.gameObject.tag=="Mosquinha")
        {
            //Recebeu dano
            this.animator.SetTrigger("Dano");
        }
    }

    public void SetOnDeathCallback(System.Action callback)
    {
        onDeathCallback = callback;
    }
}
