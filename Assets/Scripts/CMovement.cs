using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
public class CMovement : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation translation, ref CapsuleComponent capsuleComponent) =>
        {
            translation.Value.x += capsuleComponent.speed * Time.DeltaTime;

        });
    }
}
