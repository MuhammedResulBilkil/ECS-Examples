using UnityEngine;

public class PlayerSpawnerGameObject : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;

    private void Start()
    {
        int spawnAmount = 0;

        for (int i = 0; i < spawnAmount; i++)
        {
            GameObject playerGameObject = Instantiate(_playerPrefab);
            MoveToPositionGameObject moveToPositionGameObject = playerGameObject.AddComponent<MoveToPositionGameObject>();
            moveToPositionGameObject.SetMoveSpeed(Random.Range(1f, 5f));
        }
    }
}
