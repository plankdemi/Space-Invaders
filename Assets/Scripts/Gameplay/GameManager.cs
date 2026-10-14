using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject player;
    private GameObject[] invaders;

    public TextMeshProUGUI score;
    public TextMeshProUGUI health;
    public TextMeshProUGUI statusScreen;
    private int remainingEnemies;
    private bool isWin;
    void Awake()
    {
        statusScreen.gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        invaders = GameObject.FindGameObjectsWithTag("Invader");
        remainingEnemies = invaders.Length;
    }
    void Start()
    {
        if (player)
        {
            player.GetComponent<PlayerController>().PlayerHit += PlayerHit;
        }

        foreach (GameObject invader in invaders)
        {
            if (invader)
            {
                invader.GetComponent<InvaderController>().SpaceInvaderHit += SpaceInvaderHit;
            }
        }
    }

    private void SpaceInvaderHit(InvaderController invader)
    {
        if (invader.ship.Health <= 0)
        {
            player.GetComponent<PlayerController>().ship.IncreaseScore();
            UpdateScoreUI();
            --remainingEnemies;
        }
        if (remainingEnemies <= 0)
        {
            isWin = true;
            ShowGameOverUI();

        }

    }

    private void PlayerHit()
    {

        if (player.GetComponent<PlayerController>().ship.Health <= 0)
        {

            isWin = false;
            ShowGameOverUI();

        }
        UpdateHealthUI();

    }
    private void UpdateHealthUI()
    {
        health.text = "LIVES: " + player.GetComponent<PlayerController>().ship.Health;
    }
    private void UpdateScoreUI()
    {
        score.text = "SCORE: " + player.GetComponent<PlayerController>().ship.Score;
    }
    private void ShowGameOverUI()
    {
        statusScreen.text = isWin ? "YOU WIN!\nALL SPACE INVADERS ARE DEAD!" : "YOU LOSE!\nYOU HAVE EXPLODED!";
        statusScreen.gameObject.SetActive(true);
    }

}
