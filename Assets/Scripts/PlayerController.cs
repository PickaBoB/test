using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private float maxX;

    private int speed = 10;

    private GameManager gameMng;

    private void Start()
    {
        gameMng = FindObjectOfType<GameManager>();
        maxX = gameMng.maxX - player.GetComponent<MeshRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        Movement(player, speed, -maxX, maxX);
    }

    private void Movement(GameObject player, int speed, float leftBorder, float rightBorder)
    {

        if (Input.GetKey(KeyCode.A))
        {
            float newX = player.transform.position.x - speed * Time.fixedDeltaTime;

            if (player.transform.position.x > leftBorder)
                player.transform.position = new Vector3(newX, player.transform.position.y, player.transform.position.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            float newX = player.transform.position.x + speed * Time.fixedDeltaTime;

            if (player.transform.position.x < rightBorder)
                player.transform.position = new Vector3(newX, player.transform.position.y, player.transform.position.z);
        }
    }

}
