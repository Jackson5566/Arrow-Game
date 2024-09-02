using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PencilGame
{
    public enum TouchCondition
    {
        None, 
        Top,
        Down
    }

    public class PencilLauncher : MonoBehaviour
    {
        private float _time2Launch;

        [SerializeField] private Pencil _pencil;
        [SerializeField, Range(0.5f, 5)] private float _waitingSeconds;
        [Header("Launch Speed"), Range(-20, 20)] public float speed = 14;

        public TouchCondition touchCondition;

        public event Action onLaunching;


        protected virtual void Start()
        {
            _time2Launch = _waitingSeconds;
        }

        void Update()
        {
            _time2Launch -= Time.deltaTime;
            _time2Launch = Mathf.Clamp(_time2Launch, 0, _waitingSeconds);


            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                 
                if (
                    touch.phase == TouchPhase.Began && _time2Launch == 0 
                    && !GameMode.Instance.isLose 
                    && !GameMode.Instance.isWinned && !IsTouchOverUI(touch))
                {
                    if (touchCondition == TouchCondition.Down && touchPosition.y < 0)
                    {
                        Launch();
                    }

                    else if (touchCondition == TouchCondition.Top && touchPosition.y > 0)
                    {
                        Launch();
                    }

                    else if(touchCondition == TouchCondition.None)
                    {
                        Launch();
                    }
                }
            }

#if UNITY_EDITOR
            if (Input.GetKey(KeyCode.Space))
            {
                Launch();
            }
#endif
        }
        void Launch()
        {
            _time2Launch = _waitingSeconds;
            Pencil pencil = InstantiatePencil();
            PlayerMovement pen = pencil.GetComponent<PlayerMovement>();
            pen.speed = speed;
            pen.pos = new Vector2(-transform.position.x, -transform.position.y);

            OnLaunching();

            if (onLaunching != null)
                onLaunching();
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
            return Instantiate(_pencil, transform.position, transform.rotation);
        }
    }
}

