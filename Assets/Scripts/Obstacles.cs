using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    List<GameObject> walls = new List<GameObject>();


    private float xPose, zPose;
    private float indent = 5;

    private Transform obstaclesContain;

    private GameManager gameMng;
    private MoverMethods methods;

    void Start()
    {
        obstaclesContain = new GameObject("ObstaclesContain").transform;

        gameMng = FindObjectOfType<GameManager>();
        methods = FindObjectOfType<MoverMethods>();

        zPose = gameMng.maxZ;

        CreateWalls(gameMng.wallPref);
    }

    void FixedUpdate()
    {
        methods.MoveBack(walls);
        methods.ReturnObjects(walls, indent);
    }

    private void CreateWalls(List<GameObject> objs)
    {
        foreach (GameObject wall in objs)
        {
            zPose -= indent;
            xPose = Random.Range(-gameMng.maxX, gameMng.maxX);

            GameObject instObj = Instantiate(wall, new Vector3(xPose, 1, zPose), Quaternion.identity);
            instObj.transform.SetParent(obstaclesContain);
            walls.Add(instObj);
        }
    }
}
