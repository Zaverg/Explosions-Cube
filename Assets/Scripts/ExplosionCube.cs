using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ExplosionCube : MonoBehaviour
{
    [SerializeField] private int _scaleDivision;
    [SerializeField] private bool _isFirst;

    private MeshRenderer _meshRenderer;
   
    [field: SerializeField] public int Chance { get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        transform.TryGetComponent<MeshRenderer>(out _meshRenderer);
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if (_isFirst)
        {
            _isFirst = false;
            return;
        }

        transform.localScale /= _scaleDivision;

        if (_meshRenderer != null)
            _meshRenderer.material.color = Random.ColorHSV();
    }

    public void SetChance(int chance)
    {
        if (chance >= 0)
            Chance = chance;
    }
}
