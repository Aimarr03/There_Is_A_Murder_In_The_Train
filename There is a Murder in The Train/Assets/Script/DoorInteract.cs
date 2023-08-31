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
    private bool Touched()
    {
        return Physics2D.OverlapBox(transform.position, transform.localScale * 2, 0f, playerLayer);
    }
    void OnMouseDown()
    {
        if (Touched())
        Debug.Log(("move"));
        newPosition = new Vector2(x, y);
        player.transform.position = newPosition;
    }

}
