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

    private List<Transform> Spawn(Transform obj)
    {
        List<Transform> cubs = new List<Transform>();

        if (CanDivide(obj))
        {
            int countCubs = UnityEngine.Random.RandomRange(_minNumbersSpawnCubs, _maxNumbersSpawnCubs + 1);
            int chance = obj.GetComponent<ExplosionCube>().Chance / _chanceDiv;

            for (int i = 0; i < countCubs; i++)
            {
                Transform cube = Instantiate(obj, obj.position, UnityEngine.Quaternion.identity);
                cube.GetComponent<ExplosionCube>().SetChance(chance);

                cubs.Add(cube);
            }
        }

        Destroy(obj.gameObject);

        return cubs;
    }

    private bool CanDivide(Transform obj)
    {
        int maxChance = 100;
        int minChance = 1;

        int chance = obj.GetComponent<ExplosionCube>().Chance;

        bool canDivide = UnityEngine.Random.RandomRange(minChance, maxChance) <= chance;

        return canDivide;
    }
}
