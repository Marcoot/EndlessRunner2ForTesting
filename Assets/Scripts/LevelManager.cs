using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform tileObject;
    private Vector3 nextTileSpawn;
    private float respawnTime = 2f;
    PlayerMovement PlayerMovement;

    private void Start()
    {

        PlayerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        StartCoroutine(SpawnTile());
        nextTileSpawn.z = 20;
    }

    private void Update()
    {

    }

    IEnumerator SpawnTile()
    {
        yield return new WaitForSeconds(respawnTime);
        Instantiate(tileObject, nextTileSpawn, tileObject.rotation);
        //nextTileSpawn.z += 30;
        StartCoroutine(SpawnTile());
    }
}
