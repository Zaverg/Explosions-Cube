using System;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const int _buttonNumber = 0;

    public event Action<ExplosionCube, List<ExplosionCube>> Explodes;
    public event Func<ExplosionCube, List<ExplosionCube>> Spawn;
    public event Func<ExplosionCube> Click;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_buttonNumber))
        {
            ExplosionCube objectHit = Click?.Invoke();

            if (objectHit == null)
                return;

            List<ExplosionCube> children = Spawn?.Invoke(objectHit);
            
            if(children != null)
                Explodes?.Invoke(objectHit, children);
        }
    }
}
