using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{

    public int vida;
    public int vidaMaxima;
    public Image[] coracao;
    public Sprite cheio;
    public Sprite vazio;

    public string scene;

    private bool isDead;
    public GameManagerScript gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthLogic();
        DeadState();
    }

    void HealthLogic()
    {
        if(vida>vidaMaxima)
        {
            vida = vidaMaxima;
        }
        for(int i=0;i<coracao.Length;i++){
            if(i<vida)
            {
                coracao[i].sprite = cheio;
            }
            else
            {
                coracao[i].sprite = vazio;
            }
            if(i<vidaMaxima)
            {
                coracao[i].enabled = true;
            }
            else
            {
                coracao[i].enabled = false;
            }
        }
    }

    void DeadState()
    {
        if(vida <= 0 && !isDead)
        {
            isDead = true;
            gameManager.GameOver();
            GetComponent<PlayerController>().enabled = false;
            //Destroy(gameObject, 1.0f);
            vida = vidaMaxima;
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
        }
    }
}
