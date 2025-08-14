using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        // Flip the ship based on horizontal input
        if (xInput != 0)
        {
            player.FlipController(xInput); // input determines facing, not velocity
        }


        // Horizontal
        if (xInput != 0)
        {
            player.currentVelocity.x = Mathf.MoveTowards(
                player.currentVelocity.x,
                xInput * player.maxMoveSpeed,
                player.acceleration * Time.deltaTime
            );
        }
        else
        {
            player.currentVelocity.x = Mathf.MoveTowards(
                player.currentVelocity.x,
                0,
                player.deceleration * Time.deltaTime
            );
        }

        // Vertical
        if (yInput != 0)
        {
            player.currentVelocity.y = Mathf.MoveTowards(
                player.currentVelocity.y,
                yInput * player.maxVerticalSpeed,
                player.acceleration * Time.deltaTime
            );
        }
        else
        {
            player.currentVelocity.y = Mathf.MoveTowards(
                player.currentVelocity.y,
                0,
                player.deceleration * Time.deltaTime
            );
        }

        player.SetVelocity(player.currentVelocity.x, player.currentVelocity.y);

        if (player.currentVelocity == Vector2.zero)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
