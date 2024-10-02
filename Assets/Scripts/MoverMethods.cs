using System.Collections.Generic;
using UnityEngine;

public class MoverMethods : MonoBehaviour
{
    private GameManager gameMng;

    void Start()
    {
        gameMng = FindObjectOfType<GameManager>();
    }


    public void MoveBack(List<GameObject> objs)
    {
        foreach (GameObject obj in objs)
        {
            obj.transform.position += Vector3.back * gameMng.speedOfGame * Time.fixedDeltaTime;
        }
    }
    public void ReturnRoutes(List<GameObject> objs)
    {
        foreach (GameObject route in objs)
        {
            if (route.transform.position.z <= gameMng.endOfRoute)
                route.transform.position = new Vector3(0, 0, FindMaxZ(objs) + gameMng.lenghtOfRoute);
        }
    }
    public void ReturnObjects(List<GameObject> objs, float indent)
    {
        foreach (GameObject obj in objs)
        {
            if (obj.transform.position.z <= gameMng.endOfRoute)
                obj.transform.position = new Vector3(Random.Range(-gameMng.maxX, gameMng.maxX), 1, FindMaxZ(objs) + indent);
        }
    }
    public void ReturnObjects(List<GameObject> objs, GameObject obj, float indent)
    {
        obj.transform.position = new Vector3(Random.Range(-gameMng.maxX, gameMng.maxX), 1, FindMaxZ(objs) + indent);
    }

    private float FindMaxZ(List<GameObject> objs)
    {
        float maxZ = float.MinValue;
        foreach (GameObject route in objs)
        {
            if (route.transform.position.z > maxZ)
                maxZ = route.transform.position.z;
        }
        return maxZ;
    }
}
