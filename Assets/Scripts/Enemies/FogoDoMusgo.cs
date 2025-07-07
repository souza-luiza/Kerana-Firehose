using UnityEngine;

public class FogoDoMusgo : MonoBehaviour
{
    public float velocidadeDoFogo;

    private Vector3 direcao = Vector3.left;

    public void SetDirecao(Vector3 novaDirecao)
    {
        direcao = novaDirecao.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarFogo();
    }

    private void MovimentarFogo()
    {
        if(this.gameObject.CompareTag("PoderClaudio"))
        {
            transform.Translate(Time.deltaTime * velocidadeDoFogo * Vector3.down);
        }
        else
        {
            transform.Translate(Time.deltaTime * velocidadeDoFogo * direcao);
        }
        Destroy(gameObject, 1.0f);
    }

    /*void OnTriggerEnter2D(Collider2D other) //ANTIGO
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HeartSystem>().vida--;
            Destroy(this.gameObject);
        }
    }*/
}
