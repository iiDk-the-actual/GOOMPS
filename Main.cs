using System;
using BepInEx;
using UnityEngine;

namespace GOOMPS
{
	[BepInPlugin("buzzbb.GOOMPS", "GOOMPS", "1.0.0")]
	public class Main : BaseUnityPlugin
	{
		private bool init;
		private void Update()
		{
			if (!init && GorillaLocomotion.GTPlayer.Instance != null)
			{
				init = true;
				OnGameInitialized();
            }
		}

		private void OnEnable()
		{
			HarmonyPatches.ApplyHarmonyPatches();
			if (mngr)
				mngr.enabled = true;
		}

		private void OnGameInitialized()
		{
			Cfg.LoadConfig();
            coll = new GameObject("GOOMPS Collision").AddComponent<SphereCollider>();
            mngr = coll.gameObject.AddComponent<GOOMPSCollision>();
			coll.gameObject.layer = 10;
			coll.gameObject.AddComponent<TransformFollow>().transformToFollow = GorillaTagger.Instance.offlineVRRig.transform;
			coll.isTrigger = true;
			coll.radius = Cfg.radius.Value;
			OnEnable();
        }

		private SphereCollider coll;
		private GOOMPSCollision mngr;
	}
}
