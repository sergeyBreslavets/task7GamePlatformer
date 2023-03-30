using System.Collections;
using UnityEngine;

public class GeneratorMoney : MonoBehaviour
{
    [SerializeField] private Money _enemy;

    private int _maxCountEnemies = 0;
    private int _countEnemies = 0;
    private Transform[] _spawnPoints;
    private int _spawnTarget = 0;
    private float _timeDelay = 1f;

    private void Start()
    {
        _spawnPoints = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            _spawnPoints[i] = transform.GetChild(i);

        _maxCountEnemies = _spawnPoints.Length;
        StartCoroutine(Spawn());
    }

    public void SpawnMoreMoney()
    {
        _countEnemies--;

        if (_countEnemies == 0)
            StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_timeDelay);

        _spawnTarget = 0;

        while (_countEnemies < _maxCountEnemies)
        {
            Vector3 positionSpawn = _spawnPoints[_spawnTarget].position;
            positionSpawn.z = 0;
            Instantiate(_enemy, positionSpawn, _spawnPoints[_spawnTarget].rotation);
            _countEnemies++;
            _spawnTarget++;
        }
    }
}
