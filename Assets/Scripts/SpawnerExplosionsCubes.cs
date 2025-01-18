using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerExplosionsCubes : MonoBehaviour
{
    [SerializeField] private int _minNumbersSpawnCubs;
    [SerializeField] private int _maxNumbersSpawnCubs;
    [SerializeField] private int _chanceDiv;

    [SerializeField] private RayShooter _rayShooter;

    public event Action<ExplosionCube, List<ExplosionCube>> Explodes;

    private void OnEnable()
    {
        _rayShooter.Spawn += Spawn;
    }

    private void OnDisable()
    {
        _rayShooter.Spawn += Spawn;
    }

    private void Spawn(ExplosionCube explosionCube)
    {
        List<ExplosionCube> cubs = new List<ExplosionCube>();

        if (CanDivide(explosionCube))
        {
            int countCubs = UnityEngine.Random.Range(_minNumbersSpawnCubs, _maxNumbersSpawnCubs + 1);
            int chance = explosionCube.Chance / _chanceDiv;

            for (int i = 0; i < countCubs; i++)
            {
                ExplosionCube cube = Instantiate(explosionCube, explosionCube.transform.position, UnityEngine.Quaternion.identity);
                cube.SetChance(chance);

                cubs.Add(cube);
            }
        }

        Explodes?.Invoke(explosionCube, cubs);
    }

    private bool CanDivide(ExplosionCube explosionCube)
    {
        int maxChance = 100;
        int minChance = 1;

        return UnityEngine.Random.Range(minChance, maxChance) <= explosionCube.Chance;
    }
}
