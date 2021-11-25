using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _tilePrefabs;
    [SerializeField] List<GameObject> _activeTiles = new List<GameObject>();
    [SerializeField] private Transform _player;
    private float _spawnPosition = 0;
    private float _tileLength = 90;
    private int _valueSpawnTiles = 2;
    private int _tileNumber = 2;

    private void Start()
    {
       for (int i = 0; i < _valueSpawnTiles; i++)
        {
            SpawnTile(i);
        }
    }
    private void Update()
    {
        if ((_player.position.z  - _tileLength > _activeTiles[0].transform.position.z) && (_activeTiles.Count > 1))
        {
            DeleteTile();
            if (_tileNumber < _tilePrefabs.Length)
            {
                SpawnTile(_tileNumber);
                _tileNumber += 1;
            }
        }
    }

    private void SpawnTile (int tileIndex)
    {
        GameObject nextTile = Instantiate(_tilePrefabs[tileIndex], transform.forward * _spawnPosition, transform.rotation);
        _activeTiles.Add(nextTile);
        _spawnPosition += _tileLength;
    }

    private void DeleteTile()
    {
        Destroy(_activeTiles[0]);
        _activeTiles.RemoveAt(0);
    }
}
