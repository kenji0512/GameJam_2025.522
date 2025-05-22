using UnityEngine;

public class GoalArea : MonoBehaviour
{
    private int playersInGoal = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerRed") || other.CompareTag("PlayerBlue"))
        {
            playersInGoal++;

            if (playersInGoal >= 2)
            {
                GameManager.Instance.StageClear();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerRed") || other.CompareTag("PlayerBlue"))
        {
            playersInGoal--;
        }
    }
}
