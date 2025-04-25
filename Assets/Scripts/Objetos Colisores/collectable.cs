using UnityEngine;

public class collectable : collidable
{
    protected bool collected;

    protected override void OnCollide(Collider2D coll)
    {
       if (coll.name == "Kerana")
       {
           OnCollect();
       }
    }

    protected virtual void OnCollect()
    {
        collected = true;
    }
}
