using UnityEngine;

public class Portal : collidable
{
    public string[] scenes;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Kerana")
        {   
            string scene = scenes[Random.Range(0, scenes.Length)];
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
        }
    }
}
