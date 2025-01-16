using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class ExplosionsCube : MonoBehaviour
{
    [field: SerializeField] public int Chance { get; private set; }

    public void SetChance(int chance)
    {
       if(chance >= 0)
        Chance = chance;
    }
}
