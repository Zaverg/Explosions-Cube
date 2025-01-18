using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]

public class ExplosionCube : MonoBehaviour
{
    [SerializeField] private int _scaleDivision;
    [SerializeField] private bool _isFirst;

    private MeshRenderer _meshRenderer;
   
    [field: SerializeField] public int Chance { get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
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

        _meshRenderer.material.color = Random.ColorHSV();
    }

    public void SetChance(int chance)
    {
        if (chance >= 0)
            Chance = chance;
    }
}
