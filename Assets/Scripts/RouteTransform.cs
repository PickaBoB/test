using System.Collections.Generic;
using UnityEngine;

public class RouteTransform : MonoBehaviour
{
    private List<GameObject> routes = new List<GameObject>();

    private GameManager gameMng;
    private MoverMethods methods;


    private Transform routeContein;

    void Start()
    {
        routeContein = new GameObject("RouteContein").transform;

        gameMng = FindObjectOfType<GameManager>();
        methods = FindObjectOfType<MoverMethods>();

        CreateRoutes(gameMng.floorPref, gameMng.lenghtOfRoute);
    }

    void FixedUpdate()
    {
        methods.MoveBack(routes);
        methods.ReturnRoutes(routes);
    }

    private void CreateRoutes(List<GameObject> objs, float length)
    {
        float zPos = 0;

        for (int i = 0; i < objs.Count; i++)
        {
            GameObject instObj = Instantiate(objs[i], new Vector3(0, 0, zPos), Quaternion.identity);
            instObj.transform.SetParent(routeContein);
            routes.Add(instObj);
            zPos += length;
        }
    }
}
