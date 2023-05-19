using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //check damage
    [SerializeField] private Enemy enemyData;

    // go to palyer
    [SerializeField]private GameObject _player;
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _distanceBetween = 20f;

    private float _distance;

    //dashing
    private bool _canDash = true;
    private bool _isDashing;
    private float _dashingSpeed = 20f;
    private float _dashingTime = 0.2f;
    private float _maxTimeBetweenDashing = 20f; //this time's not fixed, it'll be a random number
    private float _dashRange = 3f;
    private float _minTimeBetweenDashing = 5f;


    private bool _angryState = false;


    private void Start()
    {
        
    }

    private void Update()
    {

        MovemetAndDash();
        if(enemyData.health < 100f && !_angryState)
        {
            _speed *= 2;
            _maxTimeBetweenDashing /= 2;

            _angryState = true;
        }
        
    }

    private void MovemetAndDash()
    {
        //Go to player
        _distance = Vector2.Distance(transform.position, _player.transform.position);
        Vector2 direction = _player.transform.position - transform.position;

        if (_distance < _distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, _player.transform.position, _speed * Time.deltaTime);
        }

        //dash
        if (_distance < _dashRange && _canDash) StartCoroutine(Dash());
    }

    private IEnumerator Dash()
    {
        _canDash= false;
        _isDashing= true;

        float originalSpeed = _speed;
        _speed = _dashingSpeed;

        yield return new WaitForSeconds(_dashingTime);

        _speed= originalSpeed/-2;
        _isDashing=false;
        _canDash= false;
        
        _maxTimeBetweenDashing = Random.Range(_minTimeBetweenDashing,_maxTimeBetweenDashing);
        yield return new WaitForSeconds(_maxTimeBetweenDashing);
        _speed = originalSpeed;
        _canDash = true;
    } 
}
