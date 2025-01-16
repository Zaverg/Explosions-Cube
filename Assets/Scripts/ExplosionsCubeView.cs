using UnityEngine;
public class ExplosionsCubeView : MonoBehaviour
{
    [SerializeField] private ExplosionsCubeController _explosionCubeController;
    [SerializeField] private int _scaleDivision;

    private void OnEnable()
    {
        _explosionCubeController.Explodes += SetupObject;
    }

    private void OnDisable()
    {
        _explosionCubeController.Explodes -= SetupObject;
    }

    private void SetupObject(Transform obj)
    {
        obj.localScale /= _scaleDivision;
        obj.transform.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }
}
