using System;

public class Person
{
    public BradfordFactor Bradford { get; set; }

    string firstName { get; set; }
	string surname { get; set; }
	int age { get; set; }
	int id { get; set; }

	static int nextId = 0;

	public Person(string firstName, string surname, int age)
	{
		this.firstName = firstName;
		this.surname = surname;
		this.age = age;
		this.id = nextId;
		this.Bradford = new BradfordFactor();
		nextId++;
	}

	public void SayHello()
	{
		Console.WriteLine(
			"Hello, I am {0} {1}. I am {2} year{3} old. I am person #{4}.",
			this.firstName,
			this.surname,
			this.age,
			(this.age == 1 ? "" : "s"),
			this.id
		);
	}

	public void SayBradford()
	{
		Console.WriteLine(
			"The Bradford Factor for {0} {1} is {2}: {3}",
			this.firstName,
			this.surname,
			this.Bradford.Factor,
			this.Bradford.GetConcern()
		);
	}

	public object Clone()
	{
		return new Person(this.firstName, this.surname, this.age);
	}
}
