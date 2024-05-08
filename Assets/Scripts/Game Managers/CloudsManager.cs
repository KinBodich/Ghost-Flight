using UnityEngine;

public class CloudsManager : MonoBehaviour
{
    private PlayerMovement _player;

    [SerializeField] private Transform _cloudParent;
    [SerializeField] private GameObject[] _sceneClouds;
    [SerializeField] private GameObject[] _bgSceneClouds;

    private Cloud _frontCloud = new Cloud(0, 70, 40, 40, 80, 240, 3, 6, 100); // об'єкт хмар переднього плану

    private Cloud _backgroundCloud = new Cloud(100, 150, 200, 100, 200, 300, 10, 15, 250); // об'єкт хмар заднього плану

    private void Start()
    {
        _player = FindObjectOfType<PlayerMovement>();
        _sceneClouds = GameObject.FindGameObjectsWithTag("Cloud");
        _bgSceneClouds = GameObject.FindGameObjectsWithTag("BackgroundCloud");
    }

    private void Update()
    {
        RespawnClouds(_sceneClouds, _frontCloud);

        RespawnClouds(_bgSceneClouds, _backgroundCloud);
    }

    private void RespawnClouds(GameObject[] clouds, Cloud cloudObj) // метод обробки хмар
    {
        foreach (var cloud in clouds)
        {
            Vector3 randCloudPos = new Vector3(Random.Range(-cloudObj.MinX, -cloudObj.MaxX), Random.Range(_player.transform.position.y - cloudObj.MinY, _player.transform.position.y + cloudObj.MaxY),
            Random.Range(_player.transform.position.z + cloudObj.MinZ, _player.transform.position.z + cloudObj.MaxZ));
            var randScale = Random.Range(cloudObj.MinScale, cloudObj.MaxScale);
            var randRotation = Random.Range(0, 2);
            int cloudRotation;
            if (randRotation == 0)
                cloudRotation = 90;
            else
                cloudRotation = 270;

            if (cloud.transform.position.z < _player.transform.position.z - cloudObj.RespawnPoint) // межа зміни
            {
                cloud.transform.localScale = new Vector3(1, 1, 1);
                cloud.transform.SetPositionAndRotation(randCloudPos, Quaternion.Euler(0, cloudRotation, 0)); // присвоєння нової позиції і повороту
                cloud.transform.localScale *= randScale; // присвоєння нового розміру
            }
        }
    }
}
