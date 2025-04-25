using UnityEngine;

public class semente : collectable
{
  public Sprite sementeSprite;
  public int quantidade = 1;

  protected override void OnCollect()
  {
    if (!collected)
    {
      collected = true; 
      GetComponent<SpriteRenderer>().sprite = sementeSprite;
      Debug.Log("Semente coletada");    
    }
   
  }
}