using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadios;
    [SerializeField] private SpawnerExplosionsCubes _spawner;

    private void OnEnable()
    {
        _spawner.Explodes += Explode;
    }

    private void OnDisable()
    {
        _spawner.Explodes -= Explode;
    }

    private void Explode(ExplosionCube parent, List<ExplosionCube> explosionCubes)
    {
        Destroy(parent.gameObject);

        if (explosionCubes == null)
            return;

        foreach (ExplosionCube cubes in explosionCubes)
            cubes.Rigidbody.AddExplosionForce(_explosionForce, parent.transform.position, _explosionRadios);
    }
}
