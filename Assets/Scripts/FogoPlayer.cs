using UnityEngine;

public class FogoPlayer : MonoBehaviour
{
    public float velocidadeFogo;

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
        transform.Translate(Vector3.right * velocidadeFogo * Time.deltaTime);
        Destroy(gameObject, 1.0f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("DomClaudio"))
        {
            other.gameObject.GetComponent<DomClaudioController>().vidas--;
            Destroy(this.gameObject);
        }
    }
}
