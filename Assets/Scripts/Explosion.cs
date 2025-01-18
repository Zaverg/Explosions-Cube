using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadios;
    [SerializeField] private RayShooter _rayShooter;

    private void OnEnable()
    {
        _rayShooter.Explodes += Explode;
    }

    private void OnDisable()
    {
        _rayShooter.Explodes -= Explode;
    }

    private void Explode(ExplosionCube parent, List<ExplosionCube> children)
    {
        foreach (ExplosionCube obj in children)
            obj.Rigidbody.AddExplosionForce(_explosionForce, parent.transform.position, _explosionRadios);
    }
}
