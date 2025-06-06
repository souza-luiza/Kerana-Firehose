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

    // Adicione estas variáveis para a sequência de imagens
    public GameObject[] vitorias; // Arraste os GameObjects vitoria0 até vitoria12 no Inspector
    private int indiceVitoria = 0;
    private float tempoEntreVitorias = 0.2f; // tempo entre cada imagem
    private float tempoVitoriaAtual = 0f;
    private bool mostrandoVitoria = false;

    void Start()
    {

    }

    void Update()
    {
        HealthLogic();
        AtirarFogo();
        Movimentar();
        DeadState();
        SequenciaVitoria();
    }

    void HealthLogic()
    {
        if (vidas > vidaMax)
        {
            vidas = vidaMax;
        }
    }

    void DeadState()
    {
        if (vidas <= 0 && !mostrandoVitoria)
        {
            GetComponent<DomClaudioController>().enabled = false;
            mostrandoVitoria = true;
            indiceVitoria = 0;
            tempoVitoriaAtual = 0f;
            if (vitorias.Length > 0)
            {
                for (int i = 0; i < vitorias.Length; i++)
                    vitorias[i].SetActive(false);
                vitorias[0].SetActive(true);
            }
            Destroy(gameObject, (vitorias.Length * tempoEntreVitorias) + 0.5f);
        }
    }

    void SequenciaVitoria()
    {
        if (mostrandoVitoria && vitorias.Length > 0)
        {
            tempoVitoriaAtual += Time.deltaTime;
            if (tempoVitoriaAtual >= tempoEntreVitorias && indiceVitoria < vitorias.Length - 1)
            {
                vitorias[indiceVitoria].SetActive(false);
                indiceVitoria++;
                vitorias[indiceVitoria].SetActive(true);
                tempoVitoriaAtual = 0f;
            }
        }
    }

    private void AtirarFogo()
    {
        tempoAtualDisparos -= Time.deltaTime;
        if (tempoAtualDisparos <= 0)
        {
            Instantiate(DomClaudioFogo, DomClaudioLocalDisparo.position, Quaternion.Euler(0f, 0f, -90f));
            tempoAtualDisparos = tempoMaxEntreDisparos;
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
