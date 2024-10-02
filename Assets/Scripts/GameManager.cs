using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> floorPref;
    public List<GameObject> wallPref;

    public GameObject coinsPref;
    public GameObject player;

    public int coinsCount = 200;
    public int coinsIndent = 2;

    public float endOfRoute = -50;

    private float time;

    public float speedOfGame = 10f;

    public float lenghtOfRoute;

    public float maxZ;
    public float maxX;

    private int score = 0;
    public Text scoreText;
    public Button restart;
    public Button exit;

    private bool gameStop = false;

    private void Awake()
    {
        lenghtOfRoute = floorPref[0].GetComponent<MeshRenderer>().bounds.size.z;
        maxX = floorPref[0].GetComponent<MeshRenderer>().bounds.size.x / 2;
        maxZ = floorPref.Count * lenghtOfRoute;
    }

    private void FixedUpdate()
    {
        if (player.activeSelf)
        {
            Timer(30f);
        }
    }

    private void Update()
    {
        if (!player.activeSelf)
        {
            gameStop= true;
            speedOfGame = 0;
        }
        if (gameStop)
        {
            restart.gameObject.SetActive(true);
            exit.gameObject.SetActive(true);
        }

    }
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    private void Timer(float reset)
    {
        if (time < reset)
        {
            time += Time.fixedDeltaTime;
        }
        else
        {
            speedOfGame += 1f;
            time = 0;
        }
    }
}
