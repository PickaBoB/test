using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private List<GameObject> coins = new List<GameObject>();

    private GameManager gameMng;
    private MoverMethods methods;

    private float maxZ;

    private Transform coinsContain;

    void Start()
    {
        coinsContain = new GameObject("CoinsContain").transform;

        gameMng = FindObjectOfType<GameManager>();
        methods = FindObjectOfType<MoverMethods>();

        maxZ = gameMng.maxZ;

        CreateCoins(gameMng.coinsPref, gameMng.coinsCount);

        gameMng = FindObjectOfType<GameManager>();
    }

    void FixedUpdate()
    {
        Spin(coins);
        methods.MoveBack(coins);
        methods.ReturnObjects(coins, gameMng.coinsIndent);
    }

    private void CreateCoins(GameObject objs, int count)
    {
        float startZ = maxZ;
        float endZ = 10f;

        float stepZ = (startZ - endZ) / count;

        for (int i = 0; i < count; i++)
        {
            Vector3 position = new Vector3(Random.Range(-gameMng.maxX, gameMng.maxX), 1, startZ - i * stepZ);

            if (CheckPos(position))
            {
                GameObject coinInst = Instantiate(objs, position, Quaternion.identity);
                coinInst.transform.SetParent(coinsContain);
                coins.Add(coinInst);
            }
        }

        Debug.Log($"Total coins placed: {coins.Count}");
    }


    private void Spin(List<GameObject> objs)
    {
        foreach(GameObject obj in objs)
        {
            obj.transform.Rotate(0,3,0);
        }
    }

    private bool CheckPos(Vector3 position)
    {
        float radius = 0.5f;
        Collider[] col = Physics.OverlapSphere(position, radius);

        return col.Length == 0;
    }

    public void TransformCoin(GameObject coin)
    {
        methods.ReturnObjects(coins,coin,2);
    }
}
