using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float MinGenerationSpeed = 2;
    public float MaxGenerationSpeed = 10;
    public float GenerationSpeedIncrement = 1f;
    public BalloonAndChanse[] SpawnObjects;
    public GameObject BalloonDestroyer;

    [SerializeField]
    private BalloonPopperHandler _balloonPopperHandler;

    private float _timer;
    private float _currenGenerationSpeed;
    private Vector2 _spawnSize;
    private Vector3 _camerasButtom;



    public void Start()
    {
        _timer = 0;
        _currenGenerationSpeed = MinGenerationSpeed;
        _camerasButtom = Camera.main.ScreenToWorldPoint(Vector3.forward);
        _spawnSize.x = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
        _spawnSize.y = Camera.main.ScreenToWorldPoint(Vector3.right * Screen.width).x;

        Vector3 balloonDestroyerPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, 1));
        balloonDestroyerPosition.y += BalloonDestroyer.transform.localScale.y;
        GameObject balloonDestroyer = Instantiate(BalloonDestroyer, balloonDestroyerPosition, new Quaternion());
        balloonDestroyer.transform.localScale = new Vector3((_spawnSize.y - _spawnSize.x), 1, 1);
        balloonDestroyer.GetComponent<BalloonDestroyer>().SetPopperHandler(_balloonPopperHandler);

        float chanseSum = 0;

        foreach (var spawnObject in SpawnObjects)
        {
            chanseSum += spawnObject.ChanseToSpawn;
        }

        if (chanseSum > 1)
        {
            for (int i = 0; i < SpawnObjects.Length; i++)
            {
                SpawnObjects[i].ChanseToSpawn = SpawnObjects[i].ChanseToSpawn / chanseSum;
            }
        }

    }


    public void Update()
    {
        _timer += Time.deltaTime;

        if (!GameManager.GameEnded && _timer > 60 / _currenGenerationSpeed)
        {
            _timer = 0;
            Vector3 spawnPosition = _camerasButtom;
            spawnPosition.x = Random.Range(_spawnSize.x, _spawnSize.y);

            int spawnObjectIndex = 0;
            float random = Random.value;
            float chanseSum = 0;
            Debug.Log("Random" + random);

            for (int i = 0; i < SpawnObjects.Length; i++)
            {
                if (random > chanseSum && random <= chanseSum + SpawnObjects[i].ChanseToSpawn)
                {
                    spawnObjectIndex = i;
                    break;
                }

                else
                {
                    chanseSum += SpawnObjects[i].ChanseToSpawn;
                }
            }

            GameObject balloon = Instantiate(SpawnObjects[spawnObjectIndex].BalloonPrefabs[Random.Range(0, SpawnObjects[spawnObjectIndex].BalloonPrefabs.Length)], spawnPosition, new Quaternion());
            balloon.GetComponent<Balloon>().AddListener(_balloonPopperHandler.OnBalloonPopped);

            if (_currenGenerationSpeed < MaxGenerationSpeed)
            {
                _currenGenerationSpeed += GenerationSpeedIncrement;

                if (_currenGenerationSpeed > MaxGenerationSpeed)
                {
                    _currenGenerationSpeed = MaxGenerationSpeed;
                }
            }

        }
    }
}
