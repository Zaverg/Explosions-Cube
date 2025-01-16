using System;
using UnityEngine;
using System.Collections.Generic;

public class ExplosionsCubeController : MonoBehaviour
{
    [SerializeField] private int _minNumbersSpawnCubs;
    [SerializeField] private int _maxNumbersSpawnCubs;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadios;
    [SerializeField] private float _rayDistance;
    [SerializeField] private int _chanceDiv;

    private RaycastHit _hit;
    private Camera _mainCamera;

    private List<Transform> _childrenCubs = new List<Transform>();

    public event Action<Transform> Explodes;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(_childrenCubs != null)
                _childrenCubs.Clear();

            if (IsCube() == false)
                return;

            Transform objectHit = _hit.transform;

            if (CanDivide(objectHit))
                Divide(objectHit);

            Destroy(objectHit.gameObject);
            Explode(_childrenCubs);
        }
    }

    private bool IsCube()
    {
        Ray ray;

        ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction);

        if (Physics.Raycast(ray, out _hit, _rayDistance))
        {
            if (_hit.transform.GetComponent<ExplosionsCube>() == null)
                return false;

            return true;
        }

        return false;
    }

    private void Divide(Transform obj)
    {
        int countCubs = UnityEngine.Random.RandomRange(_minNumbersSpawnCubs, _maxNumbersSpawnCubs + 1);
        int chance = obj.GetComponent<ExplosionsCube>().Chance / _chanceDiv;

        for (int i = 0; i < countCubs; i++)
        {
            Transform cube = Instantiate(obj, obj.position, UnityEngine.Quaternion.identity);
            cube.GetComponent<ExplosionsCube>().SetChance(chance);
            Explodes?.Invoke(cube);

            _childrenCubs.Add(cube);
        }
    }

    private void Explode(List<Transform> objects)
    {
        foreach(Transform obj in objects)
            obj.transform.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, _hit.transform.position, _explosionRadios);
    }

    private bool CanDivide (Transform obj)
    {
        int maxChance = 100;
        int minChance = 1;

        int chance = obj.GetComponent<ExplosionsCube>().Chance;

        bool canDivide = UnityEngine.Random.RandomRange(minChance, maxChance) <= chance;

        return canDivide;
    }
}
