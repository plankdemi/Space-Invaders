
using System;
using UnityEngine;

public class InvaderController : MonoBehaviour
{
    public event Action<InvaderController> SpaceInvaderHit;

    public Ship ship;
    public GameObject projectile;
    private int startingHealth;
    private float offset;
    private float timer;
    public float interval;

    public ParticleSystem pc;
    void Awake()
    {
        startingHealth = 1;
        ship = new Ship(startingHealth, projectile);
        offset = -0.5f;
        interval = 3f;
        timer = UnityEngine.Random.Range(0, 3) * 0.3f;

    }

    void Update()
    {

        timer += Time.deltaTime;
        if (timer > interval)
        {
            Shoot();
            timer = 0f;
            interval = UnityEngine.Random.Range(3, 7);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ship.ReduceHealth();
            if (ship.Health <= 0)
            {
                Instantiate(pc, transform.position, Quaternion.identity);

                pc.Play();
                Destroy(gameObject);
            }
            SpaceInvaderHit?.Invoke(this);
            Debug.Log("I was hit invader");

        }
    }
    private void Shoot()
    {
        Vector3 pos = new(transform.position.x, transform.position.y + offset, transform.position.z);
        GameObject temp = Instantiate(projectile, pos, transform.rotation);
        temp.tag = "Invader";
    }

}
