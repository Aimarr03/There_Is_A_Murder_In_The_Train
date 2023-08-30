using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteract : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;
    private bool Touched()
    {
        return Physics2D.OverlapBox(transform.position, transform.localScale * 2, 0f, playerLayer);
    }
    void OnMouseDown()
    {
        if (Touched())
        Destroy(gameObject);
    }

}
