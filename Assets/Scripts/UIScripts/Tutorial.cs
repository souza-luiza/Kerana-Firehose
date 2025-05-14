using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Canvas canvas;
    private bool isHidden = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isHidden && ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)))
        {
            canvas.enabled = false;
            isHidden = true;
        }
    }
}
