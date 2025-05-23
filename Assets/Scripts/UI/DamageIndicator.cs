using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageIndicator : MonoBehaviour
{
    public Image image;
    public float flashSpeed;

    private Coroutine coroutine;

    private void Start()
    {
        CharacterManager.Instance.Player.condition.onTakeDamage += Flash;
        
    }

    public void Flash()
    {
        if(coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        image.enabled = true;
        image.color = new Color(image.color.r, image.color.g, image.color.b);
        coroutine = StartCoroutine(FadeAway());

    }

    private IEnumerator FadeAway()
    {
        float startAlpha = 0.3f;
        float a = startAlpha;

        while(a>0)
        {
            a -= (startAlpha / flashSpeed) * Time.deltaTime;
            image.color = new Color(image.color.r, image.color.g, image.color.b, a);
            yield return null;
        }

        image.enabled = false;
    }

}
