using UnityEngine;

public class MusgoController : MonoBehaviour
{

    public GameObject fogoMusgo;
    public Transform localDisparo;
    public float tempoMaxEntreDisparos;
    public float tempoAtualDisparos;
    private Animator _MusgoAnimator;

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
            Instantiate(fogoMusgo, localDisparo.position, Quaternion.Euler(0f, 0f, 0f));
            _MusgoAnimator.SetInteger("Ataque", 1);
            tempoAtualDisparos = tempoMaxEntreDisparos;
        }
        else
        {
            _MusgoAnimator.SetInteger("Ataque", 0);
        }
    }
}
