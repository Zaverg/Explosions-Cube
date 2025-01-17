using System.Collections.Generic;
using UnityEngine;

public class SpawnerExplosionsCubes : MonoBehaviour
{
    [SerializeField] private int _minNumbersSpawnCubs;
    [SerializeField] private int _maxNumbersSpawnCubs;
    [SerializeField] private int _chanceDiv;

    [SerializeField] private InputHandler _inputHandler;

    private void OnEnable()
    {
        _inputHandler.Spawn += Spawn;
    }

    private void OnDisable()
    {
        _inputHandler.Spawn += Spawn;
    }

    private List<ExplosionCube> Spawn(ExplosionCube explosionCube)
    {
        List<ExplosionCube> cubs = new List<ExplosionCube>();

        if (CanDivide(explosionCube))
        {
            int countCubs = Random.Range(_minNumbersSpawnCubs, _maxNumbersSpawnCubs + 1);
            int chance = explosionCube.Chance / _chanceDiv;

            for (int i = 0; i < countCubs; i++)
            {
                ExplosionCube cube = Instantiate(explosionCube, explosionCube.transform.position, UnityEngine.Quaternion.identity);
                cube.GetComponent<ExplosionCube>().SetChance(chance);

                cubs.Add(cube);
            }
        }

        Destroy(explosionCube.gameObject);

        return cubs;
    }

    private bool CanDivide(ExplosionCube explosionCube)
    {
        int maxChance = 100;
        int minChance = 1;

        return Random.Range(minChance, maxChance) <= explosionCube.Chance;
    }
}
