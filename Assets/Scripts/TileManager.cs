using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;

    private Transform _playerTransform;
    private float spawnZ = -10.0f;
    private float tileLength = 10.0f;
    private float safeZone = 15.0f;
    private int amnTilesOnScreen = 7;
    private int lastPrefabIndex = 0;

    private List<GameObject> activeTiles;

    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i=0; i < amnTilesOnScreen; i++)
        {
            if (i < 2)
                SpawnTile(0);
            else
                SpawnTile();
        }
 
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerTransform.position.z - safeZone> (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }

    private void SpawnTile(int prefabIndex = -1)
    {
        //Creating tiles
        GameObject _go;
        if (prefabIndex == -1)
            _go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        else
            _go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        _go.transform.SetParent(transform);
        _go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(_go);
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
