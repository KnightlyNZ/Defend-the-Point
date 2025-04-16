using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    private float shotTimer;

    public override void Enter()
    {
        moveTimer = 0f;
        losePlayerTimer = 0f;
        shotTimer = 0f;
    }

    public override void Exit()
    {
        // Cleanup if needed
    }

    public override void Perform()
    {
        if (enemy == null || enemy.Player == null || enemy.Agent == null) return;

        if (enemy.CanSeePlayer())
        {
            losePlayerTimer = 0f;
            moveTimer += Time.deltaTime;
            shotTimer += Time.deltaTime;

            // Look at the player
            enemy.transform.LookAt(enemy.Player.transform);

            // Shoot
            if (shotTimer > enemy.fireRate)
            {
                Shoot();
            }

            // Move occasionally
            if (moveTimer > Random.Range(3f, 7f))
            {
                Vector3 randomDirection = Random.insideUnitSphere * 5f;
                randomDirection.y = 0f;
                enemy.Agent.SetDestination(enemy.transform.position + randomDirection);
                moveTimer = 0f;
            }
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > 8f)
            {
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }

    private void Shoot()
    {
        if (enemy.gunBarrel == null || enemy.Player == null) return;

        Transform gunBarrel = enemy.gunBarrel;
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, gunBarrel.position, Quaternion.identity);

        // Get the direction to the player
        Vector3 shootDirection = (enemy.Player.transform.position - gunBarrel.position).normalized;

        // Apply randomization to the shoot direction
        float randomSpread = Random.Range(-3f, 3f);  // Randomize the angle slightly
        shootDirection = Quaternion.Euler(0f, randomSpread, 0f) * shootDirection;  // Apply rotation around the Y-axis to simulate randomness

        // Apply velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = shootDirection * 40f;

        Debug.Log("Shoot!");
        shotTimer = 0f;
    }
}
