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

    private void Explode(Transform parent, List<Transform> children)
    {
        foreach (Transform obj in children)
        {
            if(obj.TryGetComponent<Rigidbody>(out Rigidbody rb))
                rb.AddExplosionForce(_explosionForce, parent.position, _explosionRadios);
        }
    }
}
