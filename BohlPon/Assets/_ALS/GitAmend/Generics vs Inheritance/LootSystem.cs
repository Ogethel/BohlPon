using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ALS.GitAmend.LootSystem
{
    public interface ILootResolver
    {
        bool ShouldDropLoot();
    }

    public class DropChanceResolver : ILootResolver
    {
        readonly float _dropChance;

        public DropChanceResolver(float dropChance)
        {
            this._dropChance = dropChance;
        }

		public bool ShouldDropLoot()
		{
			return Random.value <= _dropChance;
		}
    }
}
