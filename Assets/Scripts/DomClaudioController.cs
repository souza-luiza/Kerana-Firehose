using UnityEngine;

public class DomClaudioController : MonoBehaviour
{
    public int vidas;
    public int vidaMax;

    public float velocidadeClaudio;

    public GameObject DomClaudioFogo;
    public Transform DomClaudioLocalDisparo;
    public float tempoMaxEntreDisparos;
    public float tempoAtualDisparos;

    private bool Cima = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthLogic();
        AtirarFogo();
        Movimentar();
        DeadState();
    }

    void HealthLogic()
    {
        if(vidas>vidaMax)
        {
            vidas = vidaMax;
        }
    }

    void DeadState()
    {
        if(vidas <= 0)
        {
            GetComponent<DomClaudioController>().enabled = false;
            Destroy(gameObject, 1.0f);
        }
    }

    private void AtirarFogo()
    {
        tempoAtualDisparos -= Time.deltaTime;
        if(tempoAtualDisparos <= 0)
        {
            Instantiate(DomClaudioFogo, DomClaudioLocalDisparo.position, Quaternion.Euler(0f, 0f, -90f));
            tempoAtualDisparos = tempoMaxEntreDisparos;
        }
    }
    private void Movimentar()
    {
        float direcao;
        if(Cima)
        {
            direcao = 1;
        } 
        else
        {
            direcao = -1;
        }  
        transform.Translate(Vector3.up * velocidadeClaudio * direcao * Time.deltaTime);
        if (transform.position.y >= -26f)
        {
            Cima = false;
        }
        else if (transform.position.y <= -33f)
        {
            Cima = true;
        }
    }
}
