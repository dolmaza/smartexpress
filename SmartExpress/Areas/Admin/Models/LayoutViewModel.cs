﻿using Core.Utilities;
using SmartExpress.Admin.Reusable;

namespace SmartExpress.Admin.Models
{
    public class LayoutViewModel : BaseViewModel
    {
        public string HomeUrl { get; set; }
        public string LogoutUrl { get; set; }

        public string DashboardUrl { get; set; }
        public string DictionariesUrl { get; set; }
        public string UsersUrl { get; set; }
        public string InvoicesUrl { get; set; }

        public SuccessErrorMessageInfo SuccessErrorMessageInfo { get; set; }

    }
}