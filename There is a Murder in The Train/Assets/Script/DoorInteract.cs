using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorInteract : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;
    Vector2 newPosition;

    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] GameObject player;
    [SerializeField] GameObject fadeBlack;
    private bool Touched()
    {
        return Physics2D.OverlapBox(transform.position, transform.localScale * 2, 0f, playerLayer);
    }
    // void Update()
    // {
    //     if (Touched() == false)
    //     fadeBlack.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
    // }
    IEnumerator OnMouseDown()
    {
        if (Touched())
        {
            // fadeBlack.GetComponent<SpriteRenderer>().color = new Color(0,0,0,255);
            player.GetComponent<PlayerMovement>().status = false;
            StartCoroutine(FadeTo(20f,1f));
            Debug.Log(("teleport start"));
            newPosition = new Vector2(x, y);
            player.transform.position = newPosition;
            yield return new WaitForSeconds(0.2f);
            StartCoroutine(FadeTo(0f,1f));
            Debug.Log("teleport done");
            yield return new WaitForSeconds(0.65f);
            player.GetComponent<PlayerMovement>().status = true;
            if(player.transform.position.x != x || player.transform.position.y != y)
            {
                player.transform.position = newPosition;
            }

        }
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
    float alpha = fadeBlack.GetComponent<SpriteRenderer>().color.a;
    for (float t = 0.0f; t < 1.0f; t += (Time.deltaTime / aTime))
        {
        Color newColor = new Color(0, 0, 0, Mathf.Lerp(alpha,aValue,t));
        fadeBlack.GetComponent<SpriteRenderer>().color = newColor;
        yield return null;
        }
    }
}
