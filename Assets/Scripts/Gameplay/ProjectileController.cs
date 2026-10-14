using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float direction;
    public int speed;



    void Start()
    {
        if (CompareTag("Player"))
        {
            direction = 1;
            speed = 5;
        }
        else if (CompareTag("Invader"))
        {
            direction = -1;
            speed = 3;
        }
    }

    void Update()
    {
        transform.position += new Vector3(0, direction, 0) * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!CompareTag(collision.gameObject.tag))
        {
            Destroy(gameObject);
        }

    }

}
