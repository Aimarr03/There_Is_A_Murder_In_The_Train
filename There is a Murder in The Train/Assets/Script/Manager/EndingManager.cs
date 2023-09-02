using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    public static EndingManager instance;
    [SerializeField] private GameObject fadeBlack;
    [SerializeField] private GameObject EndingCanvas;

    public void Awake()
    {
        instance = this;
        EndingCanvas.gameObject.SetActive(false);
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
        ClueManager.instance.ClueButton.gameObject.SetActive(false);
        StartCoroutine(LoadScene());
    }
    public IEnumerator LoadScene()
    {
        EndingCanvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("MainMenu");
    }
}
