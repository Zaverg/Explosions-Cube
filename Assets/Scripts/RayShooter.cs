using System;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private const int _buttonNumber = 0;

    [SerializeField] private float _rayDistance;

    private Camera _mainCamera;

    public event Action<ExplosionCube> Spawn;

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

            Spawn?.Invoke(objectHit);
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
