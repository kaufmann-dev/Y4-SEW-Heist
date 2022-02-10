using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Heist
{
    public class Heist
    {
        public async Task EvaluateHeist(string target)
        {
            Console.WriteLine("-----------------------------------------------\nStarting operation: Robbery " + target + "\n-----------------------------------------------\n");
            
            var stopWatch = Stopwatch.StartNew();
            
            Task<string> t7 = Task.Run(HireCrew);
            Task<string> t8 = Task.Run(GetBankPlans);
            Task<string> t9 = Task.Run(BuyGetawayCar);
            Task<string> t10 = Task.Run(BribeBankEmployee);
            var stage1 = await Task.WhenAll(t7, t8, t9, t10);
            Console.WriteLine(AggregateLog(stage1));
            
            Task<string> t6 = Task.Run(EnterBank);
            var stage2 = await Task.WhenAll(t6);
            Console.WriteLine(AggregateLog(stage2));
            
            Task<string> t3 = Task.Run(RobCounter3);
            Task<string> t4 = Task.Run(RobCounter2);
            Task<string> t5 = Task.Run(RobCounter1);
            var stage3 = await Task.WhenAll(t3, t4, t5);
            Console.WriteLine(AggregateLog(stage3));
            
            Task<string> t2 = Task.Run(LeaveBank);
            var stage4 = await Task.WhenAll(t2);
            Console.WriteLine(AggregateLog(stage4));
            
            Task<string> t1 = Task.Run(LoosePolice);
            var stage5 = await Task.WhenAll(t1);
            Console.WriteLine(AggregateLog(stage5));

            stopWatch.Stop();
            var elapsedTime = stopWatch.ElapsedMilliseconds;
            Console.WriteLine(AggregateLog("-----------------------------------------------\nSuccessfully robbed " + target + " in " + elapsedTime + " milliseconds\n-----------------------------------------------"));
        }
        private string AggregateLog(string message)
        {
            StringBuilder str = new StringBuilder();
            str.Append(message);
            str.AppendLine();
            return str.ToString();
        }
        private string AggregateLog(string[] messages)
        {
            StringBuilder str = new StringBuilder();
            foreach (var message in messages)
            {
                str.Append(message);
                str.Append(" ");
            }
            str.AppendLine();
            return str.ToString();
        }
        private string BribeBankEmployee()
        {
            Thread.Sleep(300);
            return ELog.BRIBE_BANK_EMPLOYEE.ToString();
        }
        private string BuyGetawayCar()
        {
            Thread.Sleep(200);
            return ELog.BUY_GETAWAY_CAR.ToString();
        }
        private string GetBankPlans()
        {
            Thread.Sleep(200);
            return ELog.GET_BANK_PLAN.ToString();
        }
        private string HireCrew()
        {
            Thread.Sleep(400);
            return ELog.HIRE_CREW.ToString();
        }
        private string EnterBank()
        {
            Thread.Sleep(100);
            return ELog.ENTER_BANK.ToString();
        }
        private string RobCounter1()
        {
            Thread.Sleep(300);
            return ELog.ROB_COUNTER_1.ToString();
        }
        private string RobCounter2()
        {
            Thread.Sleep(300);
            return ELog.ROB_COUNTER_2.ToString();
        }
        private string RobCounter3()
        {
            Thread.Sleep(300);
            return ELog.ROB_COUNTER_3.ToString();
        }
        private string LeaveBank()
        {
            Thread.Sleep(120);
            return ELog.LEAVE_BANK.ToString();
        }
        private string LoosePolice()
        {
            Thread.Sleep(300);
            return ELog.LOOSE_POLICE.ToString();
        }
    }
}