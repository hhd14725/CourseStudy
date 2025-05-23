using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuffEntry : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI label;
    public Image durationFill;

    private float totalDuration;
    private float remaining;

    public void Initialize(BuffData buff)
    {
        icon.sprite = buff.icon;
        label.text = $"{buff.buffName}\n {buff.GetDisplayValue()}" ;

        totalDuration = buff.Duration;
        remaining = totalDuration;
        durationFill.fillAmount = 1f;

        StartCoroutine(UpdateFill(buff));

    }

    private IEnumerator UpdateFill(BuffData buff)
    {
        while(remaining >0)
        {
            remaining -= Time.deltaTime;
            durationFill.fillAmount = remaining / totalDuration;
            yield return null;
        }
    }

  
}
