using UnityEngine;

public class BalloonPopperHandler : MonoBehaviour
{

    public HealsController HealsScript;
    public ScoreCounter ScoreCounterScript;

    public void OnBalloonPopped(Balloon.BalloonType balloonType)
    {
        if (!GameManager.IsPaused && !GameManager.GameEnded)
        {
            switch (balloonType)
            {
                case Balloon.BalloonType.standart:
                    ScoreCounterScript.AddScore(1);
                    break;
                case Balloon.BalloonType.heal:
                    ScoreCounterScript.AddScore(1);
                    HealsScript.AddHeals(1);
                    break;
                case Balloon.BalloonType.bad:
                    HealsScript.TakeDamage(3);
                    break;
            }
        }
    }

    public void OnBalloonMissed(Balloon.BalloonType balloonType)
    {
        switch (balloonType)
        {
            case Balloon.BalloonType.standart:
                HealsScript.TakeDamage(1);
                break;
            /*case Balloon.BalloonType.heal:
                ScoreCounterScript.AddScore(1);
                break;*/
           /* case Balloon.BalloonType.bad:
                HealsScript.TakeDamage(1);
                break;*/
        }
    }
}
