using Unity.Entities;

public partial class PlayerSpawnerSystem : SystemBase
{
    protected override void OnUpdate()
    {
        EntityQuery playerEntityQuery = EntityManager.CreateEntityQuery(typeof(PlayerTagComponent));
        
        PlayerSpawnerComponent playerSpawnerComponent = SystemAPI.GetSingleton<PlayerSpawnerComponent>();
        RefRW<RandomComponent> randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();

        EntityCommandBuffer entityCommandBuffer = SystemAPI
            .GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(World.Unmanaged);

        int spawnAmount = 10000;

        if (playerEntityQuery.CalculateEntityCount() < spawnAmount)
        {
            Entity spawnedEntity = entityCommandBuffer.Instantiate(playerSpawnerComponent.playerPrefab);
            
            entityCommandBuffer.SetComponent(spawnedEntity, new MoveSpeedComponent
            {
                moveSpeed = randomComponent.ValueRW.random.NextFloat(1f, 5f)
            });
        }
    }
}
