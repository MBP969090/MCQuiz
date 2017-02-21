using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
	class Program
	{
		static void Main(string[] args)
		{
			Controller c = new Controller();
			c.AnswerQuestion(1, new int[4] { 0, 0, 0, 1 });
			Console.WriteLine(c.GetQuestion(1));

			Console.Read();
		}
	}
}
