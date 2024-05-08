using UnityEngine;

public class MainMenuCloudsMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] _cloudsPrefabs;
    private float _speed = 5;

    private void FixedUpdate()
    {
        foreach(var cloud in _cloudsPrefabs)
        {
            cloud.transform.Translate(Vector3.left * _speed * Time.deltaTime);

            SpawnCloud(cloud);
        }
    }

    private void SpawnCloud(GameObject cloud)
    {
        Vector3 randPosition = new Vector3(Random.Range(45, 70), Random.Range(-18, 6), Random.Range(-3, 30));
        var randScale = Random.Range(2f, 3);
        if(cloud.transform.position.x < -60)
        {
            cloud.transform.localScale = new Vector3(1, 1, 1);
            cloud.transform.position = randPosition;
            cloud.transform.localScale *= randScale;
        }
    }
}