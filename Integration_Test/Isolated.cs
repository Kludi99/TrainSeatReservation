﻿//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Transactions;

namespace Integration_Test
{
    public class Isolated : Attribute, ITestAction
    {
        private TransactionScope _transactionScope;

        public ActionTargets Targets
        {
            get { return ActionTargets.Test; }
        }

        public void AfterTest(ITest test)
        {
            _transactionScope.Dispose();
        }

        public void BeforeTest(ITest test)
        {
            _transactionScope = new TransactionScope();
        }
    }
}
