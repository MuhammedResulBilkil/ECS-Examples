using Unity.Entities;
using UnityEngine;

public class MoveSpeedAuthoring : MonoBehaviour
{
    public float moveSpeed;
}

public class MoveSpeedBaker : Baker<MoveSpeedAuthoring>
{
    public override void Bake(MoveSpeedAuthoring authoring)
    {
        Entity entity = GetEntity(authoring, TransformUsageFlags.Dynamic);

        AddComponent(entity, new MoveSpeedComponent
        {
            moveSpeed = authoring.moveSpeed
        });
    }
}