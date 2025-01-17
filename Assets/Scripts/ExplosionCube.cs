using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ExplosionCube : MonoBehaviour
{
    [SerializeField] private int _scaleDivision;
    [SerializeField] private bool _isFirst;

    [field: SerializeField] public int Chance { get; private set; }

    private void Start()
    {
        if (_isFirst)
        {
            _isFirst = false;
            return;
        }

        transform.localScale /= _scaleDivision;

        if (transform.GetComponent<MeshRenderer>() != null)
            transform.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }

    public void SetChance(int chance)
    {
        if (chance >= 0)
            Chance = chance;
    }
}
