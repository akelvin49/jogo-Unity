using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject painelPaused;
    public GameObject ButtonPause;
    public GameObject gameOver;
    public GameObject gameContinue;
    public GameObject gameNoContinue;

    public GameObject player;

    private bool isPaused = false;
    private bool menuGameOver = false;


    // Update is called once per frame
    void Update () {
        if ( (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape) ) && !menuGameOver)
        {
            paused();
        }
        
        if (player.GetComponent<Player>().death && !menuGameOver)
        {
            AfterDeath();
        }
    }

    public void paused()
    {
        isPaused = !isPaused;

        if (isPaused){
            painelPaused.SetActive(false);
            UnPause();
        }else{
            painelPaused.SetActive(true);
            Pause();
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;
    }

    private void UnPause()
    {
        Time.timeScale = 1;
    }

    private void AfterDeath()
    {
        if (player.transform.position.y <= player.GetComponent<Player>().DOWN_LIMIT)
        {
            player.SetActive(false);
            
            if (player.GetComponent<Player>().lives > 0)
            {
                player.GetComponent<Player>().lives--;
                player.GetComponent<Player>().textLives.text = player.GetComponent<Player>().lives.ToString();
                gameContinue.SetActive(true);
                gameOver.SetActive(true);
                ButtonPause.SetActive(false);
                Pause();



            }
            else if (player.GetComponent<Player>().lives == 0)
            {
                gameNoContinue.SetActive(true);
                gameOver.SetActive(true);
                ButtonPause.SetActive(false);
                Pause();
            }
            menuGameOver = true;

        }

        
    }

    public void Continue()
    {
        gameContinue.SetActive(false);
        gameOver.SetActive(false);
        ButtonPause.SetActive(true);
        GameObject checkPoint = player.GetComponent<Player>().checkPoint;
        if (checkPoint != null)
        {
            player.transform.position = checkPoint.transform.position;
        }
        else
        {
            player.transform.position = player.GetComponent<Player>().posicaoInicial;
        }

        
        player.GetComponent<Player>().death = false;
        player.GetComponent<CapsuleCollider2D>().isTrigger = false;
        player.SetActive(true);
        player.GetComponent<Animator>().SetBool("Death", false);
        menuGameOver = false;
        painelPaused.SetActive(false);
        UnPause();

    }
}
