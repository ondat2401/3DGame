using ReadyPlayerMe.Samples.QuickStart;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject energyTankPrefab;
    [SerializeField] private GameObject jetpackBooster;

    private float currentTime;
    [SerializeField] private float moveTime;
    [SerializeField] private float speed;

    private void Update()
    {
        if(GameManager.instance.gameState == GameState.Playing)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= moveTime)
            {
                currentTime = 0;
                int nextRoad = Random.Range(0, 3);
                StartCoroutine(Movement(nextRoad));
            }
        }
    }
    private IEnumerator Movement(int nextRoad)
    {
        Vector3 targetPosition = transform.position;

        switch (nextRoad)
        {
            case 0:
                targetPosition = new Vector3(-5, transform.position.y, transform.position.z);
                break;
            case 1:
                targetPosition = new Vector3(0, transform.position.y, transform.position.z);
                break;
            case 2:
                targetPosition = new Vector3(5, transform.position.y, transform.position.z);
                break;
        }

        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
        if(!GameManager.instance.player.isDrainingEnergy)
            SpawnEnergyTank();
    }
    private void SpawnEnergyTank()
    {
        int randomChoice = Random.Range(0, 100);

        if(randomChoice == 50)
            Instantiate(jetpackBooster, transform.position,Quaternion.identity);
        else
            Instantiate(energyTankPrefab, transform.position,Quaternion.identity);
    }
}
