using ConsoleUI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class Context
    {
        private readonly Func<ESomeEnum, IStrategy> _strategyFactory;

        public Context(Func<ESomeEnum, IStrategy> strategyFactory)
        {
            _strategyFactory = strategyFactory;
        }

        public void DoSomething()
        {
            _strategyFactory(ESomeEnum.UseStrategyB).Do();
            _strategyFactory(ESomeEnum.UseStrategyA).Do();
        }
    }


}
