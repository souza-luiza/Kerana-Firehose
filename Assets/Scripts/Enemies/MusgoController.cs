using UnityEngine;

public class MusgoController : MonoBehaviour
{

    public GameObject fogoMusgo;
    public Transform localDisparo;
    public float tempoMaxEntreDisparos;
    public float tempoAtualDisparos;
    private Animator _MusgoAnimator;

    public int direcaoDisparo; //direcao 0 = esquerda, direcao 1 = direita

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _MusgoAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AtirarFogo();
    }

    private void AtirarFogo()
    {
        tempoAtualDisparos -= Time.deltaTime;
        if(tempoAtualDisparos <= 0)
        {
            GameObject fogo = Instantiate(fogoMusgo, localDisparo.position, Quaternion.Euler(0f, 0f, 0f));

            Vector3 direcao = (direcaoDisparo == 0) ? Vector3.left : Vector3.right;
            fogo.GetComponent<FogoDoMusgo>().SetDirecao(direcao);

            _MusgoAnimator.SetInteger("Ataque", 1);
            tempoAtualDisparos = tempoMaxEntreDisparos;
        }
        else
        {
            _MusgoAnimator.SetInteger("Ataque", 0);
        }
    }
}
