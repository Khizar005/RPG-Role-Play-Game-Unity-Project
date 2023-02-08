using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    public string sceenToLoad;
    public string transitionAreaName;
    [SerializeField] AreaEnter areaEnter;

    private void Start()
    {
          areaEnter.transitionAreaName = transitionAreaName;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.instance.transitionAreaName = transitionAreaName;
            MenuManager.instance.FadeImage();
            StartCoroutine(OnLevelLoaded());
        }
    }

    private IEnumerator OnLevelLoaded()
    {
        yield return new WaitForSeconds(1f);
       
        SceneManager.LoadScene(sceenToLoad);
    }
}
