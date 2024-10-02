using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] private GameObject player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Wall")
        {
            player.SetActive(false);
        }
    }
}
