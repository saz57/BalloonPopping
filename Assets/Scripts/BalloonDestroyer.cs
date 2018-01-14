using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonDestroyer : MonoBehaviour
{
    private BalloonPopperHandler _popperHandler;

    public void SetPopperHandler(BalloonPopperHandler popperHandler)
    {
        _popperHandler = popperHandler;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Balloon balloon = collider.gameObject.GetComponent<Balloon>();

        if (balloon!= null)
        {
            _popperHandler.OnBalloonMissed(balloon.TypeOfBalloon);
        }

        Destroy(collider.gameObject);
    }
}
