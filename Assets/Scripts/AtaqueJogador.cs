using UnityEngine;

public class AtaqueJogador : MonoBehaviour
{

    [SerializeField]
    private Transform pontoAtaqueDireita;

    [SerializeField]
    private Transform pontoAtaqueEsquerda;

    [SerializeField]
    private Transform pontoAtaqueCima;

    [SerializeField]
    private Transform pontoAtaqueBaixo;

    [SerializeField]
    private float raioAtaque;

    [SerializeField]
    private LayerMask layersAtaque;

    [SerializeField]
    private PlayerController player;

    public int fase;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.player._isAttack = true;
            Atacar();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            this.player._isAttack = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        if(this.pontoAtaqueDireita != null)
        {
            Gizmos.DrawWireSphere(this.pontoAtaqueDireita.position, this.raioAtaque); 
        }
        if(this.pontoAtaqueEsquerda != null)
        {
            Gizmos.DrawWireSphere(this.pontoAtaqueEsquerda.position, this.raioAtaque);
        }
        if(this.pontoAtaqueCima != null)
        {
            Gizmos.DrawWireSphere(this.pontoAtaqueCima.position, this.raioAtaque);
        }
        if(this.pontoAtaqueBaixo != null)
        {
            Gizmos.DrawWireSphere(this.pontoAtaqueBaixo.position, this.raioAtaque);
        }

        //Destaca área usada no momento
        Transform pontoAtaque;
        if(this.player.direcaoMovimento == DirecaoMovimento.Direita)
        {
            pontoAtaque = this.pontoAtaqueDireita;
        }
        else if(this.player.direcaoMovimento == DirecaoMovimento.Esquerda)
        {
            pontoAtaque = this.pontoAtaqueEsquerda;
        }
        else if(this.player.direcaoMovimento == DirecaoMovimento.Cima)
        {
            pontoAtaque = this.pontoAtaqueCima;
        }
        else
        {
            pontoAtaque = this.pontoAtaqueBaixo;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pontoAtaque.position, this.raioAtaque);
    }

    private void Atacar()
    {
        Transform pontoAtaque;
        if (fase != 0)
        {
            AudioController.current.PlayMusic(AudioController.current.Lanca);
        }
        if (this.player.direcaoMovimento == DirecaoMovimento.Direita)
        {
            pontoAtaque = this.pontoAtaqueDireita;
        }
        else if(this.player.direcaoMovimento == DirecaoMovimento.Esquerda)
        {
            pontoAtaque = this.pontoAtaqueEsquerda;
        }
        else if(this.player.direcaoMovimento == DirecaoMovimento.Cima)
        {
            pontoAtaque = this.pontoAtaqueCima;
        }
        else
        {
            pontoAtaque = this.pontoAtaqueBaixo;
        }

        Collider2D[] collidersInimigo = Physics2D.OverlapCircleAll(pontoAtaque.position, this.raioAtaque, this.layersAtaque);
        if(collidersInimigo != null)
        {
            foreach(Collider2D colliderInimigo in collidersInimigo) //Ataca todos inimigos no raio
            {
               Debug.Log("Atacando objeto " + colliderInimigo.name);

                //Causar dano no inimigo
                Inimigo inimigo = colliderInimigo.GetComponent<Inimigo>();
                if(inimigo != null)
                {
                    inimigo.ReceberDano();
                } 
            }
        }
    }
}
