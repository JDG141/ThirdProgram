using System;

public class Multiplier
{
	public int Result { get; set; } = 1;

	public Multiplier()
	{
		
	}

	public void MultiplyBy(int num)
	{
		this.Result *= num;
	}
}
