using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
