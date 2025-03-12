using System;

public class Class1
{
	public Class1()
	{
		List<int> scores = [97, 92, 81, 60];
		
		for(int i = 0; i < scores.Length; i++)
		{
		if(scores[i] > 80)
			{
				Console.WriteLine($"Found a score over 80 {scores[i]}");

            }
		}
		return;
	}
}
