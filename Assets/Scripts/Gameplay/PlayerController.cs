using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private float direction;
    public int speed;

    public Ship ship;
    public GameObject projectile;
    private int startingHealth;
    private float offset;

    public event Action PlayerHit;

    void Awake()
    {

        direction = 0;
        startingHealth = 3;
        ship = new Ship(startingHealth, projectile);
        offset = 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += direction * Time.deltaTime * speed;
        pos.x = Mathf.Clamp(pos.x, -9.5f, 9.5f);
        transform.position = pos;
    }
    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>().x;

    }
    private void OnShoot()
    {
        projectile.transform.position = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);

        GameObject temp = Instantiate(projectile);
        temp.tag = "Player";

    }

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.CompareTag("Invader"))
        {
            ship.ReduceHealth();
            PlayerHit?.Invoke();
            if (ship.Health <= 0)
            {
                Destroy(gameObject);
            }


        }
    }
}

