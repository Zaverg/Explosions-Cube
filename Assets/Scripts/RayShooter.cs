using UnityEngine;

public class RayShooter : MonoBehaviour
{
    [SerializeField] private float _rayDistance;
    [SerializeField] private InputHandler _inputHandler;

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        _inputHandler.Click += Shoot;
    }

    private void OnDisable()
    {
        _inputHandler.Click -= Shoot;
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
