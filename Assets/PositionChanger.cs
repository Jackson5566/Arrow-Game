using PencilGame;
using UnityEngine;

[RequireComponent(typeof(PencilLauncher))]
public class PositionChanger : MonoBehaviour
{
    private int _currentIndex;
    private Vector2 initialPosition = new Vector2 (0, 0);

    [SerializeField] private Transform[] _points;
    [SerializeField] private PencilLauncher _pencilLauncher;

    #region Configurations
    [SerializeField] private bool _randomLaunchs;
    [SerializeField] private int _maxRandomLaunchs;

    [SerializeField] private int _maxLaunchs;
    private int _currentLaunchs;


    [SerializeField] private bool byTime;
    [SerializeField] private int time2Pass;
    private float time;

    [SerializeField] private bool _randomTime;
    [SerializeField] private int _maxRandomTime;

    #endregion

    private void OnEnable()
    {
        if (!byTime)
        {
            _pencilLauncher.onLaunching += IncreaseLaunchs;
        }
    }

    private void OnDisable()
    {
        if (!byTime)
        {
            _pencilLauncher.onLaunching -= IncreaseLaunchs;
        }
    }

    private void Update()
    {
        if (byTime) {
            time += Time.deltaTime;

            if (time >= time2Pass) {

                time = 0;
                VerifyAndSetRandomTime();
                ChangePosition();
            }
        }
    }

    private void Start()
    {
        _currentIndex = 0;
        _currentLaunchs = 0;

        VerifyAndSetRandomLaunchs();
        VerifyAndSetRandomTime();
    }

    /// <summary>
    /// Increase current arrow throws if: byTime = false
    /// </summary>
    public void IncreaseLaunchs()
    {
        _currentLaunchs++;

        if (_currentLaunchs == _maxLaunchs)
        {
            _currentLaunchs = 0;
            VerifyAndSetRandomLaunchs();
            ChangePosition();
        }
    }

    /// <summary>
    /// Change Launcher Position
    /// </summary>
    public void ChangePosition()
    {
        transform.position = _points[_currentIndex].position;

        if (_currentIndex == _points.Length - 1)
        {
            _currentIndex = 0;
        }

        _currentIndex++;

        float euler = Mathf.Atan2(- transform.position.y,  - transform.position.x);
        print("Angulo: " + euler * Mathf.Rad2Deg);

        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, euler * Mathf.Rad2Deg - 90);
    }

    private int GetRandomIndex()
    {
        return Random.Range(0, _points.Length);
    }


    /// <summary>
    /// If Random will set a random max launchs
    /// </summary>
    private void VerifyAndSetRandomLaunchs()
    {
        if (_randomLaunchs)
            _maxLaunchs = Random.Range(1, _maxRandomLaunchs);
    }

    private void VerifyAndSetRandomTime()
    {
        if (_randomTime)
            time2Pass = Random.Range(1, _maxRandomTime);
    }
}
