using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteract : MonoBehaviour
{
    [SerializeField] Button characterButton;
    void Start()
    {
        characterButton.interactable = false;
    }

    void OnTriggerExit(Collider other)
    {
        characterButton.interactable = false;
    }
    void OnTriggerEnter(Collider other)
    {
        characterButton.interactable = true;
    }
    public void HeClick()
    {
        Destroy(gameObject);
    }
}
