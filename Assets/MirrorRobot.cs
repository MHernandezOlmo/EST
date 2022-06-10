using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MirrorRobot : MonoBehaviour
{

    Vector2 minPoint;
    Vector2 maxPoint;
    RectTransform _rectTransform;
    Coroutine routine;
    EspejoController _espejoController;

    private void Start()
    {
        _espejoController = FindObjectOfType<EspejoController>();
        minPoint = new Vector2(-652f, -182);
        maxPoint = new Vector2(652f, 182);
        _rectTransform = GetComponent<RectTransform>();
        GetComponent<Button>().onClick.AddListener(()=>Kill());
        Appear();
    }

    public void Appear()
    {
        StartCoroutine(CrAppear());
    }

    public void Kill()
    {
        if (routine != null)
        {
            StopCoroutine(routine);
            StartCoroutine(CrDie());
        }
    }
    IEnumerator CrDie()
    {
        for (float i = 0; i < 0.2f; i += Time.deltaTime)
        {
            yield return null;
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, i / 0.2f);
        }
        transform.localScale = Vector3.zero;

        float randomPointX = Random.Range(minPoint.x, maxPoint.x);
        float randomPointY = Random.Range(minPoint.y, maxPoint.y);
        Vector2 randomTarget = new Vector2(randomPointX, randomPointY);
        _rectTransform.anchoredPosition = randomTarget;
        _espejoController.RobotKills++;
        yield return new WaitForSeconds(Random.Range(2, 5));

        if (_espejoController.RobotKills < 30)
        {
            StartCoroutine(CrAppear());
        }
    }
    IEnumerator CrAppear()
    {
        for (float i = 0; i < 0.2f; i += Time.deltaTime)
        {
            yield return null;
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, i / 0.2f);
        }
        transform.localScale = Vector3.one;
        routine = StartCoroutine(CrMove());
    }

    IEnumerator CrMove()
    {
        float randomPointX = Random.Range(minPoint.x, maxPoint.x);
        float randomPointY = Random.Range(minPoint.y, maxPoint.y);
        Vector2 randomTarget = new Vector2(randomPointX, randomPointY);
        float distance = Vector2.Distance(_rectTransform.anchoredPosition, randomTarget);
        float speed = 200;
        Vector2 startPosition = _rectTransform.anchoredPosition;
        float timeToMove = distance / speed;
        for(float i = 0; i< timeToMove; i += Time.deltaTime)
        {
            yield return null;
            _rectTransform.anchoredPosition = Vector2.Lerp(startPosition, randomTarget, i/timeToMove);
        }
        _rectTransform.anchoredPosition = randomTarget;
        yield return new WaitForSeconds(1f);

        _espejoController.CreateDirt(_rectTransform.anchoredPosition);
        routine = StartCoroutine(CrMove());
    }
    
}
