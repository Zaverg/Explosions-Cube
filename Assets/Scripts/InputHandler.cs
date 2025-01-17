using System;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private float _rayDistance;
    public event Action<Transform, List<Transform>> Explodes;
    public event Func<Transform, List<Transform>> Spawn;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Transform objectHit = ShootRay();

            if (objectHit.GetComponent<ExplosionCube>() == null)
                return;

            List<Transform> children = Spawn?.Invoke(objectHit);
            
            if(children != null)
                Explodes?.Invoke(objectHit, children);
        }
    }

    private Transform ShootRay()
    {
        Ray ray;
        RaycastHit _hit;
        Camera mainCamera = Camera.main;

        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction);

        if (Physics.Raycast(ray, out _hit, _rayDistance))
            return _hit.transform;

        return null;
    }
}
