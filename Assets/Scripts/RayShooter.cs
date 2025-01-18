using System.Collections.Generic;
using System;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private const int _buttonNumber = 0;

    [SerializeField] private float _rayDistance;

    private Camera _mainCamera;

    public event Action<ExplosionCube, List<ExplosionCube>> Explodes;
    public event Func<ExplosionCube, List<ExplosionCube>> Spawn;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_buttonNumber))
        {
            ExplosionCube objectHit = Shoot();
            
            if (objectHit == null)
                return;

            List<ExplosionCube> children = Spawn?.Invoke(objectHit);

            if (children != null)
                Explodes?.Invoke(objectHit, children);
        }
    }

    private ExplosionCube Shoot()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, _rayDistance))
        {
            if (hit.transform.TryGetComponent<ExplosionCube>(out ExplosionCube explosionCube))
            {
                return explosionCube;
            }
        }

        return null;
    }
}
