using UnityEngine;

public class FogoDoMusgo : MonoBehaviour
{
    public float velocidadeDoFogo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            transform.Translate(Vector3.down * velocidadeDoFogo * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * velocidadeDoFogo * Time.deltaTime);
        }
        Destroy(gameObject, 1.0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HeartSystem>().vida--;
            Destroy(this.gameObject);
        }
    }
}
