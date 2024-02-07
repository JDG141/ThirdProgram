using System;

public class BradfordFactor
{
    public int Factor { get; set; }

    int instances { get; set; }
    int days { get; set; }

	public BradfordFactor()
	{
	}

    public void SetDays(int days)
    {
        this.days = days;
        this.Factor = calcFactor();
    }

    public void SetInstances(int instances)
    {
        this.instances = instances;
        this.Factor = calcFactor();
    }

    public string GetConcern()
	{
        if (this.Factor >= 900)
            return "Sufficient days for a manager to consider dismissal.";

        if (this.Factor >= 100)
            return "Sufficient days for a manager to start a disciplinary action (oral warning, written warning, formal monitoring etc.)";

        if (this.Factor >= 45)
            return "Sufficient days for a manager to show concern and advise on possible disciplinary of financial actions, should more absences occur during an identified period.";

        return "No concern.";
    }

	int calcFactor()
	{
		return this.instances * this.instances * this.days;
	}
}
