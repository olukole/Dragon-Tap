using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
  Rigidbody2D rb;
  public float jumpForce;

  private void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  private void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      // Jump
      rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Obstacle"))
    {
      FindFirstObjectByType<GameManager>().GameOver();
    }
  }
}
