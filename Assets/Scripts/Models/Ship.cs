using UnityEngine;

public class Ship
{
    public int Health { get; private set; }
    public GameObject Projectile { get; private set; }
    public int Score { get; private set; }
    public Ship(int health, GameObject projectile)
    {
        this.Health = health;
        this.Projectile = projectile;
        this.Score = 0;
    }
    public void ReduceHealth()
    {
        Health -= 1;
    }
    public void IncreaseScore()
    {
        Score += 10;
    }
}
