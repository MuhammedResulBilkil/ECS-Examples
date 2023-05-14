using Unity.Entities;
using UnityEngine;

public class PlayerSpawnerAuthoring : MonoBehaviour
{
    public GameObject playerPrefab;
}

public class PlayerSpawnerBaker : Baker<PlayerSpawnerAuthoring>
{
    public override void Bake(PlayerSpawnerAuthoring authoring)
    {
        Entity entity = GetEntity(authoring, TransformUsageFlags.None);
        
        AddComponent(entity, new PlayerSpawnerComponent
        {
            playerPrefab = GetEntity(authoring.playerPrefab, TransformUsageFlags.Dynamic)
        });
    }
}