using UnityEngine;

public class ClearZone : MonoBehaviour
{
    public GameObject Clear;
    
    public GameObject player1;
    public GameObject player2;

    private bool player1Inside = false;
    private bool player2Inside = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player1)
            player1Inside = true;
        else if (other.gameObject == player2)
            player2Inside = true;

        CheckBothPlayersInside();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player1)
            player1Inside = false;
        else if (other.gameObject == player2)
            player2Inside = false;
    }
    

    private void CheckBothPlayersInside()
    {
        if (player1Inside && player2Inside)
        {
            Clear.SetActive(true);
        }
    }

}
