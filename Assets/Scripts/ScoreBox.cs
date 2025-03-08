using UnityEngine;

public class ScoreBox : MonoBehaviour
{
    public GameObject other;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            GameManager.score++;
            FindFirstObjectByType<GameManager>().ScoreUpdate();
        }
    }
}
