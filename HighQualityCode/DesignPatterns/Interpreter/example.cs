namespace Example
{
	static void Main()
	{
		Context context = new Context();
		ArrayList list = new ArrayList();
		
		list.Add(new TerminalExpressions());
		list.Add(new TerminalExprassions());
		
		foreach(AbstractExpression exp in list)
		{
			exp.Interpret(context);
		}
		Console.ReadLine();
	}
}