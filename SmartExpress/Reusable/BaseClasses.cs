﻿using Core;
using Core.DB;
using Core.UnitOfWork;
using SmartExpress.Reusable.FilterAttributes;
using System.Web.Mvc;

namespace SmartExpress.Reusable
{
    [BeforePageLoads]
    public class BaseController : Controller
    {
        public User UserItem { get; set; }

        public IUnitOfWork UnitOfWork { get; set; }

        public BaseController()
        {
            UnitOfWork = new UnitOfWork(new DbCoreDataContext());
        }
    }
}