﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
	public sealed class ShipModel : Body
	{
		public ShipMind mind { get; set; }

		public void MoveTo(Vector3 newPosition)
		{
			Vector3 direction = (newPosition - position).normalized;
			m_smoothDir = Vector3.MoveTowards(m_smoothDir, direction, SMOOTHING);
			direction = m_smoothDir;
			Vector3 movement = new Vector3(direction.x, 0, direction.z);
			physicsBody.velocity = movement * SPEED;
			m_isMoved = true;
		}
		public override void OnDeleteByWorld()
		{
		}

		protected override void DoAfterDemaged()
		{
		}

		private Vector3 m_smoothDir;
		private bool m_isMoved = false;

		private const float SPEED = 30;
		private const float SMOOTHING = 15;
		private const float TILT = 2;

		private void Start()
		{
			health = 10000;
			touchDemage = 1000;
			mapBox = GameData.mapBox;
		}
		private void FixedUpdate()
		{
			UpdatePositionOnField();
			UpdateRotation();
			UpdateMoveingSpeed();
		}
		private void UpdatePositionOnField()
		{
			transform.position = new Vector3(
				Mathf.Clamp(position.x, mapBox.xMin, mapBox.xMax),
				MapPhysics.FLY_HEIGHT,
				Mathf.Clamp(position.z, mapBox.zMin, mapBox.zMax)
			);
		} 
		private void UpdateRotation()
		{
			float zEuler = physicsBody.velocity.x * -TILT;
			physicsBody.rotation = Quaternion.Euler(0, 0, zEuler);
		}
		private void UpdateMoveingSpeed()
		{
			Vector3 velocity = physicsBody.velocity;
			physicsBody.velocity = (m_isMoved) ? velocity : Vector3.zero;
			m_isMoved = false;
		}
	}
}
