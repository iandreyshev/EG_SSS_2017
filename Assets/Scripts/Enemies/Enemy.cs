﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGame
{
	public abstract class Enemy : Body
	{
		public int points { get; set; }
		public byte starsCount { get; protected set; }

		protected bool isTimerWork { get; set; }
		protected bool isTimerReady { get; set; }
		protected float coldown { get; set; }

		protected sealed override void OnInitEnd()
		{
			InitProperties();

			if (healthBar)
			{
				healthBar.SetValue(healthPart);
				healthBar.isFadable = true;
			}

			if (roadController) roadController.OnEndReached.AddListener((T) =>
			{
				world.Remove(this, false);
			});
		}
		protected sealed override void PlayingUpdate()
		{
			UpdateTimer();
			TryShoot();
		}
		protected virtual void UpdateTimer()
		{
			if (isTimerWork)
			{
				Utils.UpdateTimer(ref m_timer, coldown, Time.fixedDeltaTime);
			}
		}
		protected abstract void InitProperties();
		protected abstract void Shoot();

		private float m_timer = 0;

		private void TryShoot()
		{
			if (isTimerWork && isTimerReady)
			{
				Shoot();
			}
		}
	}
}
