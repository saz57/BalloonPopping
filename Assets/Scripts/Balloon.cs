using UnityEngine;
using UnityEngine.EventSystems;

public class Balloon : MonoBehaviour, IPointerDownHandler
{
    public float Speed = 5;
    public BalloonType TypeOfBalloon;
    public GameObject AfterPoppingEffect;
    public delegate void DestroyedByPlayer(BalloonType balloonType);
    public event DestroyedByPlayer OnDestroyByPlayer;
    
    public enum BalloonType
    {
        standart,
        heal,
        bad
    };

    private float _deltaSpeed;

    public void Start()
    {
        _deltaSpeed = Speed * Time.fixedDeltaTime;
    }

    public void FixedUpdate()
    {
        transform.position += Vector3.up * _deltaSpeed;
    }

    public void AddListener(DestroyedByPlayer listener)
    {
        OnDestroyByPlayer += listener;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!GameManager.IsPaused && !GameManager.GameEnded)
        {
            if (OnDestroyByPlayer != null)
            {
                OnDestroyByPlayer(TypeOfBalloon);
            }

            Instantiate(AfterPoppingEffect, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
