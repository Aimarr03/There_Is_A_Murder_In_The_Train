using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public static EndingManager instance;
    [SerializeField] private GameObject fadeBlack;

    public void Awake()
    {
        instance = this;
    }
    public IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = fadeBlack.GetComponent<SpriteRenderer>().color.a;
        for (float t = 0.0f; t < 1.0f; t += (Time.deltaTime / aTime))
        {
            Color newColor = new Color(0, 0, 0, Mathf.Lerp(alpha, aValue, t));
            fadeBlack.GetComponent<SpriteRenderer>().color = newColor;
            yield return null;
        }
    }
}
