using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadios;
    [SerializeField] private InputHandler _inputHandler;

    private void OnEnable()
    {
        _inputHandler.Explodes += Explode;
    }

    private void OnDisable()
    {
        _inputHandler.Explodes -= Explode;
    }

    private void Explode(ExplosionCube parent, List<ExplosionCube> children)
    {
        foreach (ExplosionCube obj in children)
        {
            if(obj.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
                rigidbody.AddExplosionForce(_explosionForce, parent.transform.position, _explosionRadios);
        }
    }
}
