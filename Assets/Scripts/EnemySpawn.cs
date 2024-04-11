using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    [SerializeField] GameManager _gameManager;
    [SerializeField] GameObject[] _spawnPoints;
    [SerializeField] GameObject _enemy;
    float _spawnTimer = 2f;
    float _spawnRateIncrease = 5f;

    void Start() {
        StartCoroutine(SpawnNextEnemy());
        StartCoroutine(SpawnRateIncreasse());
    }

    IEnumerator SpawnNextEnemy() {
        int nextSpawnLocation = Random.Range(0, _spawnPoints.Length);

        Instantiate(_enemy, _spawnPoints[nextSpawnLocation].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(_spawnTimer);

        if (!_gameManager._gameOver) {
            StartCoroutine(SpawnNextEnemy());
        }
    }

    IEnumerator SpawnRateIncreasse() {
        yield return new WaitForSeconds(_spawnRateIncrease);

        if (_spawnTimer >= 0.5f) {
            _spawnTimer -= 0.2f;
        }
        StartCoroutine(SpawnRateIncreasse());
    }
}
