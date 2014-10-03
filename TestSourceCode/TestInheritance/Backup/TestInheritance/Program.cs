using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            TestBase tb = new TestBase();
            tb.Print();

            Console.WriteLine(string.Format("ViewMode: {0}, RuleMode = {1}", ((ITest)tb).ViewMode, ((ITest)tb).RuleMode));
            */

            /*
            TestRule tr = new TestRule();
            tr.Print();

            ((TestBase)tr).Print();

            Console.WriteLine(string.Format("ViewMode: {0}, RuleMode = {1}", ((ITest)tr).ViewMode, ((ITest)tr).RuleMode));
            */

            /*
            TestSomething ts = new TestSomething();
            ts.Print();

            ((TestRule)ts).RuleMode = "Huy";
            ((TestRule)ts).Print();
            ((TestBase)ts).Print();

            Console.WriteLine(string.Format("ViewMode: {0}, RuleMode = {1}", ((ITest)ts).ViewMode, ((ITest)ts).RuleMode));
            */

            string Param = "Format:Litton;";

            string[] Params = Param.Split(';');

            foreach (string p in Params)
                Console.WriteLine(p);
        }
    }

    public interface ITest
    {
        string ViewMode { get; set; }
        string RuleMode { get; set; }
    }

    public class TestBase : ITest
    {
        protected string viewMode;
        protected string ruleMode;

        public TestBase()
        {
            ruleMode = "Vendor";
        }

        public string ViewMode
        {
            get { return viewMode; }
            set { viewMode = value; }
        }

        public string RuleMode
        {
            get { return ruleMode; }
            set { ruleMode = value; }
        }

        public virtual void Print()
        {
            Console.WriteLine(string.Format("ViewMode: {0}, RuleMode = {1}\n", this.ViewMode, this.RuleMode));
        }
    }

    public class TestRule : TestBase
    {
        public TestRule()
        {
            this.RuleMode = "Reviewer";
        }

        public void DoSomething()
        {
            Console.WriteLine("TestRule.DoSomething()");
        }

        public override void Print()
        {
            Console.WriteLine(string.Format("ViewMode: {0}, RuleMode = {1}\n", this.ViewMode, this.RuleMode));
        }
    }

    public class TestSomething : TestRule
    {
        public TestSomething()
        {
            this.RuleMode = "Something";
        }
    }
}
