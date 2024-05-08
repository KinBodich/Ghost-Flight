using UnityEngine;

public class TargetManager : MonoBehaviour
{
    
    [SerializeField] private GameObject _targetPrefab;

    private PlayerMovement _player;
    private MainTarget _target;
    private TargetDestroy _targetDestroy;

    private void Start()
    {
        _player = FindObjectOfType<PlayerMovement>();
        SpawnTarget();        
    }

    int s;
    private void SpawnTarget()
    {
        var _randY = Random.Range(_player.gameObject.transform.position.y - 50, _player.gameObject.transform.position.y + 50);
        var _randZ = Random.Range(_player.gameObject.transform.position.z + 20, _player.gameObject.transform.position.z + 100);
        var _targetSpawnPosition = new Vector3(0, _randY, _randZ);
        Instantiate(_targetPrefab, _targetSpawnPosition, Quaternion.identity);
        _target = FindObjectOfType<MainTarget>();
        _targetDestroy = _target.GetComponent<TargetDestroy>();
        _targetDestroy.OnTargetDestroy += SpawnTarget;
    }
}
