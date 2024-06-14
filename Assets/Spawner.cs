using System.Collections;
using System.Collections.Generic;
using ChuongCustom;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemies;

    [SerializeField] public List<Transform> randomPoint;

    public float time = 2, timeCount = 2;

    public int count;


    private void Spawn()
    {
        var enemy = Instantiate(enemies, randomPoint[Random.Range(0, randomPoint.Count)].position,
            transform.rotation).GetComponent<Virus>();

        count++;

        if (count is > 0 and < 7)
        {
            enemy.Init(Random.Range(1, 6));
        }
        else if (count is >= 7 and < 13)
        {
            enemy.Init(Random.Range(1, GameDataManager.Instance.VirusSo.data.Length));
        }
        else
        {
            count = 0;

            var transformPosition = enemy.transform.position;
            transformPosition.x = 0;
            enemy.transform.position = transformPosition;

            enemy.Init(0);
        }
    }

    void Update()
    {
        if (Manager.InGame.isPlay)
        {
            time -= Time.deltaTime;

            if (time <= 0)
            {
                time = timeCount;

                Spawn();
            }
        }
    }
}