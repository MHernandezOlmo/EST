using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaFlotante : Interactable
{
    Vector3 pointA;
    Vector3 pointB;

    [SerializeField] AnimationCurve _animationCurve;
    private void Start()
    {
        base.Start();
        pointA = new Vector3(-2.9f, 38.42f, 39.31f);
        pointB = new Vector3(-2.9f, 38.42f, -17.11f);

        if (GameProgressController.GetPlatformLeft())
        {
            transform.parent.position = pointB;
        }
        else
        {
            transform.parent.position = pointA;
        }
    }
    public override void Interact()
    {
        StartCoroutine(CrMove());
    }

    IEnumerator CrMove()
    {
        CurrentSceneManager._canMove = false;
        FindObjectOfType<CharacterController>().detectCollisions = false;
        FindObjectOfType<MovementController>().transform.SetParent(gameObject.transform);
        FindObjectOfType<MovementController>().transform.SetParent(gameObject.transform);

        Vector3 characterOffset = FindObjectOfType<MovementController>().transform.position-transform.position;
        if (GameProgressController.GetPlatformLeft())
        {
            for (float i = 0; i < 4; i += Time.deltaTime)
            {
                yield return null;
                transform.parent.position = Vector3.Lerp(pointB, pointA, _animationCurve.Evaluate(i / 4f));
            }
            transform.parent.position = pointA;
            
            GameProgressController.SetPlatformLeft(false);
        }
        else
        {
            for (float i = 0; i < 4; i += Time.deltaTime)
            {
                yield return null;
                transform.parent.position = Vector3.Lerp(pointA, pointB, _animationCurve.Evaluate(i / 4f));
            }
            transform.parent.position = pointB;
            GameProgressController.SetPlatformLeft(true);
        }
        FindObjectOfType<MovementController>().transform.SetParent(null);
        CurrentSceneManager._canMove = true;
        FindObjectOfType<CharacterController>().detectCollisions = true;
        //FindObjectOfType<CharacterController>().transform.position = transform.position+ characterOffset;
    }
}
