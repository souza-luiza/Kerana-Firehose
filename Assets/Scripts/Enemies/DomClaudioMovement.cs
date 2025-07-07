using UnityEngine;

public class DomClaudioMovement : MonoBehaviour
{
    public float velocidadeClaudio;
    private bool Cima = true;

    public GameObject DomClaudioFogo;
    public Transform DomClaudioLocalDisparo;
    public float tempoMaxEntreDisparos;
    public float tempoAtualDisparos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimentar();
        AtirarFogo();
    }

    private void AtirarFogo()
    {
        if (DomClaudioFogo != null && DomClaudioLocalDisparo != null)
        {
            tempoAtualDisparos -= Time.deltaTime;
            if (tempoAtualDisparos <= 0)
            {
                Instantiate(DomClaudioFogo, DomClaudioLocalDisparo.position, Quaternion.Euler(0f, 0f, 90f));
                tempoAtualDisparos = tempoMaxEntreDisparos;
            }
        }
        
    }
    
    private void Movimentar()
    {
        float direcao;
        if (Cima)
        {
            direcao = 1;
        }
        else
        {
            direcao = -1;
        }

        transform.Translate(direcao * Time.deltaTime * velocidadeClaudio * Vector3.up);

        if (transform.position.y >= -19f)
        {
            Cima = false;
        }
        else if (transform.position.y <= -27f)
        {
            Cima = true;
        }
    }
}
