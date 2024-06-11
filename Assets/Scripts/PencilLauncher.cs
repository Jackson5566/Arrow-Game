using UnityEngine;
using UnityEngine.EventSystems;

namespace PencilGame
{
    public class PencilLauncher : Service<PencilLauncher>
    {
        [SerializeField] private Pencil _pencil;

        [SerializeField] private float _time2Launch = 0.5f;
        [SerializeField, Range(0.5f, 5)] private float _waitingSeconds;
        [Header("Launch Speed"), Range(5, 20)] public float speed = 14;

        protected override void Awake()
        {
            base.Awake();
        }

        protected virtual void Start()
        {

        }

        void Update()
        {
            _time2Launch -= Time.deltaTime;
            _time2Launch = Mathf.Clamp(_time2Launch, 0, _waitingSeconds);


            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                 
                if (
                    touch.phase == TouchPhase.Began && _time2Launch == 0 
                    && !GameMode.Instance.isLose 
                    && !GameMode.Instance.isWinned && !IsTouchOverUI(touch))
                {
                    _time2Launch = _waitingSeconds;
                    InstantiatePencil();

                    OnLaunching();
                }
            }
        }


        bool IsTouchOverUI(Touch touch)
        {
            // Convertir la posición del toque a un objeto PointerEventData
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current)
            {
                position = touch.position
            };

            // Crear una lista para guardar los resultados del raycast
            var raycastResults = new System.Collections.Generic.List<RaycastResult>();

            // Realizar el raycast
            EventSystem.current.RaycastAll(pointerEventData, raycastResults);

            // Verificar si hay resultados
            return raycastResults.Count > 0;
        }

        protected virtual void OnLaunching()
        {

        }

        protected virtual Pencil InstantiatePencil()
        {
            return Instantiate(_pencil, transform.position, Quaternion.identity);
        }
    }
}

