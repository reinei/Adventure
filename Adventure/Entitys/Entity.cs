namespace Adventure.Entitys
{
	public abstract class Entity
	{
		public Position Pos;
		public double Health;

		protected float[] Resistances { get; private set; }

		protected byte[] Blocks { get; private set; }

		protected Entity(double health = 1)
		{
			this.Health = health;
			this.Resistances = new float[32];
			this.Blocks = new byte[32];
		}

		public bool Damage(int amount, DamageType d)
		{
			if (!MathHelper.blocks(amount, d, this.Blocks))
			{
				amount = MathHelper.damageAfterResistance(amount, d, Resistances);

				this.Health -= amount;
				if (this.Health <= 0)
				{
					this.Health = 0;
					return true;
				}
			}
			return false;
		}
	}
}