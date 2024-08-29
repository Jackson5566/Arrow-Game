using UnityEngine;


public class Oscilation : MonoBehaviour
{
    public Transform[] points;

    private int currentIndex;

    public float speed;

    private int _maxIndex;

    [SerializeField] private bool _getRandom = true;

    private void Start()
    {
        _maxIndex = points.Length - 1;
        currentIndex = _getRandom ? GetRandomIndex() : 0;
    }

    private void Update()
    {
        if (Vector2.Distance(points[currentIndex].position, transform.position) <= 0.1f)
        {
            if (currentIndex == _maxIndex)
            {
                currentIndex = GetRandomIndex();
            }
            else
            {
                currentIndex++;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[currentIndex].position, speed * Time.deltaTime);

    }

    private void FixedUpdate()
    {
    }

    int GetRandomIndex()
    {
        return Random.Range(0, points.Length);
    }
}
