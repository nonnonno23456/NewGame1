using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject menuSet;
    public GameObject GameOver;
    public static bool isPaused = false; 
    
    public Player1 player1;
    public Player2 player2;
    
    void Update()
    {
        //Sub Menu
        if (Input.GetButtonDown("Cancel"))
        {
            SubMenuActive();
        }

        if (player1.getIsDead() || player2.getIsDead())
        {
            Invoke("Gameover",2.8f);
        }
        
        
    }

    public void SubMenuActive()
    {
        if (menuSet.activeSelf)
        {
            menuSet.SetActive(false);
            isPaused = false;
        }

        else
        {
            menuSet.SetActive(true);
            isPaused = true;
        }
}

    void Gameover()
    {
        GameOver.SetActive(true);
        isPaused = true;
    }


    
    public void GameExit()
    {
        Application.Quit();
    }

}
