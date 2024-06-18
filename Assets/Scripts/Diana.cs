using System.Collections;
using UnityEngine;

namespace PencilGame
{
    public class Diana : MonoBehaviour
    {
        [SerializeField, Header("Speed of rotation")] private float _startSpeed;
        [SerializeField] private float _speedModifier;
        [SerializeField] private float _time2ModifierMax;
        [SerializeField] private float _speedModifierTime;

        private float _speed;
        private float _time2Modifier;


        //protected override void Awake()
        //{
        //    base.Awake();
        //}

        protected void Start()
        {
            _speed = _startSpeed;
            _time2Modifier = 0;
        }

        private void Update()
        {
            transform.Rotate(Vector3.forward, _speed * Time.deltaTime);

            _time2Modifier += Time.deltaTime;
            if (_time2Modifier >= _time2ModifierMax)
            {
                _time2Modifier = 0;
                StartCoroutine(ModifySpeed());
            }
        }

        public IEnumerator ModifySpeed()
        {
            if(_speed < 0 )
            {
                _speed -= _speedModifier;
            }
            else
            {
                _speed += _speedModifier;
            }
            print(_speed);
            yield return new WaitForSeconds(_speedModifierTime);
            _speed = _startSpeed;
        }

        public void ChangeDirection()
        {
            _speed *= -1;
        }
    }
}

