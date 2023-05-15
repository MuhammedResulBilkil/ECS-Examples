using Unity.Entities;

public partial class PlayerSpawnerSystem : SystemBase
{
    private int _spawnAmount = 10000;

    protected override void OnStartRunning()
    {
        base.OnStartRunning();
        
        /*RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
        RequireForUpdate<PlayerSpawnerComponent>();
        RequireForUpdate<RandomComponent>();*/
        
        EntityCommandBuffer entityCommandBuffer = SystemAPI
            .GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(World.Unmanaged);

        PlayerSpawnerComponent playerSpawnerComponent = SystemAPI.GetSingleton<PlayerSpawnerComponent>();
        RefRW<RandomComponent> randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();

        for (int i = 0; i < _spawnAmount; i++)
        {
            Entity spawnedEntity = entityCommandBuffer.Instantiate(playerSpawnerComponent.playerPrefab);
            
            entityCommandBuffer.SetComponent(spawnedEntity, new MoveSpeedComponent
            {
                moveSpeed = randomComponent.ValueRW.random.NextFloat(1f, 5f)
            });
        }
    }

    protected override void OnUpdate()
    {
        /*EntityQuery playerEntityQuery = EntityManager.CreateEntityQuery(typeof(PlayerTagComponent));
        
        PlayerSpawnerComponent playerSpawnerComponent = SystemAPI.GetSingleton<PlayerSpawnerComponent>();
        RefRW<RandomComponent> randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();

        EntityCommandBuffer entityCommandBuffer = SystemAPI
            .GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(World.Unmanaged);

        if (playerEntityQuery.CalculateEntityCount() < _spawnAmount)
        {
            Entity spawnedEntity = entityCommandBuffer.Instantiate(playerSpawnerComponent.playerPrefab);
            
            entityCommandBuffer.SetComponent(spawnedEntity, new MoveSpeedComponent
            {
                moveSpeed = randomComponent.ValueRW.random.NextFloat(1f, 5f)
            });
        }*/
    }
}
