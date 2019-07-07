using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringMechanics : MonoBehaviour
{
    public float JumpForce;

    public List<Sprite> SpriteList;
    public int TimeBetweenFrames;

    private void Start()
    {
    }

    public void SpringTrigger(GameObject Player)
    {
        if (GameManager.GameStart == true)
        {
            StartCoroutine(Animation(SpriteList, TimeBetweenFrames, this.GetComponent<SpriteRenderer>()));
            Player.GetComponent<PlayerMechanics>().Jump(JumpForce);
        }
    }



      private IEnumerator Animation(List<Sprite> List, int Time, SpriteRenderer SR)
       {
           foreach(Sprite a in List)
        {
            SR.sprite = a;
            yield return StartCoroutine(Frames(Time));
        }
       }

      public IEnumerator Frames(int frameCount)
       {
        while (frameCount > 0)
        {
            frameCount--;
            yield return null;
        }
       }

}
