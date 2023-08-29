using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    [SerializeField]private Animator animator;
    private float WaitSecond = 1f;
    // Start is called before the first frame update

    // Update is called once per frame
    public enum GameScene
    {
        Main_Menu,
        Interract,
        Dialog
    }
    public GameScene scene;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex));
        }
    }
    IEnumerator LoadScene(int index)
    {
        Debug.Log(index);
        if (index == 0) index++;
        else index = 0;
        animator.SetTrigger("LoadedScene");
        yield return new WaitForSeconds(WaitSecond);
        SceneManager.LoadScene(index);
    }
}
