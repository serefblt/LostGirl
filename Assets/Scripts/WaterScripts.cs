using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterScripts : MonoBehaviour
{
    [SerializeField] GameObject _gameOverPanel;
    [SerializeField] Animator _anim;
    PlayerController _playController;

    private void Awake()
    {
       
        _playController = new PlayerController();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _anim.Play("Dead");
         
            StartCoroutine(DeadPanel());
           
        }
    }

    IEnumerator DeadPanel()
    {
        
        yield return new WaitForSeconds(0);
        Time.timeScale = 0;
        _gameOverPanel.SetActive(true);

    }


    public void GameOverOnClick()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

   public void Retry()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

}
